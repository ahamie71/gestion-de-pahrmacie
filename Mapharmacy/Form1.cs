using System.Windows.Forms.Design.Behavior;

namespace Mapharmacy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                  timer1.Start();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // on declare une variable nommée point de depart de type int qui vaut zero 
        int pdd = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {    
            // on incremente notre point de depart 
            pdd += 1;
            // on appelle notre bar de progression qui a comme valeur pdd
            BardeProgression.Value = pdd;
            // on crrer une label nommée Pourcentage pour avoir la preogression du pourcentage %
            Pourcentagelbl.Text= pdd+ "%";
            // on verifie si barde progression arrive a 100%
            if (BardeProgression.Value == 100)
            {    // on remet la bar de prog a zero 
                BardeProgression.Value = 0;
                // on arrete notre timer avec la fonction stop() 
                timer1.Stop();
                // on affiche la fenetre de connexion, on cree une instance de classe connexion, puis on l'affiche avec la methode show(), puis on hide la fenetre de chargement avec la fonction hide();
                Connexion MyCon =new Connexion();
                MyCon.Show();
                this.Hide();
            }
        }

        private void Pourcentagelbl_Click(object sender, EventArgs e)
        {

        }
    }
}