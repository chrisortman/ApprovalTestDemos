﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.invoiceUserControl1 = new MsTestProject.Lib.InvoiceUserControl();
            this.SuspendLayout();
            // 
            // invoiceUserControl1
            // 
            this.invoiceUserControl1.Location = new System.Drawing.Point(12, 12);
            this.invoiceUserControl1.Name = "invoiceUserControl1";
            this.invoiceUserControl1.Size = new System.Drawing.Size(523, 392);
            this.invoiceUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 574);
            this.Controls.Add(this.invoiceUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MsTestProject.Lib.InvoiceUserControl invoiceUserControl1;

    }
}

