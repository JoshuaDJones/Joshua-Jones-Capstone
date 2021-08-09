namespace Joshua_Jones_C969_Project
{
    partial class UserForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.allAppointmentsButton = new System.Windows.Forms.Button();
            this.appointmentByMonthButton = new System.Windows.Forms.Button();
            this.appointmentWeekButton = new System.Windows.Forms.Button();
            this.userFormLabel = new System.Windows.Forms.Label();
            this.userFormTitleLabel = new System.Windows.Forms.Label();
            this.appointmentSortedLabel = new System.Windows.Forms.Label();
            this.weekMonthLabel = new System.Windows.Forms.Label();
            this.openReportsButton = new System.Windows.Forms.Button();
            this.tableSortButton = new System.Windows.Forms.Button();
            this.rightArrowButton = new System.Windows.Forms.PictureBox();
            this.leftArrowButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrowButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.customerDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.customerDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerDataGridView.GridColor = System.Drawing.Color.Black;
            this.customerDataGridView.Location = new System.Drawing.Point(57, 47);
            this.customerDataGridView.Name = "customerDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.customerDataGridView.RowHeadersVisible = false;
            this.customerDataGridView.RowHeadersWidth = 51;
            this.customerDataGridView.RowTemplate.Height = 24;
            this.customerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView.Size = new System.Drawing.Size(818, 172);
            this.customerDataGridView.TabIndex = 0;
            this.customerDataGridView.TabStop = false;
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appointmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.appointmentDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.appointmentDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.appointmentDataGridView.GridColor = System.Drawing.Color.Black;
            this.appointmentDataGridView.Location = new System.Drawing.Point(57, 350);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appointmentDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.appointmentDataGridView.RowHeadersVisible = false;
            this.appointmentDataGridView.RowHeadersWidth = 51;
            this.appointmentDataGridView.RowTemplate.Height = 24;
            this.appointmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGridView.Size = new System.Drawing.Size(818, 172);
            this.appointmentDataGridView.TabIndex = 1;
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addCustomerButton.Location = new System.Drawing.Point(371, 225);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(164, 46);
            this.addCustomerButton.TabIndex = 2;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = false;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.updateCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateCustomerButton.Location = new System.Drawing.Point(541, 225);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(164, 46);
            this.updateCustomerButton.TabIndex = 3;
            this.updateCustomerButton.Text = "Update Customer";
            this.updateCustomerButton.UseVisualStyleBackColor = false;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.deleteCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteCustomerButton.Location = new System.Drawing.Point(711, 225);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(164, 46);
            this.deleteCustomerButton.TabIndex = 4;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = false;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Appointments";
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.deleteAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteAppointmentButton.Location = new System.Drawing.Point(711, 528);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(164, 46);
            this.deleteAppointmentButton.TabIndex = 9;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = false;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // updateAppointmentButton
            // 
            this.updateAppointmentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.updateAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateAppointmentButton.Location = new System.Drawing.Point(541, 528);
            this.updateAppointmentButton.Name = "updateAppointmentButton";
            this.updateAppointmentButton.Size = new System.Drawing.Size(164, 46);
            this.updateAppointmentButton.TabIndex = 8;
            this.updateAppointmentButton.Text = "Update Appointment";
            this.updateAppointmentButton.UseVisualStyleBackColor = false;
            this.updateAppointmentButton.Click += new System.EventHandler(this.updateAppointmentButton_Click);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAppointmentButton.Location = new System.Drawing.Point(371, 528);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(164, 46);
            this.addAppointmentButton.TabIndex = 7;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = false;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.allAppointmentsButton);
            this.panel1.Controls.Add(this.appointmentByMonthButton);
            this.panel1.Controls.Add(this.appointmentWeekButton);
            this.panel1.Controls.Add(this.userFormLabel);
            this.panel1.Controls.Add(this.userFormTitleLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(942, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 646);
            this.panel1.TabIndex = 13;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(52, 535);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(164, 59);
            this.exitButton.TabIndex = 33;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // allAppointmentsButton
            // 
            this.allAppointmentsButton.BackColor = System.Drawing.Color.White;
            this.allAppointmentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.allAppointmentsButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAppointmentsButton.Location = new System.Drawing.Point(52, 470);
            this.allAppointmentsButton.Name = "allAppointmentsButton";
            this.allAppointmentsButton.Size = new System.Drawing.Size(164, 59);
            this.allAppointmentsButton.TabIndex = 32;
            this.allAppointmentsButton.Text = "Show All Appointments";
            this.allAppointmentsButton.UseVisualStyleBackColor = false;
            this.allAppointmentsButton.Click += new System.EventHandler(this.allAppointmentsButton_Click);
            // 
            // appointmentByMonthButton
            // 
            this.appointmentByMonthButton.BackColor = System.Drawing.Color.White;
            this.appointmentByMonthButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.appointmentByMonthButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentByMonthButton.Location = new System.Drawing.Point(52, 405);
            this.appointmentByMonthButton.Name = "appointmentByMonthButton";
            this.appointmentByMonthButton.Size = new System.Drawing.Size(164, 59);
            this.appointmentByMonthButton.TabIndex = 31;
            this.appointmentByMonthButton.Text = "View Appointments By Month";
            this.appointmentByMonthButton.UseVisualStyleBackColor = false;
            this.appointmentByMonthButton.Click += new System.EventHandler(this.appointmentByMonthButton_Click);
            // 
            // appointmentWeekButton
            // 
            this.appointmentWeekButton.BackColor = System.Drawing.Color.White;
            this.appointmentWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.appointmentWeekButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentWeekButton.Location = new System.Drawing.Point(52, 340);
            this.appointmentWeekButton.Name = "appointmentWeekButton";
            this.appointmentWeekButton.Size = new System.Drawing.Size(164, 59);
            this.appointmentWeekButton.TabIndex = 15;
            this.appointmentWeekButton.Text = "View Appointments By Week";
            this.appointmentWeekButton.UseVisualStyleBackColor = false;
            this.appointmentWeekButton.Click += new System.EventHandler(this.appointmentWeekButton_Click);
            // 
            // userFormLabel
            // 
            this.userFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userFormLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.userFormLabel.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFormLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.userFormLabel.Location = new System.Drawing.Point(32, 299);
            this.userFormLabel.Name = "userFormLabel";
            this.userFormLabel.Size = new System.Drawing.Size(200, 38);
            this.userFormLabel.TabIndex = 30;
            this.userFormLabel.Text = "(user\'s username)";
            this.userFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userFormTitleLabel
            // 
            this.userFormTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userFormTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.userFormTitleLabel.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFormTitleLabel.ForeColor = System.Drawing.Color.White;
            this.userFormTitleLabel.Location = new System.Drawing.Point(32, 261);
            this.userFormTitleLabel.Name = "userFormTitleLabel";
            this.userFormTitleLabel.Size = new System.Drawing.Size(200, 38);
            this.userFormTitleLabel.TabIndex = 29;
            this.userFormTitleLabel.Text = "User:";
            this.userFormTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appointmentSortedLabel
            // 
            this.appointmentSortedLabel.AutoSize = true;
            this.appointmentSortedLabel.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentSortedLabel.Location = new System.Drawing.Point(224, 314);
            this.appointmentSortedLabel.Name = "appointmentSortedLabel";
            this.appointmentSortedLabel.Size = new System.Drawing.Size(0, 33);
            this.appointmentSortedLabel.TabIndex = 14;
            this.appointmentSortedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // weekMonthLabel
            // 
            this.weekMonthLabel.AutoSize = true;
            this.weekMonthLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekMonthLabel.Location = new System.Drawing.Point(402, 320);
            this.weekMonthLabel.Name = "weekMonthLabel";
            this.weekMonthLabel.Size = new System.Drawing.Size(52, 24);
            this.weekMonthLabel.TabIndex = 34;
            this.weekMonthLabel.Text = "label3";
            // 
            // openReportsButton
            // 
            this.openReportsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openReportsButton.Location = new System.Drawing.Point(57, 528);
            this.openReportsButton.Margin = new System.Windows.Forms.Padding(15);
            this.openReportsButton.Name = "openReportsButton";
            this.openReportsButton.Size = new System.Drawing.Size(200, 46);
            this.openReportsButton.TabIndex = 35;
            this.openReportsButton.Text = "Open Reports";
            this.openReportsButton.UseVisualStyleBackColor = false;
            this.openReportsButton.Click += new System.EventHandler(this.openReportsButton_Click);
            // 
            // tableSortButton
            // 
            this.tableSortButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableSortButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tableSortButton.Location = new System.Drawing.Point(57, 225);
            this.tableSortButton.Margin = new System.Windows.Forms.Padding(15);
            this.tableSortButton.Name = "tableSortButton";
            this.tableSortButton.Size = new System.Drawing.Size(200, 46);
            this.tableSortButton.TabIndex = 36;
            this.tableSortButton.Text = "Open Table Sort";
            this.tableSortButton.UseVisualStyleBackColor = false;
            this.tableSortButton.Click += new System.EventHandler(this.tableSortButton_Click);
            // 
            // rightArrowButton
            // 
            this.rightArrowButton.Image = global::Joshua_Jones_C969_Project.Properties.Resources.right_arrow;
            this.rightArrowButton.Location = new System.Drawing.Point(336, 299);
            this.rightArrowButton.Name = "rightArrowButton";
            this.rightArrowButton.Size = new System.Drawing.Size(60, 45);
            this.rightArrowButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightArrowButton.TabIndex = 32;
            this.rightArrowButton.TabStop = false;
            this.rightArrowButton.Click += new System.EventHandler(this.rightArrowButton_Click);
            // 
            // leftArrowButton
            // 
            this.leftArrowButton.Image = global::Joshua_Jones_C969_Project.Properties.Resources.left_arrow;
            this.leftArrowButton.Location = new System.Drawing.Point(265, 299);
            this.leftArrowButton.Name = "leftArrowButton";
            this.leftArrowButton.Size = new System.Drawing.Size(65, 45);
            this.leftArrowButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftArrowButton.TabIndex = 33;
            this.leftArrowButton.TabStop = false;
            this.leftArrowButton.Click += new System.EventHandler(this.leftArrowButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Joshua_Jones_C969_Project.Properties.Resources._172163;
            this.pictureBox1.Location = new System.Drawing.Point(14, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 646);
            this.Controls.Add(this.tableSortButton);
            this.Controls.Add(this.openReportsButton);
            this.Controls.Add(this.weekMonthLabel);
            this.Controls.Add(this.rightArrowButton);
            this.Controls.Add(this.leftArrowButton);
            this.Controls.Add(this.appointmentSortedLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.updateAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.appointmentDataGridView);
            this.Controls.Add(this.customerDataGridView);
            this.Name = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrowButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userFormLabel;
        private System.Windows.Forms.Label userFormTitleLabel;
        private System.Windows.Forms.Button appointmentByMonthButton;
        private System.Windows.Forms.Button appointmentWeekButton;
        private System.Windows.Forms.Label appointmentSortedLabel;
        private System.Windows.Forms.PictureBox rightArrowButton;
        private System.Windows.Forms.PictureBox leftArrowButton;
        private System.Windows.Forms.Label weekMonthLabel;
        private System.Windows.Forms.Button allAppointmentsButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button openReportsButton;
        private System.Windows.Forms.Button tableSortButton;
    }
}