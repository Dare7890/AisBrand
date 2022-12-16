
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
            this.txtRelief = new System.Windows.Forms.TextBox();
            this.lblReliability = new System.Windows.Forms.Label();
            this.lblRelief = new System.Windows.Forms.Label();
            this.lblSafety = new System.Windows.Forms.Label();
            this.lblSprinkling = new System.Windows.Forms.Label();
            this.lblAdmixture = new System.Windows.Forms.Label();
            this.lblClay = new System.Windows.Forms.Label();
            this.cboAdmixture = new System.Windows.Forms.ComboBox();
            this.cboClay = new System.Windows.Forms.ComboBox();
            this.cboSprinkling = new System.Windows.Forms.ComboBox();
            this.txtSafety = new System.Windows.Forms.TextBox();
            this.cboReliability = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtRelief
            // 
            this.txtRelief.Location = new System.Drawing.Point(361, 43);
            this.txtRelief.Name = "txtRelief";
            this.txtRelief.Size = new System.Drawing.Size(153, 23);
            this.txtRelief.TabIndex = 29;
            // 
            // lblReliability
            // 
            this.lblReliability.AutoSize = true;
            this.lblReliability.Location = new System.Drawing.Point(262, 15);
            this.lblReliability.Name = "lblReliability";
            this.lblReliability.Size = new System.Drawing.Size(47, 15);
            this.lblReliability.TabIndex = 25;
            this.lblReliability.Text = "Обжиг:";
            // 
            // lblRelief
            // 
            this.lblRelief.AutoSize = true;
            this.lblRelief.Location = new System.Drawing.Point(261, 46);
            this.lblRelief.Name = "lblRelief";
            this.lblRelief.Size = new System.Drawing.Size(82, 15);
            this.lblRelief.TabIndex = 24;
            this.lblRelief.Text = "Рельефность:";
            // 
            // lblSafety
            // 
            this.lblSafety.AutoSize = true;
            this.lblSafety.Location = new System.Drawing.Point(261, 79);
            this.lblSafety.Name = "lblSafety";
            this.lblSafety.Size = new System.Drawing.Size(82, 15);
            this.lblSafety.TabIndex = 23;
            this.lblSafety.Text = "Сохранность:";
            // 
            // lblSprinkling
            // 
            this.lblSprinkling.AutoSize = true;
            this.lblSprinkling.Location = new System.Drawing.Point(14, 79);
            this.lblSprinkling.Name = "lblSprinkling";
            this.lblSprinkling.Size = new System.Drawing.Size(66, 15);
            this.lblSprinkling.TabIndex = 22;
            this.lblSprinkling.Text = "Подсыпка:";
            // 
            // lblAdmixture
            // 
            this.lblAdmixture.AutoSize = true;
            this.lblAdmixture.Location = new System.Drawing.Point(14, 46);
            this.lblAdmixture.Name = "lblAdmixture";
            this.lblAdmixture.Size = new System.Drawing.Size(61, 15);
            this.lblAdmixture.TabIndex = 21;
            this.lblAdmixture.Text = "Примеси:";
            // 
            // lblClay
            // 
            this.lblClay.AutoSize = true;
            this.lblClay.Location = new System.Drawing.Point(14, 15);
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
            "ПП",
            "ПД",
            "ПДиП",
            "БВПР"});
            this.cboAdmixture.Location = new System.Drawing.Point(86, 43);
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
            this.cboClay.Location = new System.Drawing.Point(86, 12);
            this.cboClay.Name = "cboClay";
            this.cboClay.Size = new System.Drawing.Size(153, 23);
            this.cboClay.TabIndex = 33;
            // 
            // cboSprinkling
            // 
            this.cboSprinkling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSprinkling.FormattingEnabled = true;
            this.cboSprinkling.Items.AddRange(new object[] {
            "ПМП",
            "ПКП",
            "ПЗ",
            "Заглажено"});
            this.cboSprinkling.Location = new System.Drawing.Point(87, 76);
            this.cboSprinkling.Name = "cboSprinkling";
            this.cboSprinkling.Size = new System.Drawing.Size(152, 23);
            this.cboSprinkling.TabIndex = 34;
            // 
            // txtSafety
            // 
            this.txtSafety.Location = new System.Drawing.Point(361, 76);
            this.txtSafety.Name = "txtSafety";
            this.txtSafety.Size = new System.Drawing.Size(153, 23);
            this.txtSafety.TabIndex = 30;
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
            // AddBrandUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboReliability);
            this.Controls.Add(this.cboSprinkling);
            this.Controls.Add(this.cboClay);
            this.Controls.Add(this.cboAdmixture);
            this.Controls.Add(this.txtSafety);
            this.Controls.Add(this.txtRelief);
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
        private System.Windows.Forms.TextBox txtRelief;
        private System.Windows.Forms.Label lblReliability;
        private System.Windows.Forms.Label lblRelief;
        private System.Windows.Forms.Label lblSafety;
        private System.Windows.Forms.Label lblSprinkling;
        private System.Windows.Forms.Label lblAdmixture;
        private System.Windows.Forms.Label lblClay;
        private System.Windows.Forms.ComboBox cboAdmixture;
        private System.Windows.Forms.ComboBox cboClay;
        private System.Windows.Forms.ComboBox cboSprinkling;
        private System.Windows.Forms.TextBox txtSafety;
        private System.Windows.Forms.ComboBox cboReliability;
    }
}
