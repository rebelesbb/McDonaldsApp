using McApp.domain.validators;
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
    public partial class AddWindow : Form
    {
        private McService service;
        private int locationId;
        public AddWindow()
        {
            InitializeComponent();
        }

        public void SetService(McService service, int locationId)
        {
            this.service = service;
            this.locationId = locationId;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!LastNameTextBox.Text.IsNullOrEmpty() && !FirstNameTextBox.Text.IsNullOrEmpty() &&
                !PhoneNumberTextBox.Text.IsNullOrEmpty() && PositionComboBox.SelectedItem != null &&
                !SalaryTextBox.Text.IsNullOrEmpty())
            {
                try
                {
                    service.AddEmployee(LastNameTextBox.Text, FirstNameTextBox.Text, locationId,
                        PhoneNumberTextBox.Text, PositionComboBox.Text, int.Parse(SalaryTextBox.Text), HireDatePicker.Value);
                    this.Close();
                }
                catch(ValidationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
            }
        }

    }
}
