using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ESport.DBA
{
    class clsRegistration
    {
        public int PLAYERID { get; set; }
        public string PLAYERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string STARTDATE { get; set; }
        public int CASH { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Registration", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@PlayerID", PLAYERID);
                sql.Parameters.AddWithValue("@PlayerName", PLAYERNAME);
                sql.Parameters.AddWithValue("@Password", PASSWORD);
                sql.Parameters.AddWithValue("@StartDate", STARTDATE);
                sql.Parameters.AddWithValue("@Cash", CASH);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In SaveData");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }

    }
}
