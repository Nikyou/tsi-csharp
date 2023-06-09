using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public ComplexList complexes = new ComplexList();
        public Form1()
        {
         //   InitializeComponent();
            complexes.Add(new Complex(1.25, 5.901));
            complexes.Add(new Complex(-0.13, 42));
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Complex c = new Complex(double.Parse(textBox1.Text) , double.Parse(textBox2.Text));
            complexes.Add(c);
            // When programmatically adding items to a collection,
            // update the components associated with this collection.
            ((CurrencyManager)BindingContext[complexes]).Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // The relationship between the Grid component and the collection
           dataGridView1.DataSource = complexes;
            // The relationship between Label text and the AType property of the collection.
        //    label6.DataBindings.Add(new Binding("Text", complexes, "AType"));
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(536, 586);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_2);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private DataGridView dataGridView1;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
