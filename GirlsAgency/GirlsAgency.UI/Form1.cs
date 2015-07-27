using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlsAgency.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_GirlsAgency_Data_GirlsAgencyContextDataSet.FullName' table. You can move, or remove it, as needed.
            this.fullNameTableAdapter.Fill(this._GirlsAgency_Data_GirlsAgencyContextDataSet.FullName);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tokens = comboBox1.Text.Split(' ');

            var firstName = tokens[0];
            var lastName = tokens[1];

            Console.WriteLine("KUR");
        }
    }
}
