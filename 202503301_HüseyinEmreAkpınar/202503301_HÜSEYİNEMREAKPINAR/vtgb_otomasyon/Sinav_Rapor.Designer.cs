
namespace vtgb_otomasyon
{
    partial class Sinav_Rapor
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SinavRaporDataSet = new vtgb_otomasyon.odevDataSet();
            this.sinavlarRapor1 = new vtgb_otomasyon.SinavlarRapor();
            ((System.ComponentModel.ISupportInitialize)(this.SinavRaporDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1139, 612);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // SinavRaporDataSet
            // 
            this.SinavRaporDataSet.DataSetName = "SinavRaporDataSet";
            this.SinavRaporDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Sinav_Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 612);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Sinav_Rapor";
            this.Text = "Sinav_Rapor";
            this.Load += new System.EventHandler(this.Sinav_Rapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SinavRaporDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private SinavlarRapor sinavlarRapor1;
        private odevDataSet SinavRaporDataSet;
    }
}