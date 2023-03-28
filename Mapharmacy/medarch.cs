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
    public partial class medarch : Form
    {
        public medarch()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahamie\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void Afiche()
        {
            Con.Open();
            string Req = "select * form Table";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedsDGV.DataSource = ds.Tables[0];
            Con.Close();



            MedsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            MedsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.Red;





        }

        private void MedsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MedsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
