namespace SecondChance
{
    partial class Complete
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
            this.lblCompleteTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCompleteTitle
            // 
            this.lblCompleteTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompleteTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleteTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblCompleteTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCompleteTitle.Name = "lblCompleteTitle";
            this.lblCompleteTitle.Size = new System.Drawing.Size(503, 320);
            this.lblCompleteTitle.TabIndex = 0;
            this.lblCompleteTitle.Text = "label";
            this.lblCompleteTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCompleteTitle);
            this.Name = "Complete";
            this.Size = new System.Drawing.Size(503, 320);
            this.Load += new System.EventHandler(this.Complete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCompleteTitle;
    }
}
