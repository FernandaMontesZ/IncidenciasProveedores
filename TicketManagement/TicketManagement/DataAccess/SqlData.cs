using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TicketManagement.DataAccess
{
    public class SqlData
    {
        public DataTable TicketsEditoriales = null;

        public DataTable spGetData(string spName, string[] spParameters)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Global"].ConnectionString))
            {
                cn.Open();
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand(spName, cn);

                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= spParameters.Count() - 1; i++)
                {
                    String[] substrings = spParameters[i].Split(':');
                    cmd.Parameters.AddWithValue(substrings[0], substrings[1]);
                }

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < rows.Length; i++)
                    //{
                    //    Console.WriteLine(rows[i]["Order_Back"]);
                    //}

                    TicketsEditoriales = dt;
                }
                else
                {
                    TicketsEditoriales = null;
                }
                //else
                //{

                //}
            }
            return TicketsEditoriales;
        }

    }
}