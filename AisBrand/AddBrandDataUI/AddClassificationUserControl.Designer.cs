
namespace AddBrandDataUI
{
    partial class AddClassificationUserControl
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
            this.txtVariant = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblVariant = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.lblPicture = new System.Windows.Forms.Label();
            this.picPicture = new System.Windows.Forms.PictureBox();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.errValidating = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVariant
            // 
            this.txtVariant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVariant.Location = new System.Drawing.Point(88, 53);
            this.txtVariant.Name = "txtVariant";
            this.txtVariant.Size = new System.Drawing.Size(147, 23);
            this.txtVariant.TabIndex = 7;
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(88, 20);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(147, 23);
            this.txtType.TabIndex = 6;
            this.txtType.Validating += new System.ComponentModel.CancelEventHandler(this.txtType_Validating);
            // 
            // lblVariant
            // 
            this.lblVariant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariant.AutoSize = true;
            this.lblVariant.Location = new System.Drawing.Point(20, 56);
            this.lblVariant.Name = "lblVariant";
            this.lblVariant.Size = new System.Drawing.Size(55, 15);
            this.lblVariant.TabIndex = 5;
            this.lblVariant.Text = "Вариант:";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(20, 23);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(30, 15);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Тип:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(88, 82);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(147, 78);
            this.txtDescription.TabIndex = 9;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 85);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Описание:";
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(17, 214);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(68, 27);
            this.btnAddPicture.TabIndex = 10;
            this.btnAddPicture.Text = "Добавить";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // lblPicture
            // 
            this.lblPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(20, 180);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(56, 15);
            this.lblPicture.TabIndex = 11;
            this.lblPicture.Text = "Рисунок:";
            // 
            // picPicture
            // 
            this.picPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPicture.Location = new System.Drawing.Point(88, 170);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(147, 127);
            this.picPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPicture.TabIndex = 12;
            this.picPicture.TabStop = false;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(17, 247);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(68, 27);
            this.btnDeleteImage.TabIndex = 13;
            this.btnDeleteImage.Text = "Удалить";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // errValidating
            // 
            this.errValidating.ContainerControl = this;
            // 
            // AddClassificationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.picPicture);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtVariant);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblVariant);
            this.Controls.Add(this.lblType);
            this.Name = "AddClassificationUserControl";
            this.Size = new System.Drawing.Size(254, 321);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVariant;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblVariant;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.PictureBox picPicture;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.ErrorProvider errValidating;
    }
}
