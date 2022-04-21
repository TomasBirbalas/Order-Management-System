namespace Order_Management_System
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
            this.generatePendingPaymentReport = new System.Windows.Forms.Button();
            this.displayBlock = new System.Windows.Forms.TextBox();
            this.generateAllCustomersReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generatePendingPaymentReport
            // 
            this.generatePendingPaymentReport.Location = new System.Drawing.Point(54, 104);
            this.generatePendingPaymentReport.Name = "generatePendingPaymentReport";
            this.generatePendingPaymentReport.Size = new System.Drawing.Size(226, 47);
            this.generatePendingPaymentReport.TabIndex = 0;
            this.generatePendingPaymentReport.Text = "Generate report of pending payments";
            this.generatePendingPaymentReport.UseVisualStyleBackColor = true;
            this.generatePendingPaymentReport.Click += new System.EventHandler(this.generatePendingPaymentReport_Click);
            // 
            // displayBlock
            // 
            this.displayBlock.Location = new System.Drawing.Point(368, 104);
            this.displayBlock.Multiline = true;
            this.displayBlock.Name = "displayBlock";
            this.displayBlock.ReadOnly = true;
            this.displayBlock.Size = new System.Drawing.Size(264, 166);
            this.displayBlock.TabIndex = 1;
            // 
            // generateAllCustomersReport
            // 
            this.generateAllCustomersReport.Location = new System.Drawing.Point(54, 157);
            this.generateAllCustomersReport.Name = "generateAllCustomersReport";
            this.generateAllCustomersReport.Size = new System.Drawing.Size(226, 47);
            this.generateAllCustomersReport.TabIndex = 2;
            this.generateAllCustomersReport.Text = "Generate all customers report";
            this.generateAllCustomersReport.UseVisualStyleBackColor = true;
            this.generateAllCustomersReport.Click += new System.EventHandler(this.generateAllCustomersReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.generateAllCustomersReport);
            this.Controls.Add(this.displayBlock);
            this.Controls.Add(this.generatePendingPaymentReport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generatePendingPaymentReport;
        private System.Windows.Forms.TextBox displayBlock;
        private System.Windows.Forms.Button generateAllCustomersReport;
    }
}
