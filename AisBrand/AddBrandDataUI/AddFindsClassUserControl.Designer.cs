
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
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Location = new System.Drawing.Point(106, 18);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(175, 23);
            this.txtClass.TabIndex = 4;
            // 
            // lblClass
            // 
            this.lblClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(22, 21);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(78, 15);
            this.lblClass.TabIndex = 3;
            this.lblClass.Text = "Тип находок:";
            // 
            // AddFindsClassUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblClass);
            this.Name = "AddFindsClassUserControl";
            this.Size = new System.Drawing.Size(299, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
    }
}
