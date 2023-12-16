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
    public partial class frm_FoodAndDrink : Form
    {
        public frm_FoodAndDrink()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsFoodAndDrink obj_clsFoodAndDrink = new clsFoodAndDrink();
        DataTable DT = new DataTable();
        String SPString = "";
        public bool _IsEdit = false;
        public int _FoodID = 0;
        
        private void frm_FoodAndDrink_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtPrice.Text = "0";
            txtQty.Text = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ok;
            if (txtName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Food Name");
                txtName.Focus();
            }
            else if (txtPrice.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Price");
                txtPrice.Focus();
            }
            else if (int.TryParse(txtPrice.Text, out ok) == false)
            {
                MessageBox.Show("Price Should Be Number");
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else if (Convert.ToInt32(txtPrice.Text) < 500 || Convert.ToInt32(txtPrice.Text) > 5000)
            {
                MessageBox.Show("Price Should Be Between 500 and 5000");
                txtPrice.Focus();
            }
            else if (txtQty.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Qty");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (int.TryParse(txtQty.Text, out ok) == false)
            {
                MessageBox.Show("Price Should Be Number");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", txtName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _FoodID != Convert.ToInt32(DT.Rows[0]["FoodID"]))
                {
                    MessageBox.Show("This Food Already Exits");
                    txtName.Focus();
                    txtName.SelectAll();
                }
                else
                {
                    obj_clsFoodAndDrink.FOODID = _FoodID;
                    obj_clsFoodAndDrink.NAME = txtName.Text;
                    obj_clsFoodAndDrink.PRICE = Convert.ToInt32(txtPrice.Text);
                    obj_clsFoodAndDrink.QTY = Convert.ToInt32(txtQty.Text);
                    if (_IsEdit)
                    {
                        obj_clsFoodAndDrink.ACTION = 1;
                        obj_clsFoodAndDrink.SaveData();
                        MessageBox.Show("Successfully Edited", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        obj_clsFoodAndDrink.ACTION = 0;
                        obj_clsFoodAndDrink.SaveData();
                        MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        
    }
}
