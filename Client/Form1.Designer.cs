namespace Client;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private DateTimePicker dateTimePicker;
    private Button button;
    private Label label1;


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
        label1 = new Label();
        dateTimePicker = new DateTimePicker();
        button = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(117, 15);
        label1.TabIndex = 0;
        label1.Text = "Введите дату сводок";
        // 
        // dateTimePicker
        // 
        dateTimePicker.Format = DateTimePickerFormat.Short;
        dateTimePicker.Location = new Point(12, 27);
        dateTimePicker.Name = "dateTimePicker";
        dateTimePicker.Size = new Size(200, 23);
        dateTimePicker.TabIndex = 1;
        // 
        // button
        // 
        button.Location = new Point(12, 56);
        button.Name = "button";
        button.Size = new Size(100, 30);
        button.TabIndex = 2;
        button.Text = "Подтвердить";
        button.Click += Button_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(224, 95);
        Controls.Add(label1);
        Controls.Add(dateTimePicker);
        Controls.Add(button);
        Name = "MainForm";
        Text = "SVO";
        ResumeLayout(false);
        PerformLayout();
    }



    #endregion
}