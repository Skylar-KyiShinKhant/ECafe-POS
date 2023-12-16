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
    public partial class frm_GameSetList : Form
    {
        public frm_GameSetList()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsGameSet obj_clsGameSet = new clsGameSet();
        String SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvGameSet.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvGameSet.Columns[0].Width = (dgvGameSet.Width / 100) * 33;
            dgvGameSet.Columns[1].Visible = false;
            dgvGameSet.Columns[2].Width = (dgvGameSet.Width / 100) * 33;
            dgvGameSet.Columns[3].Width = (dgvGameSet.Width / 100) * 33;
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "GameSetType");
            tslGameSetType.Text = "GameSetType";
        }

        private void ShowEntry()
        {
            if (dgvGameSet.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm_GameSet frm = new frm_GameSet();
                frm._GameSetID = Convert.ToInt32(dgvGameSet.CurrentRow.Cells["GameSetID"].Value.ToString());
                frm.txtGameSetType.Text = dgvGameSet.CurrentRow.Cells["GameSetType"].Value.ToString();
                frm.lblDate.Text = dgvGameSet.CurrentRow.Cells["Date"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_GameSetList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_GameSet frm = new frm_GameSet();
            frm.ShowDialog();
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvGameSet_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvGameSet.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsGameSet.GAMESETID = Convert.ToInt32(dgvGameSet.CurrentRow.Cells["GameSetID"].Value.ToString());
                    obj_clsGameSet.ACTION = 2;
                    obj_clsGameSet.SaveData();
                    MessageBox.Show("Successfully Deleted", "Successfully", MessageBoxButtons.OK);
                    ShowData();
                }
            }
        }

        private void tsmGameSetType_Click(object sender, EventArgs e)
        {
            tslGameSetType.Text = "GameSetType";
            SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "GameSetType");
        }

        private void tsmDate_Click(object sender, EventArgs e)
        {
            tslGameSetType.Text = "Date";
            SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Date");
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslGameSetType.Text == "GameSetType")
            {
                SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            else if (tslGameSetType.Text == "Date")
            {
                SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            dgvGameSet.DataSource = obj_clsMainDB.SelectData(SPString);
        }
    }
}
