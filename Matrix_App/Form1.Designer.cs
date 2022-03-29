namespace Matrix_App
{
    partial class MainForm
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
            this.Input1Check = new System.Windows.Forms.Label();
            this.Modes = new System.Windows.Forms.ComboBox();
            this.Input2Check = new System.Windows.Forms.Label();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.Caculate_btn = new System.Windows.Forms.Button();
            this.Input_1 = new System.Windows.Forms.TextBox();
            this.Input_2 = new System.Windows.Forms.TextBox();
            this.Ouput = new System.Windows.Forms.TextBox();
            this.Row1_tb = new System.Windows.Forms.TextBox();
            this.Col1_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Col2_tb = new System.Windows.Forms.TextBox();
            this.Row2_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Input1Check
            // 
            this.Input1Check.AutoSize = true;
            this.Input1Check.Location = new System.Drawing.Point(12, 415);
            this.Input1Check.Name = "Input1Check";
            this.Input1Check.Size = new System.Drawing.Size(54, 15);
            this.Input1Check.TabIndex = 1;
            this.Input1Check.Text = "No Input";
            // 
            // Modes
            // 
            this.Modes.FormattingEnabled = true;
            this.Modes.Items.AddRange(new object[] {
            "Subtraction",
            "Addition ",
            "Multiplication",
            "Determinant",
            "Inverse",
            "Transpose",
            "Eigenvalue",
            "Trace",
            "LU_Factor",
            "QR_Factor",
            "Rank",
            "Symmetric Matrix"});
            this.Modes.Location = new System.Drawing.Point(772, 12);
            this.Modes.Name = "Modes";
            this.Modes.Size = new System.Drawing.Size(100, 23);
            this.Modes.TabIndex = 4;
            this.Modes.Text = "Select ";
            this.Modes.SelectedIndexChanged += new System.EventHandler(this.Modes_SelectedIndexChanged);
            // 
            // Input2Check
            // 
            this.Input2Check.AutoSize = true;
            this.Input2Check.Location = new System.Drawing.Point(268, 415);
            this.Input2Check.Name = "Input2Check";
            this.Input2Check.Size = new System.Drawing.Size(54, 15);
            this.Input2Check.TabIndex = 5;
            this.Input2Check.Text = "No Input";
            // 
            // Clear_btn
            // 
            this.Clear_btn.Location = new System.Drawing.Point(730, 462);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(142, 35);
            this.Clear_btn.TabIndex = 7;
            this.Clear_btn.Text = "Clear!";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Caculate_btn
            // 
            this.Caculate_btn.Location = new System.Drawing.Point(576, 462);
            this.Caculate_btn.Name = "Caculate_btn";
            this.Caculate_btn.Size = new System.Drawing.Size(148, 35);
            this.Caculate_btn.TabIndex = 8;
            this.Caculate_btn.Text = "Caculate!";
            this.Caculate_btn.UseVisualStyleBackColor = true;
            this.Caculate_btn.Click += new System.EventHandler(this.Caculate_btn_Click_1);
            // 
            // Input_1
            // 
            this.Input_1.Location = new System.Drawing.Point(12, 12);
            this.Input_1.Multiline = true;
            this.Input_1.Name = "Input_1";
            this.Input_1.Size = new System.Drawing.Size(250, 400);
            this.Input_1.TabIndex = 16;
            this.Input_1.TextChanged += new System.EventHandler(this.Input_1_TextChanged);
            // 
            // Input_2
            // 
            this.Input_2.Location = new System.Drawing.Point(268, 12);
            this.Input_2.Multiline = true;
            this.Input_2.Name = "Input_2";
            this.Input_2.Size = new System.Drawing.Size(250, 400);
            this.Input_2.TabIndex = 17;
            this.Input_2.TextChanged += new System.EventHandler(this.Input_2_TextChanged);
            // 
            // Ouput
            // 
            this.Ouput.Location = new System.Drawing.Point(524, 12);
            this.Ouput.Multiline = true;
            this.Ouput.Name = "Ouput";
            this.Ouput.ReadOnly = true;
            this.Ouput.Size = new System.Drawing.Size(242, 400);
            this.Ouput.TabIndex = 18;
            this.Ouput.TextChanged += new System.EventHandler(this.Ouput_TextChanged);
            // 
            // Row1_tb
            // 
            this.Row1_tb.Location = new System.Drawing.Point(54, 474);
            this.Row1_tb.Name = "Row1_tb";
            this.Row1_tb.Size = new System.Drawing.Size(50, 23);
            this.Row1_tb.TabIndex = 19;
            // 
            // Col1_tb
            // 
            this.Col1_tb.Location = new System.Drawing.Point(161, 474);
            this.Col1_tb.Name = "Col1_tb";
            this.Col1_tb.Size = new System.Drawing.Size(50, 23);
            this.Col1_tb.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Row :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Col :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Col :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Row :";
            // 
            // Col2_tb
            // 
            this.Col2_tb.Location = new System.Drawing.Point(412, 474);
            this.Col2_tb.Name = "Col2_tb";
            this.Col2_tb.Size = new System.Drawing.Size(50, 23);
            this.Col2_tb.TabIndex = 24;
            // 
            // Row2_tb
            // 
            this.Row2_tb.Location = new System.Drawing.Point(310, 474);
            this.Row2_tb.Name = "Row2_tb";
            this.Row2_tb.Size = new System.Drawing.Size(50, 23);
            this.Row2_tb.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(884, 509);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Col2_tb);
            this.Controls.Add(this.Row2_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Col1_tb);
            this.Controls.Add(this.Row1_tb);
            this.Controls.Add(this.Ouput);
            this.Controls.Add(this.Input_2);
            this.Controls.Add(this.Input_1);
            this.Controls.Add(this.Caculate_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Input2Check);
            this.Controls.Add(this.Modes);
            this.Controls.Add(this.Input1Check);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Input1Check;
        private ComboBox Modes;
        private Label Input2Check;
        private Button Clear_btn;
        private Button Caculate_btn;
        private TextBox Input_1;
        private TextBox Input_2;
        private TextBox Ouput;
        private TextBox Row1_tb;
        private TextBox Col1_tb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Col2_tb;
        private TextBox Row2_tb;
    }
}