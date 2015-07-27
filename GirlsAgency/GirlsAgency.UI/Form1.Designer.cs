namespace GirlsAgency.UI
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this._GirlsAgency_Data_GirlsAgencyContextDataSet = new GirlsAgency.UI._GirlsAgency_Data_GirlsAgencyContextDataSet();
            this.fullNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameTableAdapter = new GirlsAgency.UI._GirlsAgency_Data_GirlsAgencyContextDataSetTableAdapters.FullNameTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._GirlsAgency_Data_GirlsAgencyContextDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullNameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fullNameBindingSource, "Full Name", true));
            this.comboBox1.DataSource = this.fullNameBindingSource;
            this.comboBox1.DisplayMember = "Full Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Full Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _GirlsAgency_Data_GirlsAgencyContextDataSet
            // 
            this._GirlsAgency_Data_GirlsAgencyContextDataSet.DataSetName = "_GirlsAgency_Data_GirlsAgencyContextDataSet";
            this._GirlsAgency_Data_GirlsAgencyContextDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fullNameBindingSource
            // 
            this.fullNameBindingSource.DataMember = "FullName";
            this.fullNameBindingSource.DataSource = this._GirlsAgency_Data_GirlsAgencyContextDataSet;
            // 
            // fullNameTableAdapter
            // 
            this.fullNameTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._GirlsAgency_Data_GirlsAgencyContextDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullNameBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private _GirlsAgency_Data_GirlsAgencyContextDataSet _GirlsAgency_Data_GirlsAgencyContextDataSet;
        private System.Windows.Forms.BindingSource fullNameBindingSource;
        private _GirlsAgency_Data_GirlsAgencyContextDataSetTableAdapters.FullNameTableAdapter fullNameTableAdapter;
    }
}

