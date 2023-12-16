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
    public partial class frm_UserSetting : Form
    {
        public frm_UserSetting()
        {
            InitializeComponent();
        }

        clsUserSetting obj_clsUserSetting = new clsUserSetting();
        clsMainDB obj_clsMainDB = new clsMainDB();
        frm_Main obj_clsMain = new frm_Main();

        DataTable DT = new DataTable();
        String SPString = "";
        public bool _IsEdit = false;
        public String UserLevel = "";
        public int UserID = 0;

        private void ShowUserLevel()
        {
            chkUserLevel.Items.Clear();
            for (int i = 1; i < obj_clsMain.menuStrip1.Items.Count; i++)
            {
                ToolStripMenuItem mnuMain = (ToolStripMenuItem)obj_clsMain.menuStrip1.Items[i];
                foreach (ToolStripItem mnuSub in mnuMain.DropDownItems)
                {
                    chkUserLevel.Items.Add(mnuSub.Text.ToString());
                }
            }
            if (_IsEdit)
            {
                string[] Arr_UserLevel = UserLevel.Split(',');
                for (int i = 0; i < chkUserLevel.Items.Count; i++)
                {
                    for (int j = 0; j < Arr_UserLevel.Length; j++)
                    {
                        if (chkUserLevel.Items[i].ToString() == Arr_UserLevel[j].ToString())
                        {
                            chkUserLevel.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void frm_UserSetting_Load(object sender, EventArgs e)
        {
            ShowUserLevel();
            String Month = String.Format("{0:D2}", DateTime.Now.Month);
            String Day = String.Format("{0:D2}", DateTime.Now.Day);
            String Year = String.Format("{0:D2}", DateTime.Now.Year);
            lblUpdateDate.Text = Month + "/" + Day + "/" + Year;
            txtUserName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserLevel = string.Empty;
            foreach (object itemChecked in chkUserLevel.CheckedItems)
            {
                UserLevel = UserLevel + itemChecked.ToString() + ",";
            }
            if (txtUserName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type User Name");
                txtUserName.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Password");
                txtPassword.Focus();
            }
            else if (txtConfirmPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Confirmed Password");
                txtConfirmPassword.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() != txtConfirmPassword.Text.Trim().ToString())
            {
                MessageBox.Show("Password And Confirmed Password Should Be Same.");
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
            }
            else if (UserLevel.ToString() == string.Empty)
            {
                MessageBox.Show("Please Choose User Level");
            }
            else
            {
                SPString = string.Format("SP_Select_UserSetting N'{0}', N'{1}', N'{2}'", txtUserName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString(), "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && UserID != Convert.ToInt32(DT.Rows[0]["UserID"].ToString()))
                {
                    MessageBox.Show("This User Already Exists.");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
                else
                {
                    obj_clsUserSetting.UNAME = txtUserName.Text.Trim().ToString();
                    obj_clsUserSetting.PASS = txtPassword.Text.Trim().ToString();
                    obj_clsUserSetting.USERLEVEL = UserLevel;
                    obj_clsUserSetting.UPDATE = lblUpdateDate.Text.Trim().ToString();
                    if (_IsEdit)
                    {
                        obj_clsUserSetting.USERID = UserID;
                        obj_clsUserSetting.ACTION = 1;
                        obj_clsUserSetting.SaveData();
                        MessageBox.Show("Successfully Edited", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        obj_clsUserSetting.ACTION = 0;
                        obj_clsUserSetting.SaveData();
                        MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }            
                   
    }
}
