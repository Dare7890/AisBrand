
namespace AddBrandDataUI
{
    partial class AddExcavationUserControl
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMonument = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.errValidating = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboMonument = new System.Windows.Forms.ComboBox();
            this.chkIsCopy = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Раскоп:";
            // 
            // lblMonument
            // 
            this.lblMonument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonument.AutoSize = true;
            this.lblMonument.Location = new System.Drawing.Point(13, 56);
            this.lblMonument.Name = "lblMonument";
            this.lblMonument.Size = new System.Drawing.Size(65, 15);
            this.lblMonument.TabIndex = 1;
            this.lblMonument.Text = "Памятник:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(81, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 23);
            this.txtName.TabIndex = 2;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // errValidating
            // 
            this.errValidating.ContainerControl = this;
            // 
            // cboMonument
            // 
            this.cboMonument.FormattingEnabled = true;
            this.cboMonument.Location = new System.Drawing.Point(81, 53);
            this.cboMonument.Name = "cboMonument";
            this.cboMonument.Size = new System.Drawing.Size(175, 23);
            this.cboMonument.TabIndex = 4;
            // 
            // chkIsCopy
            // 
            this.chkIsCopy.AutoSize = true;
            this.chkIsCopy.Location = new System.Drawing.Point(121, 92);
            this.chkIsCopy.Name = "chkIsCopy";
            this.chkIsCopy.Size = new System.Drawing.Size(135, 19);
            this.chkIsCopy.TabIndex = 5;
            this.chkIsCopy.Text = "Копировать данные";
            this.chkIsCopy.UseVisualStyleBackColor = true;
            // 
            // AddExcavationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIsCopy);
            this.Controls.Add(this.cboMonument);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblMonument);
            this.Controls.Add(this.lblName);
            this.Name = "AddExcavationUserControl";
            this.Size = new System.Drawing.Size(270, 126);
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMonument;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider errValidating;
        private System.Windows.Forms.ComboBox cboMonument;
        private System.Windows.Forms.CheckBox chkIsCopy;
    }
}
