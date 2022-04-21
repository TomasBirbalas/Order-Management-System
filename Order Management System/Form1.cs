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
using System.IO;

namespace Order_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SerializeData serializeData = new SerializeData();
            serializeData.GenerateJsonFile();
        }

        private void generatePendingPaymentReport_Click(object sender, EventArgs e)
        {
            GenerateCustomersReport clients = new GenerateCustomersReport();
            GenerateAllCustomersReport allCustomers = new GenerateAllCustomersReport();

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "html files (*.html)|*.html";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Can use dialog.FileName
                    string fileName = dialog.FileName;
                    clients.GenerateAllPendingPaymentOrders(fileName);
                    MessageBox.Show("Report is generated!!!");
                }
            }
        }

        private void generateAllCustomersReport_Click(object sender, EventArgs e)
        {
            GenerateAllCustomersReport allCustomers = new GenerateAllCustomersReport();

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "html files (*.html)|*.html";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Can use dialog.FileName
                    string fileName = dialog.FileName;
                    allCustomers.GenerateAllOrdersOfCustomerReport(fileName);
                    MessageBox.Show("Report is generated!!!");
                }
            }
        }
    }
}
