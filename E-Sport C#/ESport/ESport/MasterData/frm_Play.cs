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
    public partial class frm_Play : Form
    {
        public frm_Play()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsPlay obj_clsPlay = new clsPlay();
        clsPlayDetail obj_clsPlayDetail = new clsPlayDetail();
        clsFoodAndDrink obj_clsFoodAndDrink = new clsFoodAndDrink();
        clsRegistration obj_clsRegistration = new clsRegistration();
        DataTable DT = new DataTable();
        DataTable DTPlay = new DataTable();
        String SPString = "";
        int Count = 0;
        int _PlayID = 0;
        int _Cash = 0;

        private void CreateTable()
        {
            DTPlay.Columns.Clear();
            DTPlay.Rows.Clear();
            DTPlay.Columns.Add("FoodID");
            DTPlay.Columns.Add("FoodAndDrink");
            DTPlay.Columns.Add("FoodQty");
            DTPlay.Columns.Add("FoodPrice");
            DTPlay.Columns.Add("TotalAmount");
            dgvPlay.DataSource = DTPlay;
        }

        public void ShowData()
        {
            SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboPlayerName, SPString, "PlayerName", "PlayerID");

            SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboGameSetType, SPString, "GameSetType", "GameSetID");

            SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboGameName, SPString, "GameName", "GameID");

            SPString = string.Format("SP_Select_FoodAndDrink N'{0}', N'{1}', N'{2}'", "0", "0", "5");
            obj_clsMainDB.AddCombo(ref cboFoodAndDrink, SPString, "Name", "FoodID");
        }

        private void frm_Play_Load(object sender, EventArgs e)
        {
            CreateTable();
            ShowData();
            txtQty.Text = "0";
            txtPrice.Text = "0";
            lblTotalFoodCost.Text = "0";
            lblTotalGameCost.Text = "0";
            lblGrandTotal.Text = "0";
        }

        private void cboFoodAndDrink_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQty.Text = "0";
            txtPrice.Text = "0";
            txtQty.Focus();
        }

        private void CalculateTotal()
        {
            int totalFood = 0;
            
            if (DTPlay.Rows.Count > 0)
            {
                foreach (DataRow Dr in DTPlay.Rows)
                {
                    totalFood += Convert.ToInt32(Dr["TotalAmount"]);
                }
                lblTotalFoodCost.Text = totalFood.ToString();
                int Total = Convert.ToInt32(lblTotalFoodCost.Text) + Convert.ToInt32(lblTotalGameCost.Text);
                lblGrandTotal.Text = Total.ToString();
            }
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (DTPlay.Rows.Count <= 0)
            {
                MessageBox.Show("There Is No Data");
            }
            else if (dgvPlay.CurrentRow.Cells["FoodID"].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
            }
            else
            {
                DataRow[] Arr_Dr = DTPlay.Select("FoodID='" + dgvPlay.CurrentRow.Cells["FoodID"].Value.ToString() + "'");
                DataRow DR = Arr_Dr[0];
                DR.Delete();
                dgvPlay.DataSource = DTPlay;
                CalculateTotal();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", Convert.ToInt32(cboPlayerName.SelectedValue.ToString()), "0", "4");
            DT = obj_clsMainDB.SelectData(SPString);
            _Cash = Convert.ToInt32(DT.Rows[0]["Cash"]);

            if (cboPlayerName.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select PlayerName");
                cboPlayerName.Focus();
            }
            else if (cboGameSetType.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select GameSetType");
                cboGameSetType.Focus();
            }
            else if (cboGameName.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select GameName");
                cboGameName.Focus();
            }
            else if (txtPlayedHours.Text == string.Empty)
            {
                MessageBox.Show("Please Type Played Hours");
                txtPlayedHours.Focus();
            }
            else if (_Cash < Convert.ToInt32(lblGrandTotal.Text) || _Cash == 0)
            {
                MessageBox.Show("Player Does Not Have Enough Cash Left");
                frm_RegistrationList frm = new frm_RegistrationList();
                this.Close();
                frm.ShowDialog();
            }
            else
            {
                if (DTPlay.Rows.Count <= 0)
                {
                    obj_clsPlay.PLAYID = _PlayID;
                    obj_clsPlay.PLAYDATE = dtpDate.Text;
                    obj_clsPlay.PLAYERID = Convert.ToInt32(cboPlayerName.SelectedValue.ToString());
                    obj_clsPlay.GAMESETID = Convert.ToInt32(cboGameSetType.SelectedValue.ToString());
                    obj_clsPlay.GAMEID = Convert.ToInt32(cboGameName.SelectedValue.ToString());
                    obj_clsPlay.PRICEPERHOUR = Convert.ToInt32(lblPricePerHour.Text);
                    obj_clsPlay.PLAYEDHOURS = Convert.ToInt32(txtPlayedHours.Text);
                    obj_clsPlay.TOTALFOODCOST = Convert.ToInt32(lblTotalFoodCost.Text);
                    obj_clsPlay.TOTALGAMECOST = Convert.ToInt32(lblTotalGameCost.Text);
                    obj_clsPlay.GRANDTOTAL = Convert.ToInt32(lblGrandTotal.Text);
                    obj_clsPlay.ACTION = 0;
                    obj_clsPlay.SaveData();

                    obj_clsRegistration.PLAYERID = Convert.ToInt32(cboPlayerName.SelectedValue.ToString());
                    obj_clsRegistration.PLAYERNAME = cboPlayerName.Text;
                    obj_clsRegistration.CASH = Convert.ToInt32(lblGrandTotal.Text);
                    obj_clsRegistration.ACTION = 3;
                    obj_clsRegistration.SaveData();
                }
                else
                {
                    obj_clsPlay.PLAYID = _PlayID;
                    obj_clsPlay.PLAYDATE = dtpDate.Text;
                    obj_clsPlay.PLAYERID = Convert.ToInt32(cboPlayerName.SelectedValue.ToString());
                    obj_clsPlay.GAMESETID = Convert.ToInt32(cboGameSetType.SelectedValue.ToString());
                    obj_clsPlay.GAMEID = Convert.ToInt32(cboGameName.SelectedValue.ToString());
                    obj_clsPlay.PRICEPERHOUR = Convert.ToInt32(lblPricePerHour.Text);
                    obj_clsPlay.PLAYEDHOURS = Convert.ToInt32(txtPlayedHours.Text);
                    obj_clsPlay.TOTALFOODCOST = Convert.ToInt32(lblTotalFoodCost.Text);
                    obj_clsPlay.TOTALGAMECOST = Convert.ToInt32(lblTotalGameCost.Text);
                    obj_clsPlay.GRANDTOTAL = Convert.ToInt32(lblGrandTotal.Text);
                    obj_clsPlay.ACTION = 0;
                    obj_clsPlay.SaveData();

                    obj_clsRegistration.PLAYERID = Convert.ToInt32(cboPlayerName.SelectedValue.ToString());
                    obj_clsRegistration.PLAYERNAME = cboPlayerName.Text;
                    obj_clsRegistration.CASH = Convert.ToInt32(lblGrandTotal.Text);
                    obj_clsRegistration.ACTION = 3;
                    obj_clsRegistration.SaveData();

                    SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "1");
                    DT = obj_clsMainDB.SelectData(SPString);
                    _PlayID = Convert.ToInt32(DT.Rows[0]["PlayID"].ToString());
                    for (int i = 0; i < DTPlay.Rows.Count; i++)
                    {
                        obj_clsPlayDetail.PID = _PlayID;
                        obj_clsPlayDetail.FOODID = Convert.ToInt32(DTPlay.Rows[i]["FoodID"].ToString());
                        obj_clsPlayDetail.FOODNAME = DTPlay.Rows[i]["FoodAndDrink"].ToString();
                        obj_clsPlayDetail.FOODQTY = Convert.ToInt32(DTPlay.Rows[i]["FoodQty"].ToString());
                        obj_clsPlayDetail.FOODPRICE = Convert.ToInt32(DTPlay.Rows[i]["FoodPrice"].ToString());
                        obj_clsPlayDetail.ACTION = 0;
                        obj_clsPlayDetail.SaveData();

                        obj_clsFoodAndDrink.FOODID = Convert.ToInt32(DTPlay.Rows[i]["FoodID"].ToString());
                        obj_clsFoodAndDrink.QTY = Convert.ToInt32(DTPlay.Rows[i]["FoodQty"].ToString());
                        obj_clsFoodAndDrink.ACTION = 3;
                        obj_clsFoodAndDrink.SaveData();

                    }
                    MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }               

        private void txtPlayedHours_TextChanged(object sender, EventArgs e)
        {
            if(txtPlayedHours.Text == string.Empty)
            {
                lblTotalGameCost.Text = "0";
            }
            else if (Convert.ToInt32(txtPlayedHours.Text) >= 0)
            {
                int totalGame = 0;
                totalGame = Convert.ToInt32(lblPricePerHour.Text) * Convert.ToInt32(txtPlayedHours.Text);           
                lblTotalGameCost.Text = totalGame.ToString();
            }
            int Total = Convert.ToInt32(lblTotalFoodCost.Text) + Convert.ToInt32(lblTotalGameCost.Text);
            lblGrandTotal.Text = Total.ToString();
                
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ok = 0;

            if (Convert.ToInt32(cboFoodAndDrink.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Please Choose Food And Drink");
                cboFoodAndDrink.Focus();
            }
            else if (txtQty.Text == string.Empty)
            {
                MessageBox.Show("Please Type Qty");
                txtQty.Focus();
            }
            else if (int.TryParse(txtQty.Text, out ok) == false)
            {
                MessageBox.Show("Qty Should Be Number");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (txtPrice.Text == string.Empty)
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
            else
            {
                if (DTPlay.Rows.Count > 0)
                {
                    DataRow[] Arr_Dr = DTPlay.Select("FoodID='" + cboFoodAndDrink.SelectedValue.ToString() + "'");
                    Count = Arr_Dr.Length;
                    if (Count != 0)
                    {
                        MessageBox.Show("This Record Already Exists");
                        return;
                    }
                }
                DataRow DR = DTPlay.NewRow();
                DR["FoodID"] = cboFoodAndDrink.SelectedValue.ToString();
                DR["FoodAndDrink"] = cboFoodAndDrink.Text;
                DR["FoodQty"] = txtQty.Text;
                DR["FoodPrice"] = txtPrice.Text;
                DR["TotalAmount"] = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text);
                DTPlay.Rows.Add(DR);
                dgvPlay.DataSource = DTPlay;
                cboFoodAndDrink.SelectedIndex = 0;
                CalculateTotal();
            }
        }
    }      
}

