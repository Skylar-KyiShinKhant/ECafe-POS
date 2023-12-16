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
using ESport.MasterData;

namespace ESport
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        
        public void ShowMenu(String UserLevel)
        {
            String[] Arr_UserLevel = UserLevel.Split(',');
            for (int i = 1; i < menuStrip1.Items.Count; i++)
            {
                ToolStripMenuItem MainMenu = (ToolStripMenuItem)menuStrip1.Items[i];
                foreach (ToolStripItem SubMenu in MainMenu.DropDownItems)
                {
                    SubMenu.Enabled = false;
                    foreach (string Menu in Arr_UserLevel)
                    {
                        if (SubMenu.Text.ToString() == Menu.ToString())
                        {
                            SubMenu.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            ShowMenu("");
        }

        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            if (mnuLogIn.Text == "Log Out")
            {
                if (MessageBox.Show("Are You Sure You Want To Log Out?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    mnuLogIn.Text = "Log In";
                    ShowMenu("");
                }
                return;
            }
            clsMainDB obj_clsMainDB = new clsMainDB();
            frm_LogIn obj_frmLogIn = new frm_LogIn();
            DataTable DT = new DataTable();
            String UserName = "";
            String Password = "";

        Start:
            obj_frmLogIn.txtUserName.Text = UserName;
            obj_frmLogIn.txtPassword.Text = Password;
            if (obj_frmLogIn.ShowDialog() == DialogResult.OK)
            {
                if (obj_frmLogIn.txtUserName.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type User Name");
                    obj_frmLogIn.txtUserName.Focus();
                    goto Start;
                }
                UserName = obj_frmLogIn.txtUserName.Text;
                if (obj_frmLogIn.txtPassword.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type Password");
                    obj_frmLogIn.txtPassword.Focus();
                    goto Start;
                }
                Password = obj_frmLogIn.txtPassword.Text;
                string SPString = string.Format("SP_Select_UserSetting N'{0}', N'{1}', N'{2}'", obj_frmLogIn.txtUserName.Text.Trim().ToString(), obj_frmLogIn.txtPassword.Text.Trim().ToString(), "1");

                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0)
                {
                    Program.UserID = Convert.ToInt32(DT.Rows[0]["UserID"].ToString());
                    string UserLevel = DT.Rows[0]["UserLevel"].ToString();
                    mnuLogIn.Text = "Log Out";
                    ShowMenu(UserLevel);
                }
                else
                {
                    MessageBox.Show("Invalid User Name and Password");
                    goto Start;
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuRegistration_Click(object sender, EventArgs e)
        {
            frm_RegistrationList frm = new frm_RegistrationList();
            frm.ShowDialog();
        }

        private void mnuGameSet_Click(object sender, EventArgs e)
        {
            frm_GameSetList frm = new frm_GameSetList();
            frm.ShowDialog();
        }

        private void mnuGame_Click(object sender, EventArgs e)
        {
            frm_GameList frm = new frm_GameList();
            frm.ShowDialog();
        }

        private void mnuFoodAndDrink_Click(object sender, EventArgs e)
        {
            frm_FoodAndDrinkList frm = new frm_FoodAndDrinkList();
            frm.ShowDialog();
        }

        private void mnuUserSetting_Click(object sender, EventArgs e)
        {
            frm_UserSettingList frm = new frm_UserSettingList();
            frm.ShowDialog();
        }

        private void mnuPlay_Click(object sender, EventArgs e)
        {
            frm_PlayList frm = new frm_PlayList();
            frm.ShowDialog();
        }


    }
}
