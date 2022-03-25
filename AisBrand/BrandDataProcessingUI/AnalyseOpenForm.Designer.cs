
namespace BrandDataProcessingUI
{
    partial class AnalyseOpenForm
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
            this.cboSublasses = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboSublasses
            // 
            this.cboSublasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSublasses.FormattingEnabled = true;
            this.cboSublasses.Location = new System.Drawing.Point(12, 12);
            this.cboSublasses.Name = "cboSublasses";
            this.cboSublasses.Size = new System.Drawing.Size(233, 23);
            this.cboSublasses.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(251, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "ОК";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // AnalyseOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 50);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboSublasses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnalyseOpenForm";
            this.Text = "Выберите подкатегорию";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSublasses;
        private System.Windows.Forms.Button btnOpen;
    }
}