﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class ThanhVienDAOlmpl : ThanhVienDAO
    {
        private List<ThanhVien> thanhVienList;

        public ThanhVienDAOlmpl()
        {
            thanhVienList = new List<ThanhVien>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from THANHVIEN";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ThanhVien thanhVien = new ThanhVien();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    thanhVien.MaThanhVien = reader[0].ToString();
                    thanhVien.TenThanhVien = reader[1].ToString();
                    thanhVien.MaChuyenDi = reader[2].ToString();
                    thanhVien.TienThu = Int32.Parse(reader[3].ToString());

                    thanhVienList.Add(thanhVien);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addThanhVien(ThanhVien thanhVien)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.THANHVIEN (MATHANHVIEN,TENTHANHVIEN,MACHUYENDI,TIENTHU)" +
                " VALUES (@MaThanhVien,@TenThanhVien,@MaChuyenDi,@TienThu)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaThanhVien", thanhVien.MaThanhVien);
                    command.Parameters.AddWithValue("@TenThanhVien", thanhVien.TenThanhVien);
                    command.Parameters.AddWithValue("@MaChuyenDi", thanhVien.MaChuyenDi);
                    command.Parameters.AddWithValue("@TienThu", thanhVien.TienThu);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        public void deleteThanhVien(ThanhVien thanhVien)
        {
            String delQuery = $"DELETE FROM THANHVIEN WHERE MATHANHVIEN = '{thanhVien.MaThanhVien}';";
            DatabaseHelper.executeQuery(delQuery);
        }
        public void deleteThanhVien(string tenThanhVien)
        {
            String delQuery = $"DELETE FROM THANHVIEN WHERE TENTHANHVIEN = '{tenThanhVien}';";
            DatabaseHelper.executeQuery(delQuery);
        }

        public List<ThanhVien> GetAllThanhVien()
        {
            return thanhVienList;
        }

        public void updateThanhVien()
        {
            throw new NotImplementedException();
        }

    }
}