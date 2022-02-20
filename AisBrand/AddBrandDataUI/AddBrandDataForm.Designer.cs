
namespace AddBrandDataUI
{
    partial class AddBrandDataForm<T>
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
            this.pnlAddButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tlpAddPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAddButtons.SuspendLayout();
            this.tlpAddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAddButtons
            // 
            this.pnlAddButtons.AutoSize = true;
            this.pnlAddButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAddButtons.Controls.Add(this.btnAdd);
            this.pnlAddButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlAddButtons.Name = "pnlAddButtons";
            this.pnlAddButtons.Size = new System.Drawing.Size(693, 460);
            this.pnlAddButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(287, 425);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ОК";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tlpAddPanel
            // 
            this.tlpAddPanel.AutoSize = true;
            this.tlpAddPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpAddPanel.ColumnCount = 1;
            this.tlpAddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAddPanel.Controls.Add(this.pnlAddButtons, 0, 1);
            this.tlpAddPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAddPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpAddPanel.Name = "tlpAddPanel";
            this.tlpAddPanel.RowCount = 2;
            this.tlpAddPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAddPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpAddPanel.Size = new System.Drawing.Size(699, 466);
            this.tlpAddPanel.TabIndex = 0;
            // 
            // AddBrandDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(699, 466);
            this.Controls.Add(this.tlpAddPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBrandDataForm";
            this.Text = "Form1";
            this.pnlAddButtons.ResumeLayout(false);
            this.tlpAddPanel.ResumeLayout(false);
            this.tlpAddPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AddExcavationUserControl excAdd;
        private System.Windows.Forms.Panel pnlAddButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tlpAddPanel;
    }
}

