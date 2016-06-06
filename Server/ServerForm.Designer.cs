namespace Server
{
    partial class ServerForm
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.btnServerSend = new System.Windows.Forms.Button();
            this.tbServerInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.Location = new System.Drawing.Point(12, 12);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(260, 195);
            this.tb1.TabIndex = 0;
            // 
            // btnServerSend
            // 
            this.btnServerSend.Location = new System.Drawing.Point(197, 226);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new System.Drawing.Size(75, 23);
            this.btnServerSend.TabIndex = 1;
            this.btnServerSend.Text = "Send";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new System.EventHandler(this.btnServerSend_Click);
            // 
            // tbServerInput
            // 
            this.tbServerInput.Location = new System.Drawing.Point(13, 226);
            this.tbServerInput.Name = "tbServerInput";
            this.tbServerInput.Size = new System.Drawing.Size(178, 20);
            this.tbServerInput.TabIndex = 2;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbServerInput);
            this.Controls.Add(this.btnServerSend);
            this.Controls.Add(this.tb1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Button btnServerSend;
        private System.Windows.Forms.TextBox tbServerInput;
    }
}

