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
    class clsPlay
    {
        public int PLAYID { get; set; }
        public string PLAYDATE { get; set; }
        public int PLAYERID { get; set; }
        public int GAMESETID { get; set; }
        public int GAMEID { get; set; }
        public int PRICEPERHOUR { get; set; }
        public int PLAYEDHOURS { get; set; }
        public int TOTALFOODCOST { get; set; }
        public int TOTALGAMECOST { get; set; }
        public int GRANDTOTAL { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_Play", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@PlayID", PLAYID);
                sql.Parameters.AddWithValue("@PlayDate", PLAYDATE);
                sql.Parameters.AddWithValue("@PlayerID", PLAYERID);
                sql.Parameters.AddWithValue("@GameSetID", GAMESETID);
                sql.Parameters.AddWithValue("@GameID", GAMEID);
                sql.Parameters.AddWithValue("@PricePerHour", PRICEPERHOUR);
                sql.Parameters.AddWithValue("@PlayedHours", PLAYEDHOURS);
                sql.Parameters.AddWithValue("@TotalFoodCost", TOTALFOODCOST);
                sql.Parameters.AddWithValue("@TotalGameCost", TOTALGAMECOST);
                sql.Parameters.AddWithValue("@GrandTotal", GRANDTOTAL);
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
