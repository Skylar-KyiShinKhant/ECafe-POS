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
    class clsGame
    {
        public int GAMEID { get; set; }
        public string GAMENAME { get; set; }
        public string DATE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Game", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@GameID", GAMEID);
                sql.Parameters.AddWithValue("@GameName", GAMENAME);
                sql.Parameters.AddWithValue("@Date", DATE);
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
