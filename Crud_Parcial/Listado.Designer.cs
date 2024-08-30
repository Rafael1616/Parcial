namespace Crud_Parcial
{
    partial class Listado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listado));
            this.tbRecargar = new System.Windows.Forms.Button();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TablaPersonal = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Update = new System.Windows.Forms.DataGridViewImageColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomePage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRecargar
            // 
            this.tbRecargar.BackColor = System.Drawing.Color.Silver;
            this.tbRecargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRecargar.Location = new System.Drawing.Point(23, 17);
            this.tbRecargar.Name = "tbRecargar";
            this.tbRecargar.Size = new System.Drawing.Size(89, 29);
            this.tbRecargar.TabIndex = 11;
            this.tbRecargar.Text = "Recargar";
            this.tbRecargar.UseVisualStyleBackColor = false;
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(655, 51);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(123, 20);
            this.tbFiltro.TabIndex = 9;
            this.tbFiltro.TextChanged += new System.EventHandler(this.tbFiltro_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Listado del Personal";
            // 
            // TablaPersonal
            // 
            this.TablaPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaPersonal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.Update,
            this.SupplierID,
            this.CompanyName,
            this.ContactName,
            this.ContactTitle,
            this.Addres,
            this.City,
            this.Region,
            this.PostalCode,
            this.Country,
            this.Phone,
            this.Fax,
            this.HomePage});
            this.TablaPersonal.Location = new System.Drawing.Point(23, 108);
            this.TablaPersonal.Name = "TablaPersonal";
            this.TablaPersonal.Size = new System.Drawing.Size(755, 326);
            this.TablaPersonal.TabIndex = 7;
            this.TablaPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaPersonal_CellClick_1);
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Eliminar";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // Update
            // 
            this.Update.HeaderText = "Editar";
            this.Update.Image = ((System.Drawing.Image)(resources.GetObject("Update.Image")));
            this.Update.Name = "Update";
            this.Update.Width = 60;
            // 
            // SupplierID
            // 
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "ID";
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.Width = 50;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "CompanyName";
            this.CompanyName.Name = "CompanyName";
            // 
            // ContactName
            // 
            this.ContactName.DataPropertyName = "ContactName";
            this.ContactName.HeaderText = "ContactName";
            this.ContactName.Name = "ContactName";
            // 
            // ContactTitle
            // 
            this.ContactTitle.DataPropertyName = "ContactTitle";
            this.ContactTitle.HeaderText = "ContactTitle";
            this.ContactTitle.Name = "ContactTitle";
            // 
            // Addres
            // 
            this.Addres.DataPropertyName = "Addres";
            this.Addres.HeaderText = "Addres";
            this.Addres.Name = "Addres";
            this.Addres.Visible = false;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Region
            // 
            this.Region.DataPropertyName = "Region";
            this.Region.HeaderText = "Region";
            this.Region.Name = "Region";
            this.Region.Visible = false;
            // 
            // PostalCode
            // 
            this.PostalCode.DataPropertyName = "PostalCode";
            this.PostalCode.HeaderText = "PostalCode";
            this.PostalCode.Name = "PostalCode";
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.Visible = false;
            // 
            // HomePage
            // 
            this.HomePage.DataPropertyName = "HomePage";
            this.HomePage.HeaderText = "HomePage";
            this.HomePage.Name = "HomePage";
            this.HomePage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Buscar:";
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbRecargar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TablaPersonal);
            this.Name = "Listado";
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.TablaPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tbRecargar;
        private System.Windows.Forms.TextBox tbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TablaPersonal;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Update;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addres;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomePage;
        private System.Windows.Forms.Label label2;
    }
}