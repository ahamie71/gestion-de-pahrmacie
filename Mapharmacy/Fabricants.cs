using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// on ajoute le namespace qui est le fournisseur de données .net pour Sql Server 
using System.Data.SqlClient;

namespace Mapharmacy
{
    public partial class Fabricants : Form
    {
        // constructeur 
        public Fabricants()
        {
            InitializeComponent();
            Afficher();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        // on creer un objet de la classe sql connexion et on ecrit les proprpite de la connexion que l'on apelle connection string pour pointer la base de dd que l'on veut 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        public object AdrTb { get; private set; }
        // on creer une private void car elle va rien nous retourner , elle nous permettre d'effacer les textboxs
        private void Reinitialiser()
        {
            NomTb.Text = "";
            AdrTB.Text = "";
            DescTb.Text = "";
            TelTb.Text = "";
            Cle = 0;

        }
        // affficher les fabriquants dans notre daatgridview
        private void Afficher()
        {    // on ouvre la connection 
            Con.Open();
            string Req = "select * from FabricantTbl";
           // Le SqlDataAdapter  fonctionne comme un pont entre un DataSet et une source de données (Base de données SQL Server) pour récupérer des données. SqlDataAdapter est une classe qui représente un ensemble de commandes SQL et une connexion à une base de données. Il peut être utilisé pour remplir le DataSet et mettre à jour la source de données.
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder= new SqlCommandBuilder(sda);
            // on delcare un dataset qui va recuperer les données 
            var ds = new DataSet();

            sda.Fill(ds);
            // on va reuperer le donnes de data set pour les remplir dans notre datagridview
            FabricantsDGV.DataSource= ds.Tables[0];
            Con.Close();

            FabricantsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

            FabricantsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            FabricantsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.Red;






        }

        private void button1_Click_1(object sender, EventArgs e)

        {
            // on note les texte ox par ces noms) on verife si il sont vide on leur envoie un message box qui leur alerte de remplor ces infos 
            if (NomTb.Text == "" || AddTB.Text == "" || DescTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Completer les informations manquantes");
            }
            else
            {
              try
                {// c'est le code d'insertion a la base de données dans un try and catch 
                    // on ouvre la connexion avec la fonction open();
                    Con.Open();
                    // on declare la requete qui permet d'inserer les données dans la table 
                    String Req = "insert into FabricantTbl values ('"+NomTb.Text+ "','"+AddTB.Text+"','"+DescTb.Text+ "','"+TelTb.Text+"')";
                    // on creer une commande sql qu'on leur passe deux parametres le req et la connexion 
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    //on execute la requete 
                    cmd.ExecuteNonQuery();
                  // on leur  afficher un message si le fabricant a été bien ajouté  
                    MessageBox.Show("Fabricant ajouté avec succés");
                   
                    Con.Close();
                    Afficher();
                    Reinitialiser();
                }
                catch(Exception Ex) 
                {     
                     MessageBox.Show(Ex.Message);
                }
            }
        }
         // a chaque fois qu'on clique dans le formulaire sur reinitialiser on applique cette fonction
        private void button4_Click(object sender, EventArgs e)
        {
            Reinitialiser();
        }
        int Cle = 0;
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
      
        private void FabricantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            NomTb.Text = FabricantsDGV.SelectedRows[0].Cells[1].Value.ToString();
            AdrTB.Text = FabricantsDGV.SelectedRows[0].Cells[2].Value.ToString();
            DescTb.Text = FabricantsDGV.SelectedRows[0].Cells[3].Value.ToString();
            TelTb.Text = FabricantsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (NomTb.Text == "")
                Cle = 0;
            else 
                Cle= Convert.ToInt32( FabricantsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // on verifie si un fabricant a te selectionne on peut pas supprimer un fabricant sans le slectionner 
            if (Cle == 0) 
            {
                MessageBox.Show("Selectionner le fabriquant a surrpimer ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "delete  from FabricantTbl where FabNum ="+Cle+"";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant supprimé avec succés");
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
            if (NomTb.Text == "" || AdrTB.Text == "" || DescTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("information manquante  ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Req = "Update FabricantTbl  set FabNom = '" + NomTb.Text + "',FabAd = '" + AdrTB.Text + "', FabDescr = '" + DescTb.Text + "',FabTel='" + TelTb.Text + "' where FabNum = " + Cle + " ";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant modifé avec succés");
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

        private void label3_Click(object sender, EventArgs e)
        {
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();
        }
    }
    }
