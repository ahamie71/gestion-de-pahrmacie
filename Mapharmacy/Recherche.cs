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

    public partial class Recherche : Form
    {

        public Recherche()
        {
            InitializeComponent();


            Con.Open();


            SqlCommand cmd = new SqlCommand("select  FabNum from FabricantTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("FabNum", typeof(string));
            dt.Load(Rdr);
            FabCb.ValueMember = "FabNum";
            FabCb.DataSource = dt;
            Con.Close();




        }



        private void Recherche_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MedsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");



        private void Reinitialiser()
        {
            NomTb.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)
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
                    string Req = " select * from MedicamentTbl Where  MedNom ='" + NomTb.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    MedsDGV.DataSource = ds.Tables[0];
                    Con.Close();
                    MedsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

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




        private void MedsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            NomTb.Text = MedsDGV.SelectedRows[0].Cells[1].Value.ToString();


        }

        private void FabCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            if (FabCb.SelectedIndex == -1)
            {
                MessageBox.Show("veuillez remplir le champ ");
            }

            else
            {
                try
                {
                    Con.Open();
                    string Req = " select *  from MedicamentTbl where MedFab = '" + FabCb.SelectedValue.ToString() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    DGV2.DataSource = ds.Tables[0];
                    Con.Close();
                    DGV2.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

                    DGV2.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    DGV2.RowsDefaultCellStyle.SelectionBackColor = Color.Red;


                }

                catch
                    (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FabCb.Text = MedsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (petitPrix.Text == "" || grandPrix.Text == "")
            {
                MessageBox.Show("Completer les informations manquantes");
            }
            else
            {
                Con.Open();
                string Req = " select * from MedicamentTbl where MedPrix  between  "+petitPrix.Text+" and "+grandPrix.Text;
                SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                Data2.DataSource = ds.Tables[0];
                Con.Close();

                Data2.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

                Data2.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                Data2.RowsDefaultCellStyle.SelectionBackColor = Color.Red;
            }
        }
    }
}
        
    


