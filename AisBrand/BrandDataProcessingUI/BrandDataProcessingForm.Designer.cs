
namespace BrandDataProcessingUI
{
    partial class BrandDataProcessingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpStructure = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControllers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCrudOperations = new System.Windows.Forms.Panel();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnDeleteExcavation = new System.Windows.Forms.Button();
            this.btnEditExcavation = new System.Windows.Forms.Button();
            this.btnAddExcavation = new System.Windows.Forms.Button();
            this.lblExcavation = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbProperties = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpStructure.SuspendLayout();
            this.tlpControllers.SuspendLayout();
            this.pnlCrudOperations.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpStructure
            // 
            this.tlpStructure.ColumnCount = 1;
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tlpStructure.Controls.Add(this.tlpControllers, 0, 1);
            this.tlpStructure.Controls.Add(this.dgvTable, 0, 2);
            this.tlpStructure.Controls.Add(this.mnsMenu, 0, 0);
            this.tlpStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStructure.Location = new System.Drawing.Point(0, 0);
            this.tlpStructure.Name = "tlpStructure";
            this.tlpStructure.RowCount = 3;
            this.tlpStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpStructure.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStructure.Size = new System.Drawing.Size(800, 450);
            this.tlpStructure.TabIndex = 0;
            // 
            // tlpControllers
            // 
            this.tlpControllers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpControllers.ColumnCount = 1;
            this.tlpControllers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControllers.Controls.Add(this.pnlCrudOperations, 0, 0);
            this.tlpControllers.Controls.Add(this.pnlFilter, 0, 1);
            this.tlpControllers.Location = new System.Drawing.Point(3, 23);
            this.tlpControllers.Name = "tlpControllers";
            this.tlpControllers.RowCount = 2;
            this.tlpControllers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpControllers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpControllers.Size = new System.Drawing.Size(794, 74);
            this.tlpControllers.TabIndex = 0;
            // 
            // pnlCrudOperations
            // 
            this.pnlCrudOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrudOperations.Controls.Add(this.btnMove);
            this.pnlCrudOperations.Controls.Add(this.btnDeleteExcavation);
            this.pnlCrudOperations.Controls.Add(this.btnEditExcavation);
            this.pnlCrudOperations.Controls.Add(this.btnAddExcavation);
            this.pnlCrudOperations.Controls.Add(this.lblExcavation);
            this.pnlCrudOperations.Location = new System.Drawing.Point(3, 3);
            this.pnlCrudOperations.Name = "pnlCrudOperations";
            this.pnlCrudOperations.Size = new System.Drawing.Size(788, 29);
            this.pnlCrudOperations.TabIndex = 0;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(679, 4);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(103, 22);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "Классификация";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnDeleteExcavation
            // 
            this.btnDeleteExcavation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteExcavation.Enabled = false;
            this.btnDeleteExcavation.Location = new System.Drawing.Point(293, 4);
            this.btnDeleteExcavation.Name = "btnDeleteExcavation";
            this.btnDeleteExcavation.Size = new System.Drawing.Size(103, 22);
            this.btnDeleteExcavation.TabIndex = 3;
            this.btnDeleteExcavation.Text = "Удалить";
            this.btnDeleteExcavation.UseVisualStyleBackColor = true;
            // 
            // btnEditExcavation
            // 
            this.btnEditExcavation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditExcavation.Enabled = false;
            this.btnEditExcavation.Location = new System.Drawing.Point(184, 4);
            this.btnEditExcavation.Name = "btnEditExcavation";
            this.btnEditExcavation.Size = new System.Drawing.Size(103, 22);
            this.btnEditExcavation.TabIndex = 2;
            this.btnEditExcavation.Text = "Редактировать";
            this.btnEditExcavation.UseVisualStyleBackColor = true;
            // 
            // btnAddExcavation
            // 
            this.btnAddExcavation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddExcavation.Location = new System.Drawing.Point(75, 4);
            this.btnAddExcavation.Name = "btnAddExcavation";
            this.btnAddExcavation.Size = new System.Drawing.Size(103, 22);
            this.btnAddExcavation.TabIndex = 1;
            this.btnAddExcavation.Text = "Добавить";
            this.btnAddExcavation.UseVisualStyleBackColor = true;
            // 
            // lblExcavation
            // 
            this.lblExcavation.AutoSize = true;
            this.lblExcavation.Location = new System.Drawing.Point(15, 8);
            this.lblExcavation.Name = "lblExcavation";
            this.lblExcavation.Size = new System.Drawing.Size(58, 15);
            this.lblExcavation.TabIndex = 0;
            this.lblExcavation.Text = "Раскопы:";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.cmbProperties);
            this.pnlFilter.Controls.Add(this.btnApply);
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.txtValue);
            this.pnlFilter.Location = new System.Drawing.Point(3, 38);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(788, 33);
            this.pnlFilter.TabIndex = 1;
            // 
            // cmbProperties
            // 
            this.cmbProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperties.FormattingEnabled = true;
            this.cmbProperties.Location = new System.Drawing.Point(75, 6);
            this.cmbProperties.Name = "cmbProperties";
            this.cmbProperties.Size = new System.Drawing.Size(103, 23);
            this.cmbProperties.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(679, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(103, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Искать";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(15, 10);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(45, 15);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Поиск:";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(184, 6);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(489, 23);
            this.txtValue.TabIndex = 0;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToResizeColumns = false;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(3, 103);
            this.dgvTable.Name = "dgvTable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.RowTemplate.Height = 25;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(794, 364);
            this.dgvTable.TabIndex = 1;
            // 
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 20);
            this.mnsMenu.TabIndex = 2;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsOpenFile,
            this.toolStripSeparator1,
            this.mnsClose});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 16);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mnsOpenFile
            // 
            this.mnsOpenFile.Name = "mnsOpenFile";
            this.mnsOpenFile.Size = new System.Drawing.Size(121, 22);
            this.mnsOpenFile.Text = "Открыть";
            this.mnsOpenFile.Click += new System.EventHandler(this.mnsOpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // mnsClose
            // 
            this.mnsClose.Name = "mnsClose";
            this.mnsClose.Size = new System.Drawing.Size(121, 22);
            this.mnsClose.Text = "Выход";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 16);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // BrandDataProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpStructure);
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "BrandDataProcessingForm";
            this.Text = "Brand Data Processing";
            this.tlpStructure.ResumeLayout(false);
            this.tlpStructure.PerformLayout();
            this.tlpControllers.ResumeLayout(false);
            this.pnlCrudOperations.ResumeLayout(false);
            this.pnlCrudOperations.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpStructure;
        private System.Windows.Forms.TableLayoutPanel tlpControllers;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Panel pnlCrudOperations;
        private System.Windows.Forms.Button btnDeleteExcavation;
        private System.Windows.Forms.Button btnEditExcavation;
        private System.Windows.Forms.Button btnAddExcavation;
        private System.Windows.Forms.Label lblExcavation;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbProperties;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnsClose;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    }
}

