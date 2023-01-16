
namespace AddBrandDataUI
{
    partial class AddBrandUserControl
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
            this.lblReliability = new System.Windows.Forms.Label();
            this.lblRelief = new System.Windows.Forms.Label();
            this.lblSafety = new System.Windows.Forms.Label();
            this.lblSprinkling = new System.Windows.Forms.Label();
            this.lblAdmixture = new System.Windows.Forms.Label();
            this.lblClay = new System.Windows.Forms.Label();
            this.cboAdmixture = new System.Windows.Forms.ComboBox();
            this.cboClay = new System.Windows.Forms.ComboBox();
            this.cboSprinkling = new System.Windows.Forms.ComboBox();
            this.cboReliability = new System.Windows.Forms.ComboBox();
            this.cboSafety = new System.Windows.Forms.ComboBox();
            this.cboRelief = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblReliability
            // 
            this.lblReliability.AutoSize = true;
            this.lblReliability.Location = new System.Drawing.Point(279, 10);
            this.lblReliability.Name = "lblReliability";
            this.lblReliability.Size = new System.Drawing.Size(47, 15);
            this.lblReliability.TabIndex = 25;
            this.lblReliability.Text = "Обжиг:";
            // 
            // lblRelief
            // 
            this.lblRelief.AutoSize = true;
            this.lblRelief.Location = new System.Drawing.Point(5, 51);
            this.lblRelief.Name = "lblRelief";
            this.lblRelief.Size = new System.Drawing.Size(66, 15);
            this.lblRelief.TabIndex = 24;
            this.lblRelief.Text = "Орнамент:";
            // 
            // lblSafety
            // 
            this.lblSafety.AutoSize = true;
            this.lblSafety.Location = new System.Drawing.Point(5, 84);
            this.lblSafety.Name = "lblSafety";
            this.lblSafety.Size = new System.Drawing.Size(36, 15);
            this.lblSafety.TabIndex = 23;
            this.lblSafety.Text = "ДОП:";
            // 
            // lblSprinkling
            // 
            this.lblSprinkling.AutoSize = true;
            this.lblSprinkling.Location = new System.Drawing.Point(279, 84);
            this.lblSprinkling.Name = "lblSprinkling";
            this.lblSprinkling.Size = new System.Drawing.Size(61, 15);
            this.lblSprinkling.TabIndex = 22;
            this.lblSprinkling.Text = "Примеси:";
            // 
            // lblAdmixture
            // 
            this.lblAdmixture.AutoSize = true;
            this.lblAdmixture.Location = new System.Drawing.Point(5, 12);
            this.lblAdmixture.Name = "lblAdmixture";
            this.lblAdmixture.Size = new System.Drawing.Size(30, 15);
            this.lblAdmixture.TabIndex = 21;
            this.lblAdmixture.Text = "Тип:";
            // 
            // lblClay
            // 
            this.lblClay.AutoSize = true;
            this.lblClay.Location = new System.Drawing.Point(279, 46);
            this.lblClay.Name = "lblClay";
            this.lblClay.Size = new System.Drawing.Size(43, 15);
            this.lblClay.TabIndex = 20;
            this.lblClay.Text = "Глина:";
            // 
            // cboAdmixture
            // 
            this.cboAdmixture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdmixture.FormattingEnabled = true;
            this.cboAdmixture.Items.AddRange(new object[] {
            "БВПР",
            "ПМП",
            "ПКП"});
            this.cboAdmixture.Location = new System.Drawing.Point(361, 81);
            this.cboAdmixture.Name = "cboAdmixture";
            this.cboAdmixture.Size = new System.Drawing.Size(153, 23);
            this.cboAdmixture.TabIndex = 32;
            // 
            // cboClay
            // 
            this.cboClay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClay.FormattingEnabled = true;
            this.cboClay.Items.AddRange(new object[] {
            "БГК",
            "КГК",
            "КСОЖ",
            "Другая"});
            this.cboClay.Location = new System.Drawing.Point(361, 48);
            this.cboClay.Name = "cboClay";
            this.cboClay.Size = new System.Drawing.Size(153, 23);
            this.cboClay.TabIndex = 33;
            // 
            // cboSprinkling
            // 
            this.cboSprinkling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSprinkling.FormattingEnabled = true;
            this.cboSprinkling.Location = new System.Drawing.Point(93, 12);
            this.cboSprinkling.Name = "cboSprinkling";
            this.cboSprinkling.Size = new System.Drawing.Size(152, 23);
            this.cboSprinkling.TabIndex = 34;
            // 
            // cboReliability
            // 
            this.cboReliability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReliability.FormattingEnabled = true;
            this.cboReliability.Items.AddRange(new object[] {
            "КОО",
            "КПОО"});
            this.cboReliability.Location = new System.Drawing.Point(361, 12);
            this.cboReliability.Name = "cboReliability";
            this.cboReliability.Size = new System.Drawing.Size(153, 23);
            this.cboReliability.TabIndex = 35;
            // 
            // cboSafety
            // 
            this.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSafety.FormattingEnabled = true;
            this.cboSafety.Items.AddRange(new object[] {
            "авып",
            "вапв",
            "ыыы"});
            this.cboSafety.Location = new System.Drawing.Point(93, 84);
            this.cboSafety.Name = "cboSafety";
            this.cboSafety.Size = new System.Drawing.Size(152, 23);
            this.cboSafety.TabIndex = 36;
            // 
            // cboRelief
            // 
            this.cboRelief.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelief.FormattingEnabled = true;
            this.cboRelief.Items.AddRange(new object[] {
            "dsf",
            "ssss",
            "a"});
            this.cboRelief.Location = new System.Drawing.Point(93, 46);
            this.cboRelief.Name = "cboRelief";
            this.cboRelief.Size = new System.Drawing.Size(152, 23);
            this.cboRelief.TabIndex = 37;
            // 
            // AddBrandUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboRelief);
            this.Controls.Add(this.cboSafety);
            this.Controls.Add(this.cboReliability);
            this.Controls.Add(this.cboSprinkling);
            this.Controls.Add(this.cboClay);
            this.Controls.Add(this.cboAdmixture);
            this.Controls.Add(this.lblReliability);
            this.Controls.Add(this.lblRelief);
            this.Controls.Add(this.lblSafety);
            this.Controls.Add(this.lblSprinkling);
            this.Controls.Add(this.lblAdmixture);
            this.Controls.Add(this.lblClay);
            this.Name = "AddBrandUserControl";
            this.Size = new System.Drawing.Size(530, 122);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReliability;
        private System.Windows.Forms.Label lblRelief;
        private System.Windows.Forms.Label lblSafety;
        private System.Windows.Forms.Label lblSprinkling;
        private System.Windows.Forms.Label lblAdmixture;
        private System.Windows.Forms.Label lblClay;
        private System.Windows.Forms.ComboBox cboAdmixture;
        private System.Windows.Forms.ComboBox cboClay;
        private System.Windows.Forms.ComboBox cboSprinkling;
        private System.Windows.Forms.ComboBox cboReliability;
        private System.Windows.Forms.ComboBox cboSafety;
        private System.Windows.Forms.ComboBox cboRelief;
    }
}
