
namespace AddBrandDataUI
{
    partial class AddNumberFieldForm
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
            this.components = new System.ComponentModel.Container();
            this.txtFieldNumber = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errValidating = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFieldNumber
            // 
            this.txtFieldNumber.Location = new System.Drawing.Point(12, 22);
            this.txtFieldNumber.Name = "txtFieldNumber";
            this.txtFieldNumber.Size = new System.Drawing.Size(187, 23);
            this.txtFieldNumber.TabIndex = 2;
            this.txtFieldNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtFieldNumber_Validating);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(205, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ОК";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errValidating
            // 
            this.errValidating.ContainerControl = this;
            // 
            // AddNumberFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 64);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFieldNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNumberFieldForm";
            this.Text = "Введите полевой №";
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFieldNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errValidating;
    }
}