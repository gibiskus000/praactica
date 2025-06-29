namespace laba5
{
    partial class Form2
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
            comboBox1 = new ComboBox();
            labelPlanets = new Label();
            buttonSave = new Button();
            buttonClose = new Button();
            textBoxMass = new TextBox();
            textBoxX = new TextBox();
            textBoxY = new TextBox();
            textBoxVX = new TextBox();
            textBoxVY = new TextBox();
            labelMass = new Label();
            labelX = new Label();
            labelY = new Label();
            labelVX = new Label();
            labelVY = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBoxPlanets_SelectedIndexChanged;
            // 
            // labelPlanets
            // 
            labelPlanets.AutoSize = true;
            labelPlanets.Location = new Point(45, 9);
            labelPlanets.Name = "labelPlanets";
            labelPlanets.Size = new Size(56, 15);
            labelPlanets.TabIndex = 1;
            labelPlanets.Text = "Планета:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(13, 273);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 62);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(13, 352);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(120, 62);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // textBoxMass
            // 
            textBoxMass.Location = new Point(167, 73);
            textBoxMass.Name = "textBoxMass";
            textBoxMass.Size = new Size(334, 23);
            textBoxMass.TabIndex = 4;
            textBoxMass.TextChanged += textMass_ChangeTextMass;
            // textBoxX
            // 
            textBoxX.Location = new Point(167, 145);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(334, 23);
            textBoxX.TabIndex = 5;
            textBoxX.TextChanged += textX_ChangeTextX;
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(167, 221);
            textBoxY.Name = "textBoxY";
            textBoxY.Size = new Size(334, 23);
            textBoxY.TabIndex = 6;
            textBoxY.TextChanged += textY_ChangeTextY;
            // 
            // textBoxVX
            // 
            textBoxVX.Location = new Point(167, 294);
            textBoxVX.Name = "textBoxVX";
            textBoxVX.Size = new Size(334, 23);
            textBoxVX.TabIndex = 7;
            textBoxVX.TextChanged += textVX_ChangeTextVX;
            // 
            // textBoxVY
            // 
            textBoxVY.Location = new Point(167, 373);
            textBoxVY.Name = "textBoxVY";
            textBoxVY.Size = new Size(334, 23);
            textBoxVY.TabIndex = 8;
            textBoxVY.TextChanged += textVY_ChangeTextVY;
            // 
            // labelMass
            // 
            labelMass.AutoSize = true;
            labelMass.Location = new Point(167, 55);
            labelMass.Name = "labelMass";
            labelMass.Size = new Size(42, 15);
            labelMass.TabIndex = 9;
            labelMass.Text = "Масса";
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(167, 127);
            labelX.Name = "labelX";
            labelX.Size = new Size(99, 15);
            labelX.TabIndex = 10;
            labelX.Text = "Координата по Х";
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new Point(167, 203);
            labelY.Name = "labelY";
            labelY.Size = new Size(99, 15);
            labelY.TabIndex = 11;
            labelY.Text = "Координата по Y";
            // 
            // labelVX
            // 
            labelVX.AutoSize = true;
            labelVX.Location = new Point(167, 273);
            labelVX.Name = "labelVX";
            labelVX.Size = new Size(86, 15);
            labelVX.TabIndex = 12;
            labelVX.Text = "Скорость по Х";
            // 
            // labelVY
            // 
            labelVY.AutoSize = true;
            labelVY.Location = new Point(167, 352);
            labelVY.Name = "labelVY";
            labelVY.Size = new Size(86, 15);
            labelVY.TabIndex = 13;
            labelVY.Text = "Скорость по Y";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 450);
            Controls.Add(labelVY);
            Controls.Add(labelVX);
            Controls.Add(labelY);
            Controls.Add(labelX);
            Controls.Add(labelMass);
            Controls.Add(textBoxVY);
            Controls.Add(textBoxVX);
            Controls.Add(textBoxY);
            Controls.Add(textBoxX);
            Controls.Add(textBoxMass);
            Controls.Add(buttonClose);
            Controls.Add(buttonSave);
            Controls.Add(labelPlanets);
            Controls.Add(comboBox1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label labelPlanets;
        private Button buttonSave;
        private Button buttonClose;
        private TextBox textBoxMass;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private TextBox textBoxVX;
        private TextBox textBoxVY;
        private Label labelMass;
        private Label labelX;
        private Label labelY;
        private Label labelVX;
        private Label labelVY;
    }
}