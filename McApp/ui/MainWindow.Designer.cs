using System.ComponentModel;

namespace McApp.ui;

partial class MainWindow
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        locationsDataGridView = new DataGridView();
        employeesDataGridView = new DataGridView();
        AddBttn = new Button();
        DeleteBttn = new Button();
        UpdateBttn = new Button();
        ((ISupportInitialize)locationsDataGridView).BeginInit();
        ((ISupportInitialize)employeesDataGridView).BeginInit();
        SuspendLayout();
        // 
        // locationsDataGridView
        // 
        locationsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        locationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        locationsDataGridView.Location = new Point(29, 59);
        locationsDataGridView.MultiSelect = false;
        locationsDataGridView.Name = "locationsDataGridView";
        locationsDataGridView.RowHeadersWidth = 51;
        locationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        locationsDataGridView.Size = new Size(437, 476);
        locationsDataGridView.TabIndex = 0;
        locationsDataGridView.Text = "dataGridView1";
        // 
        // employeesDataGridView
        // 
        employeesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        employeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        employeesDataGridView.Location = new Point(490, 59);
        employeesDataGridView.MultiSelect = false;
        employeesDataGridView.Name = "employeesDataGridView";
        employeesDataGridView.RowHeadersWidth = 51;
        employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        employeesDataGridView.Size = new Size(441, 334);
        employeesDataGridView.TabIndex = 1;
        // 
        // AddBttn
        // 
        AddBttn.Anchor = AnchorStyles.Bottom;
        AddBttn.Location = new Point(490, 467);
        AddBttn.Name = "AddBttn";
        AddBttn.Size = new Size(127, 29);
        AddBttn.TabIndex = 2;
        AddBttn.Text = "Adaugare";
        AddBttn.UseVisualStyleBackColor = true;
        AddBttn.Click += AddBttn_Click;
        // 
        // DeleteBttn
        // 
        DeleteBttn.Anchor = AnchorStyles.Bottom;
        DeleteBttn.Location = new Point(650, 467);
        DeleteBttn.Name = "DeleteBttn";
        DeleteBttn.Size = new Size(127, 29);
        DeleteBttn.TabIndex = 3;
        DeleteBttn.Text = "Stergere";
        DeleteBttn.UseVisualStyleBackColor = true;
        DeleteBttn.Click += DeleteBttn_Click;
        // 
        // UpdateBttn
        // 
        UpdateBttn.Anchor = AnchorStyles.Bottom;
        UpdateBttn.Location = new Point(804, 467);
        UpdateBttn.Name = "UpdateBttn";
        UpdateBttn.Size = new Size(127, 29);
        UpdateBttn.TabIndex = 4;
        UpdateBttn.Text = "Actualizare";
        UpdateBttn.UseVisualStyleBackColor = true;
        UpdateBttn.Click += UpdateBttn_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(969, 569);
        Controls.Add(UpdateBttn);
        Controls.Add(DeleteBttn);
        Controls.Add(AddBttn);
        Controls.Add(employeesDataGridView);
        Controls.Add(locationsDataGridView);
        Name = "MainWindow";
        Text = "MainWindow";
        ((ISupportInitialize)locationsDataGridView).EndInit();
        ((ISupportInitialize)employeesDataGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView locationsDataGridView;

    #endregion

    private DataGridView employeesDataGridView;
    private Button AddBttn;
    private Button DeleteBttn;
    private Button UpdateBttn;
}