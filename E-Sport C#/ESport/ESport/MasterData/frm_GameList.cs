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
    public partial class frm_GameList : Form
    {
        public frm_GameList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsGame obj_clsGame = new clsGame();
        String SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvGame.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvGame.Columns[0].Width = (dgvGame.Width / 100) * 33;
            dgvGame.Columns[1].Visible = false;
            dgvGame.Columns[2].Width = (dgvGame.Width / 100) * 33;
            dgvGame.Columns[3].Width = (dgvGame.Width / 100) * 33;
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "GameName");
            tslGameName.Text = "GameName";
        }

        private void ShowEntry()
        {
            if (dgvGame.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm_Game frm = new frm_Game();
                frm._GameID = Convert.ToInt32(dgvGame.CurrentRow.Cells["GameID"].Value.ToString());
                frm.txtGameName.Text = dgvGame.CurrentRow.Cells["GameName"].Value.ToString();
                frm.lblDate.Text = dgvGame.CurrentRow.Cells["Date"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_GameList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Game frm = new frm_Game();
            frm.ShowDialog();
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvGame_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvGame.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsGame.GAMEID = Convert.ToInt32(dgvGame.CurrentRow.Cells["GameID"].Value.ToString());
                    obj_clsGame.ACTION = 2;
                    obj_clsGame.SaveData();
                    MessageBox.Show("Successfully Deleted", "Successfully", MessageBoxButtons.OK);
                    ShowData();
                }
            }
        }

        private void tsmGameName_Click(object sender, EventArgs e)
        {
            tslGameName.Text = "GameName";
            SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "GameName");
        }

        private void tsmDate_Click(object sender, EventArgs e)
        {
            tslGameName.Text = "Date";
            SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "Date");
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslGameName.Text == "GameName")
            {
                SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            else if (tslGameName.Text == "Date")
            {
                SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            dgvGame.DataSource = obj_clsMainDB.SelectData(SPString);
        }
    }
}
