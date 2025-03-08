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
        private DataGridViewRow selectedRow;
        private int locationId;
        public UpdateWindow()
        {
            InitializeComponent();
        }
        public void SetService(McService service, DataGridViewRow dataGridViewRow, int locationId)
        {
            this.service = service;
            this.selectedRow = dataGridViewRow;
            this.locationId = locationId;
            InitView();
        }

        public void InitView()
        {
            FirstNameTextBox.Text = selectedRow.Cells["prenume"].Value.ToString();
            LastNameTextBox.Text = selectedRow.Cells["nume"].Value.ToString();
            LocationTextBox.Text = this.locationId.ToString();
            PhoneNumberTextBox.Text = selectedRow.Cells["numar_telefon"].Value.ToString();
            PositionComboBox.SelectedItem = selectedRow.Cells["functie"].Value.ToString();
            SalaryTextBox.Text = selectedRow.Cells["salariu"].Value.ToString();
            HireDatePicker.Value = DateTime.Parse(selectedRow.Cells["data_angajare"].Value.ToString()).Date;
        }

        public void UpdateBttn_Click(object sender, EventArgs e)
        {
            if (!LastNameTextBox.Text.IsNullOrEmpty() && !FirstNameTextBox.Text.IsNullOrEmpty() &&
                !LocationTextBox.Text.IsNullOrEmpty() &&
                !PhoneNumberTextBox.Text.IsNullOrEmpty() && !SalaryTextBox.Text.IsNullOrEmpty() &&
                PositionComboBox.SelectedItem != null)
            {
                try
                {
                    int employeeId = int.Parse(selectedRow.Cells["cod_angajat"].Value.ToString());

                    service.UpdateEmployee(employeeId, LastNameTextBox.Text, FirstNameTextBox.Text, int.Parse(LocationTextBox.Text),
                        PhoneNumberTextBox.Text, PositionComboBox.SelectedItem.ToString(), int.Parse(SalaryTextBox.Text), HireDatePicker.Value);
                    this.Close();
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
