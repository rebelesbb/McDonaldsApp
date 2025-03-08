using McApp.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McApp.ui
{
    public partial class UpdateWindow : Form
    {
        private McService service;
        private int employeeId;
        private DataSet dataSet;
        public UpdateWindow()
        {
            InitializeComponent();
        }
        public void SetService(McService service, DataSet dataSet, int employeeId)
        {
            this.service = service;
            this.dataSet = dataSet;
            this.employeeId = employeeId;
        }

        public void UpdateBttn_Click(object sender, EventArgs e)
        {
            if (!LastNameTextBox.Text.IsNullOrEmpty() && !FirstNameTextBox.Text.IsNullOrEmpty() &&
                !LocationTextBox.Text.IsNullOrEmpty() &&
                !PhoneNumberTextBox.Text.IsNullOrEmpty() && !SalaryTextBox.Text.IsNullOrEmpty() &&
                !PositionComboBox.SelectedItem.ToString().IsNullOrEmpty() && HireDatePicker.Value != null)
            {
                service.UpdateEmployee(dataSet, employeeId, LastNameTextBox.Text, FirstNameTextBox.Text, int.Parse(LocationTextBox.Text),
                    PhoneNumberTextBox.Text, PositionComboBox.SelectedItem.ToString(), int.Parse(SalaryTextBox.Text), HireDatePicker.Value);
                this.Close();
            }
        }
    }
}
