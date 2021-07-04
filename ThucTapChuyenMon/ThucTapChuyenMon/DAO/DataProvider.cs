﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider(){}
        private string connSTR = "Data Source=DESKTOP-EDKIR8O;Initial Catalog=QuanLiTiemNuoc;Integrated Security=True";

        

        public DataTable ExecuteQuery(string query,object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connSTR))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
            
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
            {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connSTR))
            {    

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;

        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(connSTR))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    object[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                conn.Close();
            }
            return data;

        }
    }
}
