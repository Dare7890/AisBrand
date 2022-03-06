
namespace AddBrandDataUI
{
    partial class AddFindsClassUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblClass = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.chkIsCopy = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblClass
            // 
            this.lblClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(13, 21);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(90, 15);
            this.lblClass.TabIndex = 3;
            this.lblClass.Text = "Класс находок:";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(109, 18);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(175, 23);
            this.cboClass.TabIndex = 5;
            // 
            // chkIsCopy
            // 
            this.chkIsCopy.AutoSize = true;
            this.chkIsCopy.Location = new System.Drawing.Point(149, 47);
            this.chkIsCopy.Name = "chkIsCopy";
            this.chkIsCopy.Size = new System.Drawing.Size(135, 19);
            this.chkIsCopy.TabIndex = 6;
            this.chkIsCopy.Text = "Копировать данные";
            this.chkIsCopy.UseVisualStyleBackColor = true;
            // 
            // AddFindsClassUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIsCopy);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.lblClass);
            this.Name = "AddFindsClassUserControl";
            this.Size = new System.Drawing.Size(299, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.CheckBox chkIsCopy;
    }
}
