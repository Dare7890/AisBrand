
namespace AddBrandDataUI
{
    partial class AddFindUserControl
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
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblVariant = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cboVariant = new System.Windows.Forms.ComboBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pctPhoto = new System.Windows.Forms.PictureBox();
            this.pctImage = new System.Windows.Forms.PictureBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtCollectorsNumber = new System.Windows.Forms.TextBox();
            this.txtAnalogy = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDating = new System.Windows.Forms.TextBox();
            this.txtFieldNumber = new System.Windows.Forms.TextBox();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.txtSquare = new System.Windows.Forms.TextBox();
            this.txtFormation = new System.Windows.Forms.TextBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblAnalogy = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDating = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblCollectorsNumber = new System.Windows.Forms.Label();
            this.lblFieldNumber = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblSquare = new System.Windows.Forms.Label();
            this.lblFormation = new System.Windows.Forms.Label();
            this.errValidating = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMenu.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMenu
            // 
            this.tlpMenu.AutoScroll = true;
            this.tlpMenu.ColumnCount = 1;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Controls.Add(this.pnlFind, 0, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMenu.Location = new System.Drawing.Point(0, 0);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 2;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tlpMenu.Size = new System.Drawing.Size(706, 439);
            this.tlpMenu.TabIndex = 0;
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblVariant);
            this.pnlFind.Controls.Add(this.lblType);
            this.pnlFind.Controls.Add(this.cboVariant);
            this.pnlFind.Controls.Add(this.cboType);
            this.pnlFind.Controls.Add(this.btnDeletePhoto);
            this.pnlFind.Controls.Add(this.btnAddPhoto);
            this.pnlFind.Controls.Add(this.btnDeleteImage);
            this.pnlFind.Controls.Add(this.btnAddImage);
            this.pnlFind.Controls.Add(this.pctPhoto);
            this.pnlFind.Controls.Add(this.pctImage);
            this.pnlFind.Controls.Add(this.txtNote);
            this.pnlFind.Controls.Add(this.txtCollectorsNumber);
            this.pnlFind.Controls.Add(this.txtAnalogy);
            this.pnlFind.Controls.Add(this.txtDescription);
            this.pnlFind.Controls.Add(this.txtDating);
            this.pnlFind.Controls.Add(this.txtFieldNumber);
            this.pnlFind.Controls.Add(this.txtDepth);
            this.pnlFind.Controls.Add(this.txtSquare);
            this.pnlFind.Controls.Add(this.txtFormation);
            this.pnlFind.Controls.Add(this.lblPhoto);
            this.pnlFind.Controls.Add(this.lblNote);
            this.pnlFind.Controls.Add(this.lblAnalogy);
            this.pnlFind.Controls.Add(this.lblDescription);
            this.pnlFind.Controls.Add(this.lblDating);
            this.pnlFind.Controls.Add(this.lblImage);
            this.pnlFind.Controls.Add(this.lblCollectorsNumber);
            this.pnlFind.Controls.Add(this.lblFieldNumber);
            this.pnlFind.Controls.Add(this.lblDepth);
            this.pnlFind.Controls.Add(this.lblSquare);
            this.pnlFind.Controls.Add(this.lblFormation);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFind.Location = new System.Drawing.Point(3, 3);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(700, 302);
            this.pnlFind.TabIndex = 0;
            // 
            // lblVariant
            // 
            this.lblVariant.AutoSize = true;
            this.lblVariant.Location = new System.Drawing.Point(310, 82);
            this.lblVariant.Name = "lblVariant";
            this.lblVariant.Size = new System.Drawing.Size(41, 15);
            this.lblVariant.TabIndex = 31;
            this.lblVariant.Text = "Часть/Тип:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(310, 18);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(48, 15);
            this.lblType.TabIndex = 30;
            this.lblType.Text = "Форма:";
            // 
            // cboVariant
            // 
            this.cboVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVariant.FormattingEnabled = true;
            this.cboVariant.Location = new System.Drawing.Point(310, 111);
            this.cboVariant.Name = "cboVariant";
            this.cboVariant.Size = new System.Drawing.Size(92, 23);
            this.cboVariant.TabIndex = 29;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(310, 46);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(92, 23);
            this.cboType.TabIndex = 28;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.Location = new System.Drawing.Point(220, 239);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePhoto.TabIndex = 27;
            this.btnDeletePhoto.Text = "Удалить";
            this.btnDeletePhoto.UseVisualStyleBackColor = true;
            this.btnDeletePhoto.Click += new System.EventHandler(this.btnDeletePhoto_Click);
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(220, 210);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnAddPhoto.TabIndex = 26;
            this.btnAddPhoto.Text = "Добавить";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(19, 239);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteImage.TabIndex = 25;
            this.btnDeleteImage.Text = "Удалить";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(19, 210);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 24;
            this.btnAddImage.Text = "Добавить";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // pctPhoto
            // 
            this.pctPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPhoto.Location = new System.Drawing.Point(310, 180);
            this.pctPhoto.Name = "pctPhoto";
            this.pctPhoto.Size = new System.Drawing.Size(100, 100);
            this.pctPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctPhoto.TabIndex = 23;
            this.pctPhoto.TabStop = false;
            // 
            // pctImage
            // 
            this.pctImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctImage.Location = new System.Drawing.Point(107, 180);
            this.pctImage.Name = "pctImage";
            this.pctImage.Size = new System.Drawing.Size(100, 100);
            this.pctImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctImage.TabIndex = 22;
            this.pctImage.TabStop = false;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(528, 205);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(153, 75);
            this.txtNote.TabIndex = 21;
            this.txtNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCollectorsNumber
            // 
            this.txtCollectorsNumber.Location = new System.Drawing.Point(142, 51);
            this.txtCollectorsNumber.Name = "txtCollectorsNumber";
            this.txtCollectorsNumber.Size = new System.Drawing.Size(153, 23);
            this.txtCollectorsNumber.TabIndex = 20;
            // 
            // txtAnalogy
            // 
            this.txtAnalogy.Location = new System.Drawing.Point(528, 15);
            this.txtAnalogy.Name = "txtAnalogy";
            this.txtAnalogy.Size = new System.Drawing.Size(153, 23);
            this.txtAnalogy.TabIndex = 19;
            this.txtAnalogy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnalogy_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(528, 119);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(153, 75);
            this.txtDescription.TabIndex = 18;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDating
            // 
            this.txtDating.Location = new System.Drawing.Point(528, 46);
            this.txtDating.Multiline = true;
            this.txtDating.Name = "txtDating";
            this.txtDating.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDating.Size = new System.Drawing.Size(153, 66);
            this.txtDating.TabIndex = 17;
            this.txtDating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDating.Validating += new System.ComponentModel.CancelEventHandler(this.txtDating_Validating);
            // 
            // txtFieldNumber
            // 
            this.txtFieldNumber.Location = new System.Drawing.Point(142, 19);
            this.txtFieldNumber.Name = "txtFieldNumber";
            this.txtFieldNumber.Size = new System.Drawing.Size(153, 23);
            this.txtFieldNumber.TabIndex = 15;
            this.txtFieldNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtFieldNumber_Validating);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(142, 142);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(153, 23);
            this.txtDepth.TabIndex = 14;
            this.txtDepth.Validating += new System.ComponentModel.CancelEventHandler(this.txtDepth_Validating);
            // 
            // txtSquare
            // 
            this.txtSquare.Location = new System.Drawing.Point(142, 111);
            this.txtSquare.Name = "txtSquare";
            this.txtSquare.Size = new System.Drawing.Size(153, 23);
            this.txtSquare.TabIndex = 13;
            this.txtSquare.Validating += new System.ComponentModel.CancelEventHandler(this.txtSquare_Validating);
            // 
            // txtFormation
            // 
            this.txtFormation.Location = new System.Drawing.Point(142, 82);
            this.txtFormation.Name = "txtFormation";
            this.txtFormation.Size = new System.Drawing.Size(153, 23);
            this.txtFormation.TabIndex = 12;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(222, 180);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(38, 15);
            this.lblPhoto.TabIndex = 11;
            this.lblPhoto.Text = "Фото:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(420, 208);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(81, 15);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "Примечание:";
            // 
            // lblAnalogy
            // 
            this.lblAnalogy.AutoSize = true;
            this.lblAnalogy.Location = new System.Drawing.Point(421, 18);
            this.lblAnalogy.Name = "lblAnalogy";
            this.lblAnalogy.Size = new System.Drawing.Size(75, 15);
            this.lblAnalogy.TabIndex = 9;
            this.lblAnalogy.Text = "Количество:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(420, 122);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Комплекс:";
            // 
            // lblDating
            // 
            this.lblDating.AutoSize = true;
            this.lblDating.Location = new System.Drawing.Point(421, 49);
            this.lblDating.Name = "lblDating";
            this.lblDating.Size = new System.Drawing.Size(68, 15);
            this.lblDating.TabIndex = 6;
            this.lblDating.Text = "Датировка:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(19, 180);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(56, 15);
            this.lblImage.TabIndex = 5;
            this.lblImage.Text = "Рисунок:";
            // 
            // lblCollectorsNumber
            // 
            this.lblCollectorsNumber.AutoSize = true;
            this.lblCollectorsNumber.Location = new System.Drawing.Point(19, 54);
            this.lblCollectorsNumber.Name = "lblCollectorsNumber";
            this.lblCollectorsNumber.Size = new System.Drawing.Size(117, 15);
            this.lblCollectorsNumber.TabIndex = 4;
            this.lblCollectorsNumber.Text = "Коллекционный №:";
            // 
            // lblFieldNumber
            // 
            this.lblFieldNumber.AutoSize = true;
            this.lblFieldNumber.Location = new System.Drawing.Point(19, 22);
            this.lblFieldNumber.Name = "lblFieldNumber";
            this.lblFieldNumber.Size = new System.Drawing.Size(75, 15);
            this.lblFieldNumber.TabIndex = 3;
            this.lblFieldNumber.Text = "Полевой №:";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(19, 145);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(53, 15);
            this.lblDepth.TabIndex = 2;
            this.lblDepth.Text = "Глубина";
            // 
            // lblSquare
            // 
            this.lblSquare.AutoSize = true;
            this.lblSquare.Location = new System.Drawing.Point(19, 114);
            this.lblSquare.Name = "lblSquare";
            this.lblSquare.Size = new System.Drawing.Size(53, 15);
            this.lblSquare.TabIndex = 1;
            this.lblSquare.Text = "Квадрат:";
            // 
            // lblFormation
            // 
            this.lblFormation.AutoSize = true;
            this.lblFormation.Location = new System.Drawing.Point(19, 82);
            this.lblFormation.Name = "lblFormation";
            this.lblFormation.Size = new System.Drawing.Size(43, 15);
            this.lblFormation.TabIndex = 0;
            this.lblFormation.Text = "Пласт:";
            // 
            // errValidating
            // 
            this.errValidating.ContainerControl = this;
            // 
            // AddFindUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMenu);
            this.Name = "AddFindUserControl";
            this.Size = new System.Drawing.Size(706, 439);
            this.tlpMenu.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidating)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.PictureBox pctImage;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtCollectorsNumber;
        private System.Windows.Forms.TextBox txtAnalogy;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFieldNumber;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.TextBox txtSquare;
        private System.Windows.Forms.TextBox txtFormation;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblAnalogy;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblCollectorsNumber;
        private System.Windows.Forms.Label lblFieldNumber;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblSquare;
        private System.Windows.Forms.Label lblFormation;
        private System.Windows.Forms.PictureBox pctPhoto;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnDeletePhoto;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.ErrorProvider errValidating;
        private System.Windows.Forms.Label lblVariant;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboVariant;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtDating;
        private System.Windows.Forms.Label lblDating;
    }
}
