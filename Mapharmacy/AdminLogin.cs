using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapharmacy
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pass.Text == "")
            {
                MessageBox.Show("entrer le mot de passe  admin  ");
            }
            else if(Pass.Text == "Admin")   
            {
                Agents Ag = new Agents();
                Ag.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Contacter l'admin");
            }
                
        }
    }
}
