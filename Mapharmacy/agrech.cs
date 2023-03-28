using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapharmacy
{
    public partial class agrech : Form
    {
        public agrech()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");
        private void agrech_Load(object sender, EventArgs e)
        {
           
        }

        private void Rechercher_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "")
            {
                MessageBox.Show("veuillez remplir le champ ");
            }

            else
            {
                try
                {
                    Con.Open();
                    string Req = " select * from AgentTbl Where  AgNom ='" + NomTb.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    MedsDGV.DataSource = ds.Tables[0];
                    Con.Close();

                    MedsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    MedsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.Red;

                }

                catch
                    (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void MedsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
