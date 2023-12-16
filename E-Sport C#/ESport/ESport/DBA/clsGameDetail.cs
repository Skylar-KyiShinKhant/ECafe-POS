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
    class clsGameDetail
    {
        public int GAMEID { get; set; }
        public int GAMESETID { get; set; }
        public string GAMENAME { get; set; }
        public string GAMESETTYPE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_GameDetail", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@GameID", GAMEID);
                sql.Parameters.AddWithValue("@GameSetID", GAMESETID);
                sql.Parameters.AddWithValue("@GameName", GAMENAME);
                sql.Parameters.AddWithValue("@GameSetType", GAMESETTYPE);
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
