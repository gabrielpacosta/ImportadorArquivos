namespace ImportadorArquivos
{
    partial class Main
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImportarRec = new System.Windows.Forms.Button();
            this.txbDirArquivoRec = new System.Windows.Forms.TextBox();
            this.btnProcurarRec = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnImportarCA = new System.Windows.Forms.Button();
            this.txbDirArquivoCA = new System.Windows.Forms.TextBox();
            this.btnProcurarCA = new System.Windows.Forms.Button();
            this.dateTimePickerCA = new System.Windows.Forms.DateTimePicker();
            this.lblDataCA = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.openFileDialogCA = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogRec = new System.Windows.Forms.OpenFileDialog();
            this.lblConn = new System.Windows.Forms.Label();
            this.txbConn = new System.Windows.Forms.TextBox();
            this.btnProcurarConn = new System.Windows.Forms.Button();
            this.openFileDialogConn = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(1, 72);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(297, 217);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImportarRec);
            this.tabPage1.Controls.Add(this.txbDirArquivoRec);
            this.tabPage1.Controls.Add(this.btnProcurarRec);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(289, 191);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rec_ass";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImportarRec
            // 
            this.btnImportarRec.Location = new System.Drawing.Point(172, 162);
            this.btnImportarRec.Name = "btnImportarRec";
            this.btnImportarRec.Size = new System.Drawing.Size(75, 23);
            this.btnImportarRec.TabIndex = 14;
            this.btnImportarRec.Text = "Importar";
            this.btnImportarRec.UseVisualStyleBackColor = true;
            this.btnImportarRec.Click += new System.EventHandler(this.btnImportarRec_Click);
            // 
            // txbDirArquivoRec
            // 
            this.txbDirArquivoRec.Enabled = false;
            this.txbDirArquivoRec.Location = new System.Drawing.Point(94, 84);
            this.txbDirArquivoRec.Name = "txbDirArquivoRec";
            this.txbDirArquivoRec.Size = new System.Drawing.Size(153, 20);
            this.txbDirArquivoRec.TabIndex = 13;
            // 
            // btnProcurarRec
            // 
            this.btnProcurarRec.Location = new System.Drawing.Point(20, 83);
            this.btnProcurarRec.Name = "btnProcurarRec";
            this.btnProcurarRec.Size = new System.Drawing.Size(75, 22);
            this.btnProcurarRec.TabIndex = 12;
            this.btnProcurarRec.Text = "Procurar";
            this.btnProcurarRec.UseVisualStyleBackColor = true;
            this.btnProcurarRec.Click += new System.EventHandler(this.btnProcurarRec_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnImportarCA);
            this.tabPage2.Controls.Add(this.txbDirArquivoCA);
            this.tabPage2.Controls.Add(this.btnProcurarCA);
            this.tabPage2.Controls.Add(this.dateTimePickerCA);
            this.tabPage2.Controls.Add(this.lblDataCA);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(289, 191);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Carteira Atual";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnImportarCA
            // 
            this.btnImportarCA.Location = new System.Drawing.Point(172, 162);
            this.btnImportarCA.Name = "btnImportarCA";
            this.btnImportarCA.Size = new System.Drawing.Size(75, 23);
            this.btnImportarCA.TabIndex = 11;
            this.btnImportarCA.Text = "Importar";
            this.btnImportarCA.UseVisualStyleBackColor = true;
            this.btnImportarCA.Click += new System.EventHandler(this.btnImportarCA_Click);
            // 
            // txbDirArquivoCA
            // 
            this.txbDirArquivoCA.Enabled = false;
            this.txbDirArquivoCA.Location = new System.Drawing.Point(94, 84);
            this.txbDirArquivoCA.Name = "txbDirArquivoCA";
            this.txbDirArquivoCA.Size = new System.Drawing.Size(153, 20);
            this.txbDirArquivoCA.TabIndex = 10;
            // 
            // btnProcurarCA
            // 
            this.btnProcurarCA.Location = new System.Drawing.Point(20, 83);
            this.btnProcurarCA.Name = "btnProcurarCA";
            this.btnProcurarCA.Size = new System.Drawing.Size(75, 22);
            this.btnProcurarCA.TabIndex = 9;
            this.btnProcurarCA.Text = "Procurar";
            this.btnProcurarCA.UseVisualStyleBackColor = true;
            this.btnProcurarCA.Click += new System.EventHandler(this.btnProcurarCA_Click);
            // 
            // dateTimePickerCA
            // 
            this.dateTimePickerCA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCA.Location = new System.Drawing.Point(103, 20);
            this.dateTimePickerCA.Name = "dateTimePickerCA";
            this.dateTimePickerCA.Size = new System.Drawing.Size(144, 20);
            this.dateTimePickerCA.TabIndex = 8;
            // 
            // lblDataCA
            // 
            this.lblDataCA.AutoSize = true;
            this.lblDataCA.Location = new System.Drawing.Point(17, 23);
            this.lblDataCA.Name = "lblDataCA";
            this.lblDataCA.Size = new System.Drawing.Size(86, 13);
            this.lblDataCA.TabIndex = 7;
            this.lblDataCA.Text = "Data do arquivo:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(2, 56);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 13);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Selecione a aba referente ao arquivo a ser inserido:";
            // 
            // openFileDialogCA
            // 
            this.openFileDialogCA.FileName = "Arquivo carteira atual";
            this.openFileDialogCA.Filter = "Arquivo de Texto |*.txt";
            // 
            // openFileDialogRec
            // 
            this.openFileDialogRec.FileName = "Arquivo carteira atual";
            this.openFileDialogRec.Filter = "Arquivo de Texto |*.txt";
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Location = new System.Drawing.Point(2, 20);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(105, 13);
            this.lblConn.TabIndex = 9;
            this.lblConn.Text = "Arquivo de conexão:";
            // 
            // txbConn
            // 
            this.txbConn.Enabled = false;
            this.txbConn.Location = new System.Drawing.Point(187, 16);
            this.txbConn.Name = "txbConn";
            this.txbConn.Size = new System.Drawing.Size(107, 20);
            this.txbConn.TabIndex = 15;
            // 
            // btnProcurarConn
            // 
            this.btnProcurarConn.Location = new System.Drawing.Point(113, 15);
            this.btnProcurarConn.Name = "btnProcurarConn";
            this.btnProcurarConn.Size = new System.Drawing.Size(75, 22);
            this.btnProcurarConn.TabIndex = 14;
            this.btnProcurarConn.Text = "Procurar";
            this.btnProcurarConn.UseVisualStyleBackColor = true;
            this.btnProcurarConn.Click += new System.EventHandler(this.btnProcurarConn_Click);
            // 
            // openFileDialogConn
            // 
            this.openFileDialogConn.FileName = "Arquivo de conexão";
            this.openFileDialogConn.Filter = "Arquivo de Texto |*.txt";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(299, 291);
            this.Controls.Add(this.txbConn);
            this.Controls.Add(this.btnProcurarConn);
            this.Controls.Add(this.lblConn);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "ImportadorArquivos";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txbDirArquivoCA;
        private System.Windows.Forms.Button btnProcurarCA;
        private System.Windows.Forms.DateTimePicker dateTimePickerCA;
        private System.Windows.Forms.Label lblDataCA;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnImportarCA;
        private System.Windows.Forms.OpenFileDialog openFileDialogCA;
        private System.Windows.Forms.Button btnImportarRec;
        private System.Windows.Forms.TextBox txbDirArquivoRec;
        private System.Windows.Forms.Button btnProcurarRec;
        private System.Windows.Forms.OpenFileDialog openFileDialogRec;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.TextBox txbConn;
        private System.Windows.Forms.Button btnProcurarConn;
        private System.Windows.Forms.OpenFileDialog openFileDialogConn;
    }
}

