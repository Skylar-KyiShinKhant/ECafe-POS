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
    class clsFoodAndDrink
    {
        public int FOODID { get; set; }
        public string NAME { get; set; }
        public int PRICE { get; set; }        
        public int QTY { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseCon();
                SqlCommand sql = new SqlCommand("SP_Insert_FoodAndDrink", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@FoodID", FOODID);
                sql.Parameters.AddWithValue("@Name", NAME);
                sql.Parameters.AddWithValue("@Price", PRICE);                
                sql.Parameters.AddWithValue("@Qty", QTY);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In Save Data");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
