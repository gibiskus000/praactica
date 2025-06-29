using System.Windows.Forms;

namespace laba5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            buttonStart = new Button();
            buttonStop = new Button();
            buttonSettings = new Button();
            checkBoxTraectory = new CheckBox();
            comboBoxCountBody = new ComboBox();
            labelCountBody = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(461, 38);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(95, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Старт";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            buttonStart.MouseEnter += buttonStart_MouseEnter;
            buttonStart.MouseLeave += buttonStart_MouseLeave;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(562, 38);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(95, 23);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "Стоп";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            buttonStop.MouseEnter += buttonStop_MouseEnter;
            buttonStop.MouseLeave += buttonStop_MouseLeave;
            // 
            // buttonSettings
            // 
            buttonSettings.Location = new Point(663, 38);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(95, 23);
            buttonSettings.TabIndex = 2;
            buttonSettings.Text = "Настройки";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            buttonSettings.MouseEnter += buttonSettings_MouseEnter;
            buttonSettings.MouseLeave += buttonSettings_MouseLeave;
            // 
            // checkBoxTraectory
            // 
            checkBoxTraectory.AutoSize = true;
            checkBoxTraectory.Location = new Point(280, 42);
            checkBoxTraectory.Name = "checkBoxTraectory";
            checkBoxTraectory.Size = new Size(146, 19);
            checkBoxTraectory.TabIndex = 3;
            checkBoxTraectory.Text = "Траектория движения";
            checkBoxTraectory.UseVisualStyleBackColor = true;
            checkBoxTraectory.CheckedChanged += checkBoxTraectory_CheckedChanged;
            // 
            // comboBoxCountBody
            // 
            comboBoxCountBody.FormattingEnabled = true;
            comboBoxCountBody.Items.AddRange(new object[] { 3, 4, 5, 6, 7, 8, 9, 10 });
            comboBoxCountBody.SelectedItem = 3;
            comboBoxCountBody.Location = new Point(140, 40);
            comboBoxCountBody.Name = "comboBoxCountBody";
            comboBoxCountBody.Size = new Size(47, 23);
            comboBoxCountBody.TabIndex = 4;
            comboBoxCountBody.SelectedIndexChanged += comboBoxCountBody_Change;
            // 
            // labelCountBody
            // 
            labelCountBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCountBody.AutoSize = true;
            labelCountBody.Location = new Point(37, 43);
            labelCountBody.Name = "labelCountBody";
            labelCountBody.Size = new Size(87, 15);
            labelCountBody.TabIndex = 5;
            labelCountBody.Text = "Кол-во планет";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Desktop;
            panel1.Location = new Point(12, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 347);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(labelCountBody);
            Controls.Add(comboBoxCountBody);
            Controls.Add(checkBoxTraectory);
            Controls.Add(buttonSettings);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Движение планет";
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private Button buttonStart;
        private Button buttonStop;
        private Button buttonSettings;
        private CheckBox checkBoxTraectory;
        private ComboBox comboBoxCountBody;
        private Label labelCountBody;
        private Panel panel1;
    }
}
