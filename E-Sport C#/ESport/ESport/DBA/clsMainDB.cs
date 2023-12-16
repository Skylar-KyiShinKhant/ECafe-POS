using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ESport.DBA
{
    class clsMainDB
    {
        public SqlConnection con;
        DataSet DS = new DataSet();

        public void DataBaseCon()
        {
            try
            {
                con = new SqlConnection(ESport.Properties.Settings.Default.ESportCon);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In DataBaseCon");
            }
        }

        public DataTable SelectData(string SPString)
        {   
            DataTable DT = new DataTable();
            try
            {                
                DataBaseCon();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In SelectData");
            }
            return DT;

        }

        public void ToolStripTextBoxData(ref ToolStripTextBox tstToolStrip, String SPString, String FieldName)
        {
            DataTable DT = new DataTable();
            AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
            try
            {
                DataBaseCon();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    tstToolStrip.AutoCompleteCustomSource.Clear();
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        Source.Add(DT.Rows[i][FieldName].ToString());
                    }
                    tstToolStrip.AutoCompleteCustomSource = Source;
                    tstToolStrip.Text = "";
                    tstToolStrip.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In ToolStripTextBoxData");
            }
        }

        public void AddCombo(ref ComboBox cboCombo, String SPString, String Display, String Value)
        {
            DataTable DT = new DataTable();
            DataTable DTCombo = new DataTable();
            DataRow DR;

            DTCombo.Columns.Add(Display);
            DTCombo.Columns.Add(Value);
            DR = DTCombo.NewRow();
            DR[Display] = "---Select---";
            DR[Value] = 0;
            DTCombo.Rows.Add(DR);
            try
            {
                DataBaseCon();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    DR = DTCombo.NewRow();
                    DR[Display] = DT.Rows[i][Display];
                    DR[Value] = DT.Rows[i][Value];
                    DTCombo.Rows.Add(DR);
                }
                cboCombo.DisplayMember = Display;
                cboCombo.ValueMember = Value;
                cboCombo.DataSource = DTCombo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In AddCombo");
            }
            finally
            {
                con.Close();
            }

        }

    }
}
