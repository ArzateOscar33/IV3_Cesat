namespace IV3_CESAT
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
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this.timer_camara = new System.Windows.Forms.Timer(this.components);
            this.label_ok = new System.Windows.Forms.Label();
            this.txbIpMaestro = new System.Windows.Forms.TextBox();
            this.txbIpCamara = new System.Windows.Forms.TextBox();
            this.label_error = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label_programa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(12, 131);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(264, 200);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // timer_camara
            // 
            this.timer_camara.Tick += new System.EventHandler(this.timer_camara_Tick);
            // 
            // label_ok
            // 
            this.label_ok.AutoSize = true;
            this.label_ok.Location = new System.Drawing.Point(14, 32);
            this.label_ok.Name = "label_ok";
            this.label_ok.Size = new System.Drawing.Size(106, 13);
            this.label_ok.TabIndex = 1;
            this.label_ok.Text = "Direccion IP Maestro";
            // 
            // txbIpMaestro
            // 
            this.txbIpMaestro.Location = new System.Drawing.Point(17, 48);
            this.txbIpMaestro.Name = "txbIpMaestro";
            this.txbIpMaestro.Size = new System.Drawing.Size(151, 20);
            this.txbIpMaestro.TabIndex = 2;
            // 
            // txbIpCamara
            // 
            this.txbIpCamara.Location = new System.Drawing.Point(201, 48);
            this.txbIpCamara.Name = "txbIpCamara";
            this.txbIpCamara.Size = new System.Drawing.Size(156, 20);
            this.txbIpCamara.TabIndex = 3;
            this.txbIpCamara.Text = "169, 254, 109, 199";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(218, 32);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(104, 13);
            this.label_error.TabIndex = 4;
            this.label_error.Text = "Direccion IP Camara";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_programa);
            this.groupBox1.Controls.Add(this.txbIpMaestro);
            this.groupBox1.Controls.Add(this.label_error);
            this.groupBox1.Controls.Add(this.label_ok);
            this.groupBox1.Controls.Add(this.txbIpCamara);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Direcciones IP";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(282, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 104);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controles Camara";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(23, 62);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label_programa
            // 
            this.label_programa.AutoSize = true;
            this.label_programa.Location = new System.Drawing.Point(132, 16);
            this.label_programa.Name = "label_programa";
            this.label_programa.Size = new System.Drawing.Size(104, 13);
            this.label_programa.TabIndex = 5;
            this.label_programa.Text = "Direccion IP Camara";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Timer timer_camara;
        private System.Windows.Forms.Label label_ok;
        private System.Windows.Forms.TextBox txbIpMaestro;
        private System.Windows.Forms.TextBox txbIpCamara;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label_programa;
    }
}

