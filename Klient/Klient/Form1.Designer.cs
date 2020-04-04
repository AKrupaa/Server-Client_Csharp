namespace Klient
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_IPaddress = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonWybierzPlik = new System.Windows.Forms.Button();
            this.labelAdresIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_IPaddress
            // 
            this.textBox_IPaddress.Location = new System.Drawing.Point(51, 32);
            this.textBox_IPaddress.Name = "textBox_IPaddress";
            this.textBox_IPaddress.Size = new System.Drawing.Size(100, 22);
            this.textBox_IPaddress.TabIndex = 2;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(157, 32);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 22);
            this.textBox_Port.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Location = new System.Drawing.Point(51, 89);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(206, 23);
            this.buttonSendFile.TabIndex = 4;
            this.buttonSendFile.Text = "SEND";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // buttonWybierzPlik
            // 
            this.buttonWybierzPlik.Location = new System.Drawing.Point(51, 60);
            this.buttonWybierzPlik.Name = "buttonWybierzPlik";
            this.buttonWybierzPlik.Size = new System.Drawing.Size(206, 23);
            this.buttonWybierzPlik.TabIndex = 5;
            this.buttonWybierzPlik.Text = "Choose File";
            this.buttonWybierzPlik.UseVisualStyleBackColor = true;
            this.buttonWybierzPlik.Click += new System.EventHandler(this.buttonWybierzPlik_Click);
            // 
            // labelAdresIP
            // 
            this.labelAdresIP.AutoSize = true;
            this.labelAdresIP.Location = new System.Drawing.Point(73, 12);
            this.labelAdresIP.Name = "labelAdresIP";
            this.labelAdresIP.Size = new System.Drawing.Size(61, 17);
            this.labelAdresIP.TabIndex = 6;
            this.labelAdresIP.Text = "Adres IP";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(193, 12);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 7;
            this.labelPort.Text = "Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 195);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelAdresIP);
            this.Controls.Add(this.buttonWybierzPlik);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IPaddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IPaddress;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.Button buttonWybierzPlik;
        private System.Windows.Forms.Label labelAdresIP;
        private System.Windows.Forms.Label labelPort;
    }
}

