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
    public partial class AfficheMed : Form
    {
        public string MedNu;
        public string nom;
        public string quantité;
        public string prix;
        public  string  date;
        public string fab;
       

        public AfficheMed(string MedN,string n, string q, string p, string d ,string f  )
         
        {
            nom = n;
            quantité = q;
            prix = p;
            date = d ;
            fab = f;
            MedNu=MedN;
            

            InitializeComponent();
            NomTb.Text = nom;
            QtTb.Text =  quantité;
            prixTb.Text = prix;
            ExpDate.Text = date;
            FabCb.Text= fab;
            
            
        }

        private void AfficheMed_Load(object sender, EventArgs e)
        {

        }
        int Cle = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        public object MedNum { get; }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
            if (NomTb.Text == "" || QtTb.Text == "" || prixTb.Text == "" || FabCb.Text == "-1")
            {
                MessageBox.Show("information manquante  ");
            }
            else
            {  
                try
                {
                  Con.Open();
                   String Req = "Update MedicamentTbl  set MedNom = '" + NomTb.Text + "',MedPrix =" + prixTb.Text + ", MedQte = " + QtTb.Text + ",MedFab= " + int.Parse(FabCb.Text) + ", MedExp= '" + ExpDate.Value.Date + "' where MedNum = " + MedNu + ";";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                   
                    Con.Close();
                   
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
    }
}
