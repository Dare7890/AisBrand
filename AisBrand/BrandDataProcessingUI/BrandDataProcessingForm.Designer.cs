
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpStructure = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tlpControllers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbProperties = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.tlsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tlpStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
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
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.dgvTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTable.Location = new System.Drawing.Point(3, 63);
            this.dgvTable.Name = "dgvTable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTable.RowTemplate.Height = 25;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(794, 384);
            this.dgvTable.TabIndex = 3;
            this.dgvTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellDoubleClick);
            this.dgvTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            this.dgvTable.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dgvTable_RowContextMenuStripNeeded);
            this.dgvTable.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvTable_RowStateChanged);
            // 
            // tlpControllers
            // 
            this.tlpControllers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpControllers.ColumnCount = 1;
            this.tlpControllers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControllers.Controls.Add(this.pnlFilter, 0, 0);
            this.tlpControllers.Location = new System.Drawing.Point(3, 23);
            this.tlpControllers.Name = "tlpControllers";
            this.tlpControllers.RowCount = 1;
            this.tlpControllers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControllers.Size = new System.Drawing.Size(794, 34);
            this.tlpControllers.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.cmbProperties);
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.txtValue);
            this.pnlFilter.Location = new System.Drawing.Point(3, 3);
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
            this.cmbProperties.Location = new System.Drawing.Point(169, 6);
            this.cmbProperties.Name = "cmbProperties";
            this.cmbProperties.Size = new System.Drawing.Size(123, 23);
            this.cmbProperties.TabIndex = 3;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(15, 10);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(157, 15);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(298, 6);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(484, 23);
            this.txtValue.TabIndex = 0;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsFile,
            this.справкаToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 20);
            this.mnsMenu.TabIndex = 2;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // tlsFile
            // 
            this.tlsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsBack,
            this.tlsAdd,
            this.tlsCopy,
            this.tlsAnalyse});
            this.tlsFile.Name = "tlsFile";
            this.tlsFile.Size = new System.Drawing.Size(68, 16);
            this.tlsFile.Text = "Функции";
            // 
            // tlsBack
            // 
            this.tlsBack.Enabled = false;
            this.tlsBack.Name = "tlsBack";
            this.tlsBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tlsBack.Size = new System.Drawing.Size(181, 22);
            this.tlsBack.Text = "Назад";
            this.tlsBack.Click += new System.EventHandler(this.tlsBack_Click);
            // 
            // tlsAdd
            // 
            this.tlsAdd.Name = "tlsAdd";
            this.tlsAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tlsAdd.Size = new System.Drawing.Size(181, 22);
            this.tlsAdd.Text = "Добавить";
            this.tlsAdd.Click += new System.EventHandler(this.tlsAdd_Click);
            // 
            // tlsCopy
            // 
            this.tlsCopy.Enabled = false;
            this.tlsCopy.Name = "tlsCopy";
            this.tlsCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tlsCopy.Size = new System.Drawing.Size(181, 22);
            this.tlsCopy.Text = "Копировать";
            this.tlsCopy.Visible = false;
            this.tlsCopy.Click += new System.EventHandler(this.tlsCopy_Click);
            // 
            // tlsAnalyse
            // 
            this.tlsAnalyse.Enabled = false;
            this.tlsAnalyse.Name = "tlsAnalyse";
            this.tlsAnalyse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tlsAnalyse.Size = new System.Drawing.Size(181, 22);
            this.tlsAnalyse.Text = "Анализ";
            this.tlsAnalyse.Click += new System.EventHandler(this.tlsAnalyse_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 16);
            this.справкаToolStripMenuItem.Text = "Справка";
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
            this.Text = "ААИС";
            this.Load += new System.EventHandler(this.BrandDataProcessingForm_Load);
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
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem smiUpdate;
        private System.Windows.Forms.ToolStripMenuItem smiDelete;
        private System.Windows.Forms.ToolStripMenuItem tlsFile;
        private System.Windows.Forms.ToolStripMenuItem tlsBack;
        private System.Windows.Forms.ToolStripMenuItem tlsAdd;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.TableLayoutPanel tlpControllers;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbProperties;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tlsCopy;
        private System.Windows.Forms.ToolStripMenuItem tlsAnalyse;
    }
}

