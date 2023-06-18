
namespace Pokebot_Sharp.Common
{
    partial class PokebotForm
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
            this.btn_MasterToggle = new System.Windows.Forms.Button();
            this.textBox_TestOutput = new System.Windows.Forms.TextBox();
            this.btn_Screenshot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Starter = new System.Windows.Forms.Label();
            this.radio_Right = new System.Windows.Forms.RadioButton();
            this.radio_Middle = new System.Windows.Forms.RadioButton();
            this.radio_Left = new System.Windows.Forms.RadioButton();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.checkbox_AlwaysReport = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_MasterToggle
            // 
            this.btn_MasterToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MasterToggle.Location = new System.Drawing.Point(385, 420);
            this.btn_MasterToggle.Name = "btn_MasterToggle";
            this.btn_MasterToggle.Size = new System.Drawing.Size(100, 50);
            this.btn_MasterToggle.TabIndex = 0;
            this.btn_MasterToggle.Text = "Master Toggle";
            this.btn_MasterToggle.UseVisualStyleBackColor = true;
            this.btn_MasterToggle.Click += new System.EventHandler(this.btn_MasterToggle_Click);
            // 
            // textBox_TestOutput
            // 
            this.textBox_TestOutput.Location = new System.Drawing.Point(13, 12);
            this.textBox_TestOutput.Multiline = true;
            this.textBox_TestOutput.Name = "textBox_TestOutput";
            this.textBox_TestOutput.ReadOnly = true;
            this.textBox_TestOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_TestOutput.Size = new System.Drawing.Size(455, 239);
            this.textBox_TestOutput.TabIndex = 1;
            // 
            // btn_Screenshot
            // 
            this.btn_Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Screenshot.Location = new System.Drawing.Point(12, 420);
            this.btn_Screenshot.Name = "btn_Screenshot";
            this.btn_Screenshot.Size = new System.Drawing.Size(101, 50);
            this.btn_Screenshot.TabIndex = 2;
            this.btn_Screenshot.Text = "Screenshot!";
            this.btn_Screenshot.UseVisualStyleBackColor = true;
            this.btn_Screenshot.Click += new System.EventHandler(this.btn_Screenshot_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Starter);
            this.panel1.Controls.Add(this.radio_Right);
            this.panel1.Controls.Add(this.radio_Middle);
            this.panel1.Controls.Add(this.radio_Left);
            this.panel1.Location = new System.Drawing.Point(13, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 51);
            this.panel1.TabIndex = 3;
            // 
            // label_Starter
            // 
            this.label_Starter.AutoSize = true;
            this.label_Starter.Location = new System.Drawing.Point(41, 12);
            this.label_Starter.Name = "label_Starter";
            this.label_Starter.Size = new System.Drawing.Size(85, 13);
            this.label_Starter.TabIndex = 3;
            this.label_Starter.Text = "Starter Selection";
            this.label_Starter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radio_Right
            // 
            this.radio_Right.AutoSize = true;
            this.radio_Right.Location = new System.Drawing.Point(115, 28);
            this.radio_Right.Name = "radio_Right";
            this.radio_Right.Size = new System.Drawing.Size(50, 17);
            this.radio_Right.TabIndex = 2;
            this.radio_Right.Text = "Right";
            this.radio_Right.UseVisualStyleBackColor = true;
            this.radio_Right.CheckedChanged += new System.EventHandler(this.radio_Right_CheckedChanged);
            // 
            // radio_Middle
            // 
            this.radio_Middle.AutoSize = true;
            this.radio_Middle.Checked = true;
            this.radio_Middle.Location = new System.Drawing.Point(53, 28);
            this.radio_Middle.Name = "radio_Middle";
            this.radio_Middle.Size = new System.Drawing.Size(56, 17);
            this.radio_Middle.TabIndex = 1;
            this.radio_Middle.TabStop = true;
            this.radio_Middle.Text = "Middle";
            this.radio_Middle.UseVisualStyleBackColor = true;
            this.radio_Middle.CheckedChanged += new System.EventHandler(this.radio_Middle_CheckedChanged);
            // 
            // radio_Left
            // 
            this.radio_Left.AutoSize = true;
            this.radio_Left.Location = new System.Drawing.Point(4, 28);
            this.radio_Left.Name = "radio_Left";
            this.radio_Left.Size = new System.Drawing.Size(43, 17);
            this.radio_Left.TabIndex = 0;
            this.radio_Left.Text = "Left";
            this.radio_Left.UseVisualStyleBackColor = true;
            this.radio_Left.CheckedChanged += new System.EventHandler(this.radio_Left_CheckedChanged);
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Location = new System.Drawing.Point(192, 258);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Mode.TabIndex = 4;
            this.comboBox_Mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_Mode_SelectedIndexChanged);
            // 
            // checkbox_AlwaysReport
            // 
            this.checkbox_AlwaysReport.AutoSize = true;
            this.checkbox_AlwaysReport.Location = new System.Drawing.Point(104, 315);
            this.checkbox_AlwaysReport.Name = "checkbox_AlwaysReport";
            this.checkbox_AlwaysReport.Size = new System.Drawing.Size(94, 17);
            this.checkbox_AlwaysReport.TabIndex = 5;
            this.checkbox_AlwaysReport.Text = "Always Report";
            this.checkbox_AlwaysReport.UseVisualStyleBackColor = true;
            // 
            // PokebotForm
            // 
            this.ClientSize = new System.Drawing.Size(497, 482);
            this.Controls.Add(this.checkbox_AlwaysReport);
            this.Controls.Add(this.comboBox_Mode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Screenshot);
            this.Controls.Add(this.textBox_TestOutput);
            this.Controls.Add(this.btn_MasterToggle);
            this.Name = "PokebotForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btn_MasterToggle;
        private System.Windows.Forms.TextBox textBox_TestOutput;
        private System.Windows.Forms.Button btn_Screenshot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radio_Left;
        private System.Windows.Forms.RadioButton radio_Middle;
        private System.Windows.Forms.RadioButton radio_Right;
        private System.Windows.Forms.Label label_Starter;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.CheckBox checkbox_AlwaysReport;
    }
}

