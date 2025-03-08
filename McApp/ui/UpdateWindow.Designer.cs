namespace McApp.ui
{
    partial class UpdateWindow
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
            UpdateBttn = new Button();
            HireDatePicker = new DateTimePicker();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            SalaryTextBox = new TextBox();
            label9 = new Label();
            PhoneNumberTextBox = new TextBox();
            label8 = new Label();
            FirstNameTextBox = new TextBox();
            label7 = new Label();
            LastNameTextBox = new TextBox();
            PositionComboBox = new ComboBox();
            label1 = new Label();
            LocationTextBox = new TextBox();
            SuspendLayout();
            // 
            // UpdateBttn
            // 
            UpdateBttn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            UpdateBttn.Location = new Point(188, 461);
            UpdateBttn.Name = "UpdateBttn";
            UpdateBttn.Size = new Size(122, 40);
            UpdateBttn.TabIndex = 25;
            UpdateBttn.Text = "Actualizare";
            UpdateBttn.UseVisualStyleBackColor = true;
            UpdateBttn.Click += UpdateBttn_Click;
            // 
            // HireDatePicker
            // 
            HireDatePicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            HireDatePicker.Format = DateTimePickerFormat.Short;
            HireDatePicker.Location = new Point(138, 428);
            HireDatePicker.Name = "HireDatePicker";
            HireDatePicker.Size = new Size(219, 27);
            HireDatePicker.TabIndex = 24;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(144, 405);
            label12.Name = "label12";
            label12.Size = new Size(103, 20);
            label12.TabIndex = 23;
            label12.Text = "Data angajare";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(141, 348);
            label11.Name = "label11";
            label11.Size = new Size(54, 20);
            label11.TabIndex = 22;
            label11.Text = "Salariu";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(144, 283);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 20;
            label10.Text = "Functie";
            // 
            // SalaryTextBox
            // 
            SalaryTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SalaryTextBox.Location = new Point(141, 375);
            SalaryTextBox.Name = "SalaryTextBox";
            SalaryTextBox.Size = new Size(219, 27);
            SalaryTextBox.TabIndex = 19;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(144, 215);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 18;
            label9.Text = "Telefon";
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PhoneNumberTextBox.Location = new Point(141, 235);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(219, 27);
            PhoneNumberTextBox.TabIndex = 17;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(150, 99);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 16;
            label8.Text = "Prenume";
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FirstNameTextBox.Location = new Point(144, 119);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(219, 27);
            FirstNameTextBox.TabIndex = 15;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(150, 36);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 14;
            label7.Text = "Nume";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LastNameTextBox.Location = new Point(144, 59);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(219, 27);
            LastNameTextBox.TabIndex = 13;
            // 
            // PositionComboBox
            // 
            PositionComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PositionComboBox.FormattingEnabled = true;
            PositionComboBox.Items.AddRange(new object[] { "Casier", "Manager", "Bucatar" });
            PositionComboBox.Location = new Point(141, 306);
            PositionComboBox.Name = "PositionComboBox";
            PositionComboBox.Size = new Size(216, 28);
            PositionComboBox.TabIndex = 26;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(150, 156);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 28;
            label1.Text = "Locatie";
            // 
            // LocationTextBox
            // 
            LocationTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LocationTextBox.Location = new Point(144, 176);
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.Size = new Size(219, 27);
            LocationTextBox.TabIndex = 27;
            // 
            // UpdateWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 526);
            Controls.Add(label1);
            Controls.Add(LocationTextBox);
            Controls.Add(PositionComboBox);
            Controls.Add(UpdateBttn);
            Controls.Add(HireDatePicker);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(SalaryTextBox);
            Controls.Add(label9);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(label8);
            Controls.Add(FirstNameTextBox);
            Controls.Add(label7);
            Controls.Add(LastNameTextBox);
            Name = "UpdateWindow";
            Text = "UpdateWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button UpdateBttn;
        private DateTimePicker HireDatePicker;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox SalaryTextBox;
        private Label label9;
        private TextBox PhoneNumberTextBox;
        private Label label8;
        private TextBox FirstNameTextBox;
        private Label label7;
        private TextBox LastNameTextBox;
        private ComboBox PositionComboBox;
        private Label label1;
        private TextBox LocationTextBox;
    }
}