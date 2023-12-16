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
    public partial class frm_RegistrationList : Form
    {
        public frm_RegistrationList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsRegistration obj_clsRegistration = new clsRegistration();
        String SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvRegistration.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvRegistration.Columns[0].Width = (dgvRegistration.Width / 100) * 20;
            dgvRegistration.Columns[1].Visible = false;
            dgvRegistration.Columns[2].Width = (dgvRegistration.Width / 100) * 20;
            dgvRegistration.Columns[3].Width = (dgvRegistration.Width / 100) * 20;
            dgvRegistration.Columns[4].Width = (dgvRegistration.Width / 100) * 20;
            dgvRegistration.Columns[5].Width = (dgvRegistration.Width / 100) * 20;
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "PlayerName");
            tslPlayerName.Text = "PlayerName";
        }

        private void ShowEntry()
        {
            if (dgvRegistration.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm_Registration frm = new frm_Registration();
                frm._PlayerID = Convert.ToInt32(dgvRegistration.CurrentRow.Cells["PlayerID"].Value.ToString());
                frm.txtPlayerName.Text = dgvRegistration.CurrentRow.Cells["PlayerName"].Value.ToString();
                frm.txtPassword.Text = dgvRegistration.CurrentRow.Cells["Password"].Value.ToString();
                frm.lblStartDate.Text = dgvRegistration.CurrentRow.Cells["StartDate"].Value.ToString();
                frm.txtCash.Text = dgvRegistration.CurrentRow.Cells["Cash"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_RegistrationList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Registration frm = new frm_Registration();
            frm.ShowDialog();
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvRegistration_DoubleClick_1(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvRegistration_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvRegistration.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsRegistration.PLAYERID = Convert.ToInt32(dgvRegistration.CurrentRow.Cells["PlayerID"].Value.ToString());
                    obj_clsRegistration.ACTION = 2;
                    obj_clsRegistration.SaveData();
                    MessageBox.Show("Successfully Deleted", "Successfully", MessageBoxButtons.OK);
                    ShowData();
                }
            }
        }

        private void tsmPlayerName_Click(object sender, EventArgs e)
        {
            tslPlayerName.Text = "PlayerName";
            SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "PlayerName");
        }

        private void tsmStartDate_Click(object sender, EventArgs e)
        {
            tslPlayerName.Text = "StartDate";
            SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "StartDate");
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslPlayerName.Text == "PlayerName")
            {
                SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            else if (tslPlayerName.Text == "StartDate")
            {
                SPString = string.Format("SP_Select_Registration N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            dgvRegistration.DataSource = obj_clsMainDB.SelectData(SPString);
        }        
    }
}
