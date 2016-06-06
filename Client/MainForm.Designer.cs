namespace Client
{
    partial class MainForm
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
            this.tbChatWindow = new System.Windows.Forms.TextBox();
            this.tbChatInput = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbChatWindow
            // 
            this.tbChatWindow.Location = new System.Drawing.Point(12, 12);
            this.tbChatWindow.Multiline = true;
            this.tbChatWindow.Name = "tbChatWindow";
            this.tbChatWindow.Size = new System.Drawing.Size(253, 192);
            this.tbChatWindow.TabIndex = 0;
            // 
            // tbChatInput
            // 
            this.tbChatInput.Location = new System.Drawing.Point(12, 210);
            this.tbChatInput.Name = "tbChatInput";
            this.tbChatInput.Size = new System.Drawing.Size(172, 20);
            this.tbChatInput.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(190, 207);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 275);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbChatInput);
            this.Controls.Add(this.tbChatWindow);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChatWindow;
        private System.Windows.Forms.TextBox tbChatInput;
        private System.Windows.Forms.Button btnSendMessage;
    }
}