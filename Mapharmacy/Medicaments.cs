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
using static Guna.UI2.Native.WinApi;
using static System.Net.Mime.MediaTypeNames;

namespace Mapharmacy
{
    public partial class Medicaments : Form
    {
        public Medicaments()
        {
            InitializeComponent();
            RemplirFab();
            Afficher();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void RemplirFab()
        {

            Con.Open();


            SqlCommand cmd = new SqlCommand("select FabNum from FabricantTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("FabNum", typeof(int));
            dt.Load(Rdr);
            FabCb.ValueMember = "FabNum";
            FabCb.DataSource = dt;
            Con.Close();
        }
        private void Reinitialiser()
        {
            NomTb.Text = "";
            prixTb.Text = "";
            QtTb.Text = "";
            

            Cle = 0;

        }
        private void Afficher()
        {
            Con.Open();
            string Req = "select * from MedicamentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedsDGV.DataSource = ds.Tables[0];
            Con.Close();
            
            

            MedsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            MedsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.Red;





        }
             
        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || prixTb.Text == "" || QtTb.Text == "" || FabCb.SelectedIndex == -1)
            {
                MessageBox.Show("Completer les informations manquantes");
            }
            else
            {
                String Req;
                try
                {
                    Con.Open();
                     Req = "insert into MedicamentTbl  values ('" + NomTb.Text + "'," + prixTb.Text + "," + QtTb.Text + "," + FabCb.SelectedValue.ToString() + ",'" + DateTime.ParseExact(ExpDate.Value.ToShortDateString(),"mm/dd/yyyy",null) + "')";
                  
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicament ajouté avec succés");
                    Con.Close();
                    Afficher();
                    Reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Medicaments_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Fabricants Fab = new Fabricants();
            Fab.Show();
            this.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Recherche rech = new Recherche();
            rech.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (NomTb.Text == "" || QtTb.Text == "" || prixTb.Text == "" || FabCb.SelectedIndex == -1)
            {
                MessageBox.Show("information manquante  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "Update MedicamentTbl  set MedNom = '" + NomTb.Text + "',MedPrix =" + prixTb.Text + ", MedQte = " + QtTb.Text + ",MedFab= " + FabCb.SelectedValue.ToString() + ", MedExp= '" +ExpDate.Value.Date+ "' where MedNum = " + Cle + ";" ;
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicament modifé avec succés");
                    Con.Close();
                    Afficher();
                    Reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reinitialiser();
        }
        int Cle = 0;
        private void MedsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string num = MedsDGV.SelectedRows[0].Cells[0].Value.ToString();
            NomTb.Text = MedsDGV.SelectedRows[0].Cells[1].Value.ToString();
            prixTb.Text = MedsDGV.SelectedRows[0].Cells[2].Value.ToString();
            QtTb.Text = MedsDGV.SelectedRows[0].Cells[3].Value.ToString();
            FabCb.Text = MedsDGV.SelectedRows[0].Cells[4].Value.ToString();
            ExpDate.Text = MedsDGV.SelectedRows[0].Cells[5].Value.ToString();
            AfficheMed am = new AfficheMed(num,NomTb.Text, QtTb.Text, prixTb.Text, ExpDate.Text, FabCb.SelectedValue.ToString()) ;
            am.Show();

            if (NomTb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(MedsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (Cle == 0)
                {
                    MessageBox.Show("Selectionner le Medicament  à  surrpimer ");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        String Req = "delete  from MedicamentTbl where MedNum =" + Cle + "";
                        SqlCommand cmd = new SqlCommand(Req, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicament supprimé avec succés");
                        Con.Close();
                        Afficher();
                        Reinitialiser();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Connexion cls= new Connexion();
            this.Close();
            cls.Show();
        }

        private void NomTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
