namespace ProjetoPingUDP.View
{
    partial class FormPrincipal
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
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.listBoxLogPing = new System.Windows.Forms.ListBox();
            this.buttonExecutarPing = new System.Windows.Forms.Button();
            this.textBoxPortaDestino = new System.Windows.Forms.TextBox();
            this.labelPortaDestino = new System.Windows.Forms.Label();
            this.textBoxIPDestino = new System.Windows.Forms.TextBox();
            this.labelIPDestino = new System.Windows.Forms.Label();
            this.groupBoxServidor = new System.Windows.Forms.GroupBox();
            this.buttonPararServidor = new System.Windows.Forms.Button();
            this.listBoxLogServidor = new System.Windows.Forms.ListBox();
            this.buttonIniciarServidor = new System.Windows.Forms.Button();
            this.textBoxPortaServidor = new System.Windows.Forms.TextBox();
            this.labelPortaServidor = new System.Windows.Forms.Label();
            this.numericUpDownNumeroPacotes = new System.Windows.Forms.NumericUpDown();
            this.labelNumeroPacotes = new System.Windows.Forms.Label();
            this.groupBoxCliente.SuspendLayout();
            this.groupBoxServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeroPacotes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCliente.Controls.Add(this.labelNumeroPacotes);
            this.groupBoxCliente.Controls.Add(this.numericUpDownNumeroPacotes);
            this.groupBoxCliente.Controls.Add(this.listBoxLogPing);
            this.groupBoxCliente.Controls.Add(this.buttonExecutarPing);
            this.groupBoxCliente.Controls.Add(this.textBoxPortaDestino);
            this.groupBoxCliente.Controls.Add(this.labelPortaDestino);
            this.groupBoxCliente.Controls.Add(this.textBoxIPDestino);
            this.groupBoxCliente.Controls.Add(this.labelIPDestino);
            this.groupBoxCliente.Location = new System.Drawing.Point(13, 13);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(614, 155);
            this.groupBoxCliente.TabIndex = 0;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Cliente";
            // 
            // listBoxLogPing
            // 
            this.listBoxLogPing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLogPing.FormattingEnabled = true;
            this.listBoxLogPing.Location = new System.Drawing.Point(264, 27);
            this.listBoxLogPing.Name = "listBoxLogPing";
            this.listBoxLogPing.Size = new System.Drawing.Size(331, 108);
            this.listBoxLogPing.TabIndex = 5;
            // 
            // buttonExecutarPing
            // 
            this.buttonExecutarPing.Location = new System.Drawing.Point(137, 112);
            this.buttonExecutarPing.Name = "buttonExecutarPing";
            this.buttonExecutarPing.Size = new System.Drawing.Size(107, 23);
            this.buttonExecutarPing.TabIndex = 4;
            this.buttonExecutarPing.Text = "Executar Ping";
            this.buttonExecutarPing.UseVisualStyleBackColor = true;
            this.buttonExecutarPing.Click += new System.EventHandler(this.buttonExecutarPing_Click);
            // 
            // textBoxPortaDestino
            // 
            this.textBoxPortaDestino.Location = new System.Drawing.Point(56, 53);
            this.textBoxPortaDestino.Name = "textBoxPortaDestino";
            this.textBoxPortaDestino.Size = new System.Drawing.Size(188, 20);
            this.textBoxPortaDestino.TabIndex = 3;
            // 
            // labelPortaDestino
            // 
            this.labelPortaDestino.AutoSize = true;
            this.labelPortaDestino.Location = new System.Drawing.Point(6, 56);
            this.labelPortaDestino.Name = "labelPortaDestino";
            this.labelPortaDestino.Size = new System.Drawing.Size(32, 13);
            this.labelPortaDestino.TabIndex = 2;
            this.labelPortaDestino.Text = "Porta";
            // 
            // textBoxIPDestino
            // 
            this.textBoxIPDestino.Location = new System.Drawing.Point(56, 27);
            this.textBoxIPDestino.Name = "textBoxIPDestino";
            this.textBoxIPDestino.Size = new System.Drawing.Size(188, 20);
            this.textBoxIPDestino.TabIndex = 1;
            // 
            // labelIPDestino
            // 
            this.labelIPDestino.AutoSize = true;
            this.labelIPDestino.Location = new System.Drawing.Point(6, 30);
            this.labelIPDestino.Name = "labelIPDestino";
            this.labelIPDestino.Size = new System.Drawing.Size(17, 13);
            this.labelIPDestino.TabIndex = 0;
            this.labelIPDestino.Text = "IP";
            // 
            // groupBoxServidor
            // 
            this.groupBoxServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServidor.Controls.Add(this.buttonPararServidor);
            this.groupBoxServidor.Controls.Add(this.listBoxLogServidor);
            this.groupBoxServidor.Controls.Add(this.buttonIniciarServidor);
            this.groupBoxServidor.Controls.Add(this.textBoxPortaServidor);
            this.groupBoxServidor.Controls.Add(this.labelPortaServidor);
            this.groupBoxServidor.Location = new System.Drawing.Point(13, 174);
            this.groupBoxServidor.Name = "groupBoxServidor";
            this.groupBoxServidor.Size = new System.Drawing.Size(614, 169);
            this.groupBoxServidor.TabIndex = 1;
            this.groupBoxServidor.TabStop = false;
            this.groupBoxServidor.Text = "Servidor";
            // 
            // buttonPararServidor
            // 
            this.buttonPararServidor.Enabled = false;
            this.buttonPararServidor.Location = new System.Drawing.Point(137, 130);
            this.buttonPararServidor.Name = "buttonPararServidor";
            this.buttonPararServidor.Size = new System.Drawing.Size(107, 23);
            this.buttonPararServidor.TabIndex = 8;
            this.buttonPararServidor.Text = "Parar Servidor";
            this.buttonPararServidor.UseVisualStyleBackColor = true;
            this.buttonPararServidor.Click += new System.EventHandler(this.buttonPararServidor_Click);
            // 
            // listBoxLogServidor
            // 
            this.listBoxLogServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLogServidor.FormattingEnabled = true;
            this.listBoxLogServidor.Location = new System.Drawing.Point(264, 19);
            this.listBoxLogServidor.Name = "listBoxLogServidor";
            this.listBoxLogServidor.Size = new System.Drawing.Size(331, 134);
            this.listBoxLogServidor.TabIndex = 6;
            // 
            // buttonIniciarServidor
            // 
            this.buttonIniciarServidor.Location = new System.Drawing.Point(137, 101);
            this.buttonIniciarServidor.Name = "buttonIniciarServidor";
            this.buttonIniciarServidor.Size = new System.Drawing.Size(107, 23);
            this.buttonIniciarServidor.TabIndex = 6;
            this.buttonIniciarServidor.Text = "Iniciar Servidor";
            this.buttonIniciarServidor.UseVisualStyleBackColor = true;
            this.buttonIniciarServidor.Click += new System.EventHandler(this.buttonIniciarServidor_Click);
            // 
            // textBoxPortaServidor
            // 
            this.textBoxPortaServidor.Location = new System.Drawing.Point(56, 19);
            this.textBoxPortaServidor.Name = "textBoxPortaServidor";
            this.textBoxPortaServidor.Size = new System.Drawing.Size(188, 20);
            this.textBoxPortaServidor.TabIndex = 7;
            // 
            // labelPortaServidor
            // 
            this.labelPortaServidor.AutoSize = true;
            this.labelPortaServidor.Location = new System.Drawing.Point(18, 22);
            this.labelPortaServidor.Name = "labelPortaServidor";
            this.labelPortaServidor.Size = new System.Drawing.Size(32, 13);
            this.labelPortaServidor.TabIndex = 6;
            this.labelPortaServidor.Text = "Porta";
            // 
            // numericUpDownNumeroPacotes
            // 
            this.numericUpDownNumeroPacotes.Location = new System.Drawing.Point(56, 80);
            this.numericUpDownNumeroPacotes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumeroPacotes.Name = "numericUpDownNumeroPacotes";
            this.numericUpDownNumeroPacotes.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownNumeroPacotes.TabIndex = 6;
            this.numericUpDownNumeroPacotes.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelNumeroPacotes
            // 
            this.labelNumeroPacotes.AutoSize = true;
            this.labelNumeroPacotes.Location = new System.Drawing.Point(6, 83);
            this.labelNumeroPacotes.Name = "labelNumeroPacotes";
            this.labelNumeroPacotes.Size = new System.Drawing.Size(46, 13);
            this.labelNumeroPacotes.TabIndex = 7;
            this.labelNumeroPacotes.Text = "Pacotes";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 355);
            this.Controls.Add(this.groupBoxServidor);
            this.Controls.Add(this.groupBoxCliente);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            this.groupBoxServidor.ResumeLayout(false);
            this.groupBoxServidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeroPacotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.GroupBox groupBoxServidor;
        private System.Windows.Forms.TextBox textBoxIPDestino;
        private System.Windows.Forms.Label labelIPDestino;
        private System.Windows.Forms.TextBox textBoxPortaDestino;
        private System.Windows.Forms.Label labelPortaDestino;
        private System.Windows.Forms.ListBox listBoxLogPing;
        private System.Windows.Forms.Button buttonExecutarPing;
        private System.Windows.Forms.TextBox textBoxPortaServidor;
        private System.Windows.Forms.Label labelPortaServidor;
        private System.Windows.Forms.ListBox listBoxLogServidor;
        private System.Windows.Forms.Button buttonIniciarServidor;
        private System.Windows.Forms.Button buttonPararServidor;
        private System.Windows.Forms.Label labelNumeroPacotes;
        private System.Windows.Forms.NumericUpDown numericUpDownNumeroPacotes;

    }
}

