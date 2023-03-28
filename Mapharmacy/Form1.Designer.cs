namespace Mapharmacy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.BardeProgression = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.Pourcentagelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BardeProgression.SuspendLayout();
            this.SuspendLayout();
            // 
            // BardeProgression
            // 
            this.BardeProgression.Controls.Add(this.Pourcentagelbl);
            this.BardeProgression.FillColor = System.Drawing.Color.Crimson;
            this.BardeProgression.FillOffset = 20;
            this.BardeProgression.FillThickness = 10;
            this.BardeProgression.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BardeProgression.ForeColor = System.Drawing.Color.Transparent;
            this.BardeProgression.ImageSize = new System.Drawing.Size(52, 52);
            this.BardeProgression.Location = new System.Drawing.Point(279, 67);
            this.BardeProgression.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.BardeProgression.Minimum = 0;
            this.BardeProgression.Name = "BardeProgression";
            this.BardeProgression.ProgressColor = System.Drawing.Color.White;
            this.BardeProgression.ProgressColor2 = System.Drawing.Color.White;
            this.BardeProgression.ProgressOffset = 20;
            this.BardeProgression.ProgressThickness = 10;
            this.BardeProgression.ShadowDecoration.CustomizableEdges = customizableEdges1;
            this.BardeProgression.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.BardeProgression.Size = new System.Drawing.Size(132, 132);
            this.BardeProgression.TabIndex = 0;
            this.BardeProgression.Text = "guna2CircleProgressBar1";
            this.BardeProgression.ValueChanged += new System.EventHandler(this.guna2CircleProgressBar1_ValueChanged);
            // 
            // Pourcentagelbl
            // 
            this.Pourcentagelbl.AutoSize = true;
            this.Pourcentagelbl.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Pourcentagelbl.Location = new System.Drawing.Point(36, 39);
            this.Pourcentagelbl.Name = "Pourcentagelbl";
            this.Pourcentagelbl.Size = new System.Drawing.Size(51, 44);
            this.Pourcentagelbl.TabIndex = 3;
            this.Pourcentagelbl.Text = "%";
            this.Pourcentagelbl.Click += new System.EventHandler(this.Pourcentagelbl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(156, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "La pharmacie d\'ingetis\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(216, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Developpe par H.Ahmed\r\n";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(696, 274);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BardeProgression);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Pharmacie du coin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BardeProgression.ResumeLayout(false);
            this.BardeProgression.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar BardeProgression;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private Label Pourcentagelbl;
    }
}