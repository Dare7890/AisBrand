
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpStructure = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tlpControllers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCrudOperations = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbProperties = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.tlsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tlpControllers.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.mnsMenu.SuspendLayout();
            this.cmsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpStructure
            // 
            this.tlpStructure.ColumnCount = 1;
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tlpStructure.Controls.Add(this.dgvTable, 0, 2);
            this.tlpStructure.Controls.Add(this.tlpControllers, 0, 1);
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
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToResizeColumns = false;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTable.Location = new System.Drawing.Point(3, 103);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTable.RowTemplate.Height = 25;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(794, 344);
            this.dgvTable.TabIndex = 3;
            this.dgvTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellDoubleClick);
            this.dgvTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            this.dgvTable.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dgvTable_RowContextMenuStripNeeded);
            this.dgvTable.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvTable_RowStateChanged);
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
            this.pnlCrudOperations.Location = new System.Drawing.Point(3, 3);
            this.pnlCrudOperations.Name = "pnlCrudOperations";
            this.pnlCrudOperations.Size = new System.Drawing.Size(788, 29);
            this.pnlCrudOperations.TabIndex = 0;
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
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsFile});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 20);
            this.mnsMenu.TabIndex = 2;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // tlsFile
            // 
            this.tlsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsUp,
            this.tlsBack,
            this.tlsAdd,
            this.tlsAnalyse});
            this.tlsFile.Name = "tlsFile";
            this.tlsFile.Size = new System.Drawing.Size(48, 16);
            this.tlsFile.Text = "Файл";
            // 
            // tlsUp
            // 
            this.tlsUp.Enabled = false;
            this.tlsUp.Name = "tlsUp";
            this.tlsUp.Size = new System.Drawing.Size(180, 22);
            this.tlsUp.Text = "Вперед";
            this.tlsUp.Click += new System.EventHandler(this.tlsUp_Click);
            // 
            // tlsBack
            // 
            this.tlsBack.Enabled = false;
            this.tlsBack.Name = "tlsBack";
            this.tlsBack.Size = new System.Drawing.Size(180, 22);
            this.tlsBack.Text = "Назад";
            this.tlsBack.Click += new System.EventHandler(this.tlsBack_Click);
            // 
            // tlsAdd
            // 
            this.tlsAdd.Name = "tlsAdd";
            this.tlsAdd.Size = new System.Drawing.Size(180, 22);
            this.tlsAdd.Text = "Добавить";
            this.tlsAdd.Click += new System.EventHandler(this.tlsAdd_Click);
            // 
            // tlsAnalyse
            // 
            this.tlsAnalyse.Name = "tlsAnalyse";
            this.tlsAnalyse.Size = new System.Drawing.Size(180, 22);
            this.tlsAnalyse.Text = "Анализ";
            // 
            // cmsContext
            // 
            this.cmsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiUpdate,
            this.smiDelete});
            this.cmsContext.Name = "cmsContext";
            this.cmsContext.Size = new System.Drawing.Size(146, 48);
            // 
            // smiUpdate
            // 
            this.smiUpdate.Name = "smiUpdate";
            this.smiUpdate.Size = new System.Drawing.Size(145, 22);
            this.smiUpdate.Text = "Подробнее...";
            this.smiUpdate.Click += new System.EventHandler(this.smiUpdate_Click);
            // 
            // smiDelete
            // 
            this.smiDelete.Name = "smiDelete";
            this.smiDelete.Size = new System.Drawing.Size(145, 22);
            this.smiDelete.Text = "Удалить";
            this.smiDelete.Click += new System.EventHandler(this.smiDelete_Click);
            // 
            // BrandDataProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpStructure);
            this.MainMenuStrip = this.mnsMenu;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "BrandDataProcessingForm";
            this.Text = "Brand Data Processing";
            this.tlpStructure.ResumeLayout(false);
            this.tlpStructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tlpControllers.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.cmsContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpStructure;
        private System.Windows.Forms.TableLayoutPanel tlpControllers;
        private System.Windows.Forms.Panel pnlCrudOperations;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbProperties;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem smiUpdate;
        private System.Windows.Forms.ToolStripMenuItem smiDelete;
        private System.Windows.Forms.ToolStripMenuItem tlsFile;
        private System.Windows.Forms.ToolStripMenuItem tlsUp;
        private System.Windows.Forms.ToolStripMenuItem tlsBack;
        private System.Windows.Forms.ToolStripMenuItem tlsAdd;
        private System.Windows.Forms.ToolStripMenuItem tlsAnalyse;
    }
}

