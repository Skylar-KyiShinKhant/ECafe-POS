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
    public partial class frm_Game : Form
    {
        public frm_Game()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsGame obj_clsGame = new clsGame();
        DataTable DT = new DataTable();
        String SPString = "";
        public bool _IsEdit = false;
        public int _GameID = 0;

        private void frm_Game_Load(object sender, EventArgs e)
        {
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblDate.Text = Month + "/" + Day + "/" + Year;
            txtGameName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGameName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Game Name");
                txtGameName.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Game N'{0}', N'{1}', N'{2}'", txtGameName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _GameID != Convert.ToInt32(DT.Rows[0]["GameID"]))
                {
                    MessageBox.Show("This Game Already Exits");
                    txtGameName.Focus();
                    txtGameName.SelectAll();
                }
                else
                {
                    obj_clsGame.GAMEID = _GameID;
                    obj_clsGame.GAMENAME = txtGameName.Text;
                    obj_clsGame.DATE = lblDate.Text;
                    if (_IsEdit)
                    {
                        obj_clsGame.ACTION = 1;
                        obj_clsGame.SaveData();
                        MessageBox.Show("Successfully Edited", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        obj_clsGame.ACTION = 0;
                        obj_clsGame.SaveData();
                        MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }
    }
}
