namespace mpp_proiect_csharp
{
    partial class MainForm
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
            this.dataGridViewRides = new System.Windows.Forms.DataGridView();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.hourPicker = new System.Windows.Forms.NumericUpDown();
            this.minutesPicker = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddRide = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.textBoxClientPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxNoOfSeats = new System.Windows.Forms.TextBox();
            this.buttonBookReservation = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonCancelReservation = new System.Windows.Forms.Button();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesPicker)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRides
            // 
            this.dataGridViewRides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRides.Location = new System.Drawing.Point(47, 6);
            this.dataGridViewRides.Name = "dataGridViewRides";
            this.dataGridViewRides.RowTemplate.Height = 24;
            this.dataGridViewRides.Size = new System.Drawing.Size(529, 238);
            this.dataGridViewRides.TabIndex = 0;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(81, 282);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(100, 22);
            this.textBoxDestination.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destination";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 282);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Departure Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // hourPicker
            // 
            this.hourPicker.Location = new System.Drawing.Point(467, 282);
            this.hourPicker.Name = "hourPicker";
            this.hourPicker.Size = new System.Drawing.Size(56, 22);
            this.hourPicker.TabIndex = 5;
            // 
            // minutesPicker
            // 
            this.minutesPicker.Location = new System.Drawing.Point(529, 282);
            this.minutesPicker.Name = "minutesPicker";
            this.minutesPicker.Size = new System.Drawing.Size(47, 22);
            this.minutesPicker.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Departure time";
            // 
            // buttonAddRide
            // 
            this.buttonAddRide.Location = new System.Drawing.Point(278, 310);
            this.buttonAddRide.Name = "buttonAddRide";
            this.buttonAddRide.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRide.TabIndex = 8;
            this.buttonAddRide.Text = "Add ride";
            this.buttonAddRide.UseVisualStyleBackColor = true;
            this.buttonAddRide.Click += new System.EventHandler(this.buttonAddRide_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Client Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Client Phone Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "No. of seats";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(47, 383);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(153, 22);
            this.textBoxClientName.TabIndex = 12;
            // 
            // textBoxClientPhoneNumber
            // 
            this.textBoxClientPhoneNumber.Location = new System.Drawing.Point(241, 383);
            this.textBoxClientPhoneNumber.Name = "textBoxClientPhoneNumber";
            this.textBoxClientPhoneNumber.Size = new System.Drawing.Size(159, 22);
            this.textBoxClientPhoneNumber.TabIndex = 13;
            // 
            // textBoxNoOfSeats
            // 
            this.textBoxNoOfSeats.Location = new System.Drawing.Point(439, 383);
            this.textBoxNoOfSeats.Name = "textBoxNoOfSeats";
            this.textBoxNoOfSeats.Size = new System.Drawing.Size(100, 22);
            this.textBoxNoOfSeats.TabIndex = 14;
            // 
            // buttonBookReservation
            // 
            this.buttonBookReservation.Location = new System.Drawing.Point(250, 429);
            this.buttonBookReservation.Name = "buttonBookReservation";
            this.buttonBookReservation.Size = new System.Drawing.Size(131, 23);
            this.buttonBookReservation.TabIndex = 15;
            this.buttonBookReservation.Text = "Book reservation";
            this.buttonBookReservation.UseVisualStyleBackColor = true;
            this.buttonBookReservation.Click += new System.EventHandler(this.buttonBookReservation_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(501, 495);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 16;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 573);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewRides);
            this.tabPage1.Controls.Add(this.buttonLogOut);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonBookReservation);
            this.tabPage1.Controls.Add(this.textBoxDestination);
            this.tabPage1.Controls.Add(this.textBoxNoOfSeats);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBoxClientPhoneNumber);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.textBoxClientName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.hourPicker);
            this.tabPage1.Controls.Add(this.minutesPicker);
            this.tabPage1.Controls.Add(this.buttonAddRide);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(634, 544);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonCancelReservation);
            this.tabPage2.Controls.Add(this.dataGridViewReservations);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(634, 544);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // buttonCancelReservation
            // 
            this.buttonCancelReservation.Location = new System.Drawing.Point(239, 342);
            this.buttonCancelReservation.Name = "buttonCancelReservation";
            this.buttonCancelReservation.Size = new System.Drawing.Size(142, 23);
            this.buttonCancelReservation.TabIndex = 1;
            this.buttonCancelReservation.Text = "Cancel reservation";
            this.buttonCancelReservation.UseVisualStyleBackColor = true;
            this.buttonCancelReservation.Click += new System.EventHandler(this.buttonCancelReservation_Click);
            // 
            // dataGridViewReservations
            // 
            this.dataGridViewReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservations.Location = new System.Drawing.Point(30, 42);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.RowTemplate.Height = 24;
            this.dataGridViewReservations.Size = new System.Drawing.Size(572, 262);
            this.dataGridViewReservations.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 569);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesPicker)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRides;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown hourPicker;
        private System.Windows.Forms.NumericUpDown minutesPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddRide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.TextBox textBoxClientPhoneNumber;
        private System.Windows.Forms.TextBox textBoxNoOfSeats;
        private System.Windows.Forms.Button buttonBookReservation;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonCancelReservation;
        private System.Windows.Forms.DataGridView dataGridViewReservations;
    }
}

