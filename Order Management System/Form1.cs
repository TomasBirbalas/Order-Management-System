using System;
using Business;
using DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using JsonSerializeris;

namespace Order_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // SerializeData serializeData = new SerializeData();
            // serializeData.GenerateJsonFile();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            GenerateCustomersReport clients = new GenerateCustomersReport();
            string result = "";

            clients.GenerateAllPendingPaymentOrders();
            MessageBox.Show("Report is generated!!!");

            displayBlock.Text = result;
        }
    }
}
