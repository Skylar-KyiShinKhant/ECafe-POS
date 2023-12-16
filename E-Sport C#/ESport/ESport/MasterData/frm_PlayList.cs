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

namespace ESport.MasterData
{
    public partial class frm_PlayList : Form
    {
        public frm_PlayList()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsPlay obj_clsPlay = new clsPlay();
        clsPlayDetail obj_clsPlayDetail = new clsPlayDetail();
        string SPString = "";
        UserControl PlayDetail;

        private void ShowData()
        {
            DataGridViewTextBoxColumn DGCol = new DataGridViewTextBoxColumn();
            DGCol.HeaderText = "";
            DGCol.DefaultCellStyle.NullValue = "+";
            DGCol.Width = 30;
            DGCol.ReadOnly = true;
            DGCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlayList.Columns.Add(DGCol);

            SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvPlayList.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvPlayList.Columns[1].Width = (dgvPlayList.Width / 100) * 5;
            dgvPlayList.Columns[2].Visible = false;
            dgvPlayList.Columns[3].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[4].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[5].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[6].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[7].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[8].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[9].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[10].Width = (dgvPlayList.Width / 100) * 10;
            dgvPlayList.Columns[11].Width = (dgvPlayList.Width / 100) * 15;

            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "PlayDate");
            tslLabel.Text = "PlayDate";
        }

        private void ShowPlayDetail()
        {
            PlayDetail = new ctl_PlayDetail();
            PlayDetail.Hide();
            Controls.Add(PlayDetail);
            Controls.SetChildIndex(PlayDetail, 0);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Play frm = new frm_Play();
            frm.ShowDialog();
            SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvPlayList.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void frm_PlayList_Load(object sender, EventArgs e)
        {
            ShowData();
            ShowPlayDetail();
            tstSearchWith.Focus();
        }

        private void dgvPlayList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgvPlayList[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    dgvPlayList[e.ColumnIndex, e.RowIndex].Value = "+";
                }
                if (dgvPlayList[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() == "+")
                {
                    Rectangle cellBounds = dgvPlayList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point offsetLocation = new Point(cellBounds.X, cellBounds.Y + cellBounds.Height);
                    offsetLocation.Offset(dgvPlayList.Location);
                    PlayDetail.Location = offsetLocation;

                    int PlayID = Convert.ToInt32(dgvPlayList.CurrentRow.Cells["PlayID"].Value.ToString());
                    DataGridView DGV = ((ESport.MasterData.ctl_PlayDetail)(PlayDetail)).dgvPlayDetail;
                    SPString = string.Format("SP_Select_PlayDetail N'{0}', N'{1}', N'{2}'", PlayID, "0", "1");
                    DGV.DataSource = obj_clsMainDB.SelectData(SPString);

                    DGV.Columns[0].Width = (DGV.Width / 100) * 25;
                    DGV.Columns[1].Visible = false;
                    DGV.Columns[2].Visible = false;
                    DGV.Columns[3].Width = (DGV.Width / 100) * 25;
                    DGV.Columns[4].Width = (DGV.Width / 100) * 25;
                    DGV.Columns[5].Width = (DGV.Width / 100) * 25;

                    PlayDetail.Show();
                    dgvPlayList[e.ColumnIndex, e.RowIndex].Value = "-";
                }
                else
                {
                    PlayDetail.Hide();
                    dgvPlayList[e.ColumnIndex, e.RowIndex].Value = "+";
                }
            }
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "PlayDate")
            {
                SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            else if (tslLabel.Text == "PlayerName")
            {
                SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            dgvPlayList.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void tsmPlayDate_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "PlayDate";
            SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "PlayDate");
        }

        private void tsmPlayerName_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "PlayerName";
            SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "PlayerName");
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlayList.CurrentRow.Cells["PlayID"].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data");
                dgvPlayList.Focus();
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsPlay.PLAYID = Convert.ToInt32(dgvPlayList.CurrentRow.Cells["PlayID"].Value.ToString());
                    obj_clsPlay.ACTION = 1;
                    obj_clsPlay.SaveData();

                    obj_clsPlayDetail.PID = Convert.ToInt32(dgvPlayList.CurrentRow.Cells["PlayID"].Value.ToString());
                    obj_clsPlayDetail.ACTION = 1;
                    obj_clsPlayDetail.SaveData();

                    MessageBox.Show("Successfully Deleted", "Successfully");
                    SPString = string.Format("SP_Select_Play N'{0}', N'{1}', N'{2}'", "0", "0", "0");
                    dgvPlayList.DataSource = obj_clsMainDB.SelectData(SPString);
                }
            }
        }

    }
}
