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
    public partial class frm_GameSet : Form
    {
        public frm_GameSet()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsGameSet obj_clsGameSet = new clsGameSet();
        DataTable DT = new DataTable();
        String SPString = "";
        public bool _IsEdit = false;
        public int _GameSetID = 0;

        private void frm_GameSet_Load(object sender, EventArgs e)
        {
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblDate.Text = Month + "/" + Day + "/" + Year;
            txtGameSetType.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGameSetType.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type GameSetType");
                txtGameSetType.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_GameSet N'{0}', N'{1}', N'{2}'", txtGameSetType.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _GameSetID != Convert.ToInt32(DT.Rows[0]["GameSetID"]))
                {
                    MessageBox.Show("This Game Set Type Already Exits");
                    txtGameSetType.Focus();
                    txtGameSetType.SelectAll();
                }
                else
                {
                    obj_clsGameSet.GAMESETID = _GameSetID;
                    obj_clsGameSet.GAMESETTYPE = txtGameSetType.Text;
                    obj_clsGameSet.DATE = lblDate.Text;

                    if (_IsEdit)
                    {
                        obj_clsGameSet.ACTION = 1;
                        obj_clsGameSet.SaveData();
                        MessageBox.Show("Successfully Edited", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        obj_clsGameSet.ACTION = 0;
                        obj_clsGameSet.SaveData();
                        MessageBox.Show("Successfully Saved", "Successfully", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }
    }
}
