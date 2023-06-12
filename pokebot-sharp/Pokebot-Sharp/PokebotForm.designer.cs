
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
            this.SuspendLayout();
            // 
            // btn_MasterToggle
            // 
            this.btn_MasterToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MasterToggle.Location = new System.Drawing.Point(368, 258);
            this.btn_MasterToggle.Name = "btn_MasterToggle";
            this.btn_MasterToggle.Size = new System.Drawing.Size(100, 50);
            this.btn_MasterToggle.TabIndex = 0;
            this.btn_MasterToggle.Text = "Master Toggle";
            this.btn_MasterToggle.UseVisualStyleBackColor = true;
            this.btn_MasterToggle.Click += new System.EventHandler(this.btn_MasterToggle_Click);
            // 
            // textBox_TestOutput
            // 
            this.textBox_TestOutput.Location = new System.Drawing.Point(13, 13);
            this.textBox_TestOutput.Multiline = true;
            this.textBox_TestOutput.Name = "textBox_TestOutput";
            this.textBox_TestOutput.ReadOnly = true;
            this.textBox_TestOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_TestOutput.Size = new System.Drawing.Size(455, 239);
            this.textBox_TestOutput.TabIndex = 1;
            // 
            // PokebotForm
            // 
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.textBox_TestOutput);
            this.Controls.Add(this.btn_MasterToggle);
            this.Name = "PokebotForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btn_MasterToggle;
        private System.Windows.Forms.TextBox textBox_TestOutput;
    }
}

