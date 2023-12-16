using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESport.DBA;

namespace ESport.MasterData
{
    public partial class frm_FoodAndDrinkList : Form
    {
        public frm_FoodAndDrinkList()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsFoodAndDrink obj_clsFoodAndDrink = new clsFoodAndDrink();
        String SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvFoodAndDrink.DataSource = obj_clsMainDB.SelectData(SPString);
            
            dgvFoodAndDrink.Columns[0].Width = (dgvFoodAndDrink.Width / 100) * 25;
            dgvFoodAndDrink.Columns[1].Visible = false;
            dgvFoodAndDrink.Columns[2].Width = (dgvFoodAndDrink.Width / 100) * 25;
            dgvFoodAndDrink.Columns[3].Width = (dgvFoodAndDrink.Width / 100) * 25;
            dgvFoodAndDrink.Columns[4].Width = (dgvFoodAndDrink.Width / 100) * 25;
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Name");
            tslFoodName.Text = "FoodName";
        }

        private void ShowEntry()
        {
            if (dgvFoodAndDrink.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm_FoodAndDrink frm = new frm_FoodAndDrink();
                frm._FoodID = Convert.ToInt32(dgvFoodAndDrink.CurrentRow.Cells["FoodID"].Value.ToString());
                frm.txtName.Text = dgvFoodAndDrink.CurrentRow.Cells["Name"].Value.ToString();
                frm.txtPrice.Text = dgvFoodAndDrink.CurrentRow.Cells["Price"].Value.ToString();
                frm.txtQty.Text = dgvFoodAndDrink.CurrentRow.Cells["Qty"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_FoodAndDrinkList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_FoodAndDrink frm = new frm_FoodAndDrink();
            frm.ShowDialog();
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvFoodAndDrink_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvFoodAndDrink.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else if (dgvFoodAndDrink.CurrentRow.Cells["Qty"].Value.ToString() != "0")
            {
                MessageBox.Show("This Food Has Qty. Cannot Be Deleted.");
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsFoodAndDrink.FOODID = Convert.ToInt32(dgvFoodAndDrink.CurrentRow.Cells["FoodID"].Value.ToString());
                    obj_clsFoodAndDrink.ACTION = 2;
                    obj_clsFoodAndDrink.SaveData();
                    MessageBox.Show("Successfully Deleted", "Successfully", MessageBoxButtons.OK);
                    ShowData();
                }
            }
        }        

        private void tsmFoodName_Click(object sender, EventArgs e)
        {
            tslFoodName.Text = "FoodName";
            SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Name");
        }

        private void tsmPrice_Click(object sender, EventArgs e)
        {
            tslFoodName.Text = "Price";
            SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Price");
        }

        private void tsmQty_Click(object sender, EventArgs e)
        {
            tslFoodName.Text = "Qty";
            SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Qty");
        }   

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslFoodName.Text == "FoodName")
            {
                SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            else if (tslFoodName.Text == "Price")
            {
                SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            else if (tslFoodName.Text == "Qty")
            {
                SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "4");
            }
            dgvFoodAndDrink.DataSource = obj_clsMainDB.SelectData(SPString);
        }
     
    }
}
