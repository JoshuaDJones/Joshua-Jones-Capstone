namespace Joshua_Jones_C969_Project
{
    partial class ReportForm
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
            if (disposing && (components != null))
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
            this.exitButton = new System.Windows.Forms.Button();
            this.typesByMonthButton = new System.Windows.Forms.Button();
            this.showCustomersButton = new System.Windows.Forms.Button();
            this.consultantScheduleButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(490, 511);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(188, 56);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // typesByMonthButton
            // 
            this.typesByMonthButton.BackColor = System.Drawing.Color.White;
            this.typesByMonthButton.Location = new System.Drawing.Point(12, 12);
            this.typesByMonthButton.Name = "typesByMonthButton";
            this.typesByMonthButton.Size = new System.Drawing.Size(188, 56);
            this.typesByMonthButton.TabIndex = 2;
            this.typesByMonthButton.Text = "Number of appointment types by month";
            this.typesByMonthButton.UseVisualStyleBackColor = false;
            this.typesByMonthButton.Click += new System.EventHandler(this.typesByMonthButton_Click);
            // 
            // showCustomersButton
            // 
            this.showCustomersButton.BackColor = System.Drawing.Color.White;
            this.showCustomersButton.Location = new System.Drawing.Point(490, 12);
            this.showCustomersButton.Name = "showCustomersButton";
            this.showCustomersButton.Size = new System.Drawing.Size(188, 56);
            this.showCustomersButton.TabIndex = 3;
            this.showCustomersButton.Text = "Show all Customers";
            this.showCustomersButton.UseVisualStyleBackColor = false;
            this.showCustomersButton.Click += new System.EventHandler(this.showCustomersButton_Click);
            // 
            // consultantScheduleButton
            // 
            this.consultantScheduleButton.BackColor = System.Drawing.Color.White;
            this.consultantScheduleButton.Location = new System.Drawing.Point(251, 12);
            this.consultantScheduleButton.Name = "consultantScheduleButton";
            this.consultantScheduleButton.Size = new System.Drawing.Size(188, 56);
            this.consultantScheduleButton.TabIndex = 4;
            this.consultantScheduleButton.Text = "Schedule for each consultant";
            this.consultantScheduleButton.UseVisualStyleBackColor = false;
            this.consultantScheduleButton.Click += new System.EventHandler(this.consultantScheduleButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(12, 83);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(666, 413);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(690, 579);
            this.Controls.Add(this.consultantScheduleButton);
            this.Controls.Add(this.showCustomersButton);
            this.Controls.Add(this.typesByMonthButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.outputTextBox);
            this.Name = "ReportForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button typesByMonthButton;
        private System.Windows.Forms.Button showCustomersButton;
        private System.Windows.Forms.Button consultantScheduleButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
    }
}