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

namespace Mapharmacy
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            Afficher();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || GenreCb.SelectedIndex == -1 || PassTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Completer les informations manquantes");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "insert into AgentTbl values ('" + NomTb.Text + "','" +DDNdate.Value.Date + "','" + TelTb.Text + "','" + GenreCb.SelectedItem.ToString() + "', '"+PassTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent ajouté avec succés");

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
        private void Reinitialiser()
        {
            NomTb.Text = "";
            TelTb.Text = "";
            PassTb.Text = "";
            GenreCb.SelectedIndex = -1;
           
           /* Cle = 0;*/

        }
        private void Afficher()
        {
            Con.Open();
            string Req = "select * from AgentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];
            Con.Close();

            AgentsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            AgentsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.Red;

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reinitialiser();
        }
        int Cle = 0;
        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DDNdate.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            TelTb.Text = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenreCb.SelectedItem = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PassTb.Text = AgentsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (NomTb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("Selectionner l'agent icament  à  surrpimer ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "delete  from AgentTbl where AgNum =" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent supprimé avec succés");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || GenreCb.SelectedIndex == -1 || PassTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("information manquante  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "Update AgentTbl  set AgNom = '" + NomTb.Text + "',AgDDN = '" + DDNdate.Value.Date + "', AgTel = '" + TelTb.Text + "',Agsex='" + GenreCb.SelectedItem.ToString() + "',AgPass= '" +PassTb.Text+ "'  where AgNum = " + Cle + " ";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent modifé avec succés");
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

        private void NomTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Connexion con = new Connexion();
            con.Show();
            this.Hide();    
        }

        private void label5_Click(object sender, EventArgs e)
        {
            agrech agents = new agrech();  
            agents.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            medarch med = new medarch();
            med.Show();
        }
    }
}
