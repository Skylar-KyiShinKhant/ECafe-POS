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
    class clsPlayDetail
    {
        public int PID { get; set; }
        public int FOODID { get; set; }
        public string FOODNAME { get; set; }
        public int FOODQTY { get; set; }
        public int FOODPRICE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_PlayDetail", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@PID", PID);
                sql.Parameters.AddWithValue("@FoodID", FOODID);
                sql.Parameters.AddWithValue("@FoodName", FOODNAME);
                sql.Parameters.AddWithValue("@FoodQty", FOODQTY);
                sql.Parameters.AddWithValue("@FoodPrice", FOODPRICE);
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
