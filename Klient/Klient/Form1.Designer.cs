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
            this.button_Connect = new System.Windows.Forms.Button();
            this.textBox_TextToSend = new System.Windows.Forms.TextBox();
            this.button_SendText = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(263, 32);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // textBox_TextToSend
            // 
            this.textBox_TextToSend.Location = new System.Drawing.Point(51, 74);
            this.textBox_TextToSend.Multiline = true;
            this.textBox_TextToSend.Name = "textBox_TextToSend";
            this.textBox_TextToSend.Size = new System.Drawing.Size(206, 107);
            this.textBox_TextToSend.TabIndex = 5;
            // 
            // button_SendText
            // 
            this.button_SendText.Location = new System.Drawing.Point(263, 116);
            this.button_SendText.Name = "button_SendText";
            this.button_SendText.Size = new System.Drawing.Size(75, 23);
            this.button_SendText.TabIndex = 6;
            this.button_SendText.Text = "Send";
            this.button_SendText.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_SendText);
            this.Controls.Add(this.textBox_TextToSend);
            this.Controls.Add(this.button_Connect);
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
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox textBox_TextToSend;
        private System.Windows.Forms.Button button_SendText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

