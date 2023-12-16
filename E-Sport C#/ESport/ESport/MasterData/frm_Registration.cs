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
    public partial class frm_Registration : Form
    {
        public frm_Registration()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsRegistration obj_clsRegistration = new clsRegistration();
        DataTable DT = new DataTable();
        string SPString = "";
        public bool _IsEdit = false;
        public int _PlayerID = 0;

        private void frm_Registration_Load(object sender, EventArgs e)
        {
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblStartDate.Text = Month + "/" + Day + "/" + Year;
            txtCash.Text = "0";
            txtPlayerName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ok;
            if (txtPlayerName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type PlayerName");
                txtPlayerName.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Password");
                txtPassword.Focus();
            }
            else if (int.TryParse(txtPassword.Text, out ok) == false)
            {
                MessageBox.Show("Password Must Be Number");
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
            else if (txtCash.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Cash");
                txtCash.Focus();
            }
            else if (int.TryParse(txtCash.Text, out ok) == false)
            {
                MessageBox.Show("Cash Must Be Number");
                txtCash.Focus();
                txtCash.SelectAll();
            }
            else if (Convert.ToInt32(txtCash.Text) < 3000 || Convert.ToInt32(txtCash.Text) > 100000)
            {
                MessageBox.Show("Member Fees Should Be Between 3000 and 10,000");
                txtCash.Focus();
                txtCash.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", txtPlayerName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && Convert.ToInt32(DT.Rows[0]["PlayerID"]) != _PlayerID)
                {
                    MessageBox.Show("This Player Has Already Registered");
                    txtPlayerName.Focus();
                    txtPlayerName.SelectAll();
                }
                else
                {
                    obj_clsRegistration.PLAYERID = _PlayerID;
                    obj_clsRegistration.PLAYERNAME = txtPlayerName.Text;
                    obj_clsRegistration.PASSWORD = txtPassword.Text;
                    obj_clsRegistration.STARTDATE = lblStartDate.Text;
                    obj_clsRegistration.CASH = Convert.ToInt32(txtCash.Text);
                    if (_IsEdit)
                    {

                        obj_clsRegistration.ACTION = 1;
                        obj_clsRegistration.SaveData();
                        MessageBox.Show("Successfully Edited", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        obj_clsRegistration.ACTION = 0;
                        obj_clsRegistration.SaveData();
                        this.Close();
                        MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                    }
                }
            }
        }        
    }
}
