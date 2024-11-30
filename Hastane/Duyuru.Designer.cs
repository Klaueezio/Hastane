namespace Hastane
{
    partial class Duyuru
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hastaneDataSet1 = new Hastane.HastaneDataSet1();
            this.randevuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.randevuTableAdapter = new Hastane.HastaneDataSet1TableAdapters.RandevuTableAdapter();
            this.hastaneDataSet2 = new Hastane.HastaneDataSet2();
            this.duyuruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.duyuruTableAdapter = new Hastane.HastaneDataSet2TableAdapters.DuyuruTableAdapter();
            this.duyuruidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duyuruDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duyuruBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.duyuruidDataGridViewTextBoxColumn,
            this.duyuruDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.duyuruBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(792, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // hastaneDataSet1
            // 
            this.hastaneDataSet1.DataSetName = "HastaneDataSet1";
            this.hastaneDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // randevuBindingSource
            // 
            this.randevuBindingSource.DataMember = "Randevu";
            this.randevuBindingSource.DataSource = this.hastaneDataSet1;
            // 
            // randevuTableAdapter
            // 
            this.randevuTableAdapter.ClearBeforeFill = true;
            // 
            // hastaneDataSet2
            // 
            this.hastaneDataSet2.DataSetName = "HastaneDataSet2";
            this.hastaneDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // duyuruBindingSource
            // 
            this.duyuruBindingSource.DataMember = "Duyuru";
            this.duyuruBindingSource.DataSource = this.hastaneDataSet2;
            // 
            // duyuruTableAdapter
            // 
            this.duyuruTableAdapter.ClearBeforeFill = true;
            // 
            // duyuruidDataGridViewTextBoxColumn
            // 
            this.duyuruidDataGridViewTextBoxColumn.DataPropertyName = "Duyuruid";
            this.duyuruidDataGridViewTextBoxColumn.HeaderText = "Duyuruid";
            this.duyuruidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.duyuruidDataGridViewTextBoxColumn.Name = "duyuruidDataGridViewTextBoxColumn";
            this.duyuruidDataGridViewTextBoxColumn.ReadOnly = true;
            this.duyuruidDataGridViewTextBoxColumn.Width = 125;
            // 
            // duyuruDataGridViewTextBoxColumn
            // 
            this.duyuruDataGridViewTextBoxColumn.DataPropertyName = "Duyuru";
            this.duyuruDataGridViewTextBoxColumn.HeaderText = "Duyuru";
            this.duyuruDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.duyuruDataGridViewTextBoxColumn.Name = "duyuruDataGridViewTextBoxColumn";
            this.duyuruDataGridViewTextBoxColumn.Width = 125;
            // 
            // Duyuru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Duyuru";
            this.Text = "Duyuru";
            this.Load += new System.EventHandler(this.Duyuru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duyuruBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private HastaneDataSet1 hastaneDataSet1;
        private System.Windows.Forms.BindingSource randevuBindingSource;
        private HastaneDataSet1TableAdapters.RandevuTableAdapter randevuTableAdapter;
        private HastaneDataSet2 hastaneDataSet2;
        private System.Windows.Forms.BindingSource duyuruBindingSource;
        private HastaneDataSet2TableAdapters.DuyuruTableAdapter duyuruTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn duyuruidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn duyuruDataGridViewTextBoxColumn;
    }
}