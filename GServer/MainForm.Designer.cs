namespace GServer
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InfoBox = new System.Windows.Forms.RichTextBox();
            this.StartServer = new System.Windows.Forms.Button();
            this.StopServer = new System.Windows.Forms.Button();
            this.TestClientBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(22, 13);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(250, 161);
            this.InfoBox.TabIndex = 0;
            this.InfoBox.Text = "";
            // 
            // StartServer
            // 
            this.StartServer.Location = new System.Drawing.Point(22, 201);
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(75, 23);
            this.StartServer.TabIndex = 1;
            this.StartServer.Text = "StartServer";
            this.StartServer.UseVisualStyleBackColor = true;
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // StopServer
            // 
            this.StopServer.Location = new System.Drawing.Point(103, 201);
            this.StopServer.Name = "StopServer";
            this.StopServer.Size = new System.Drawing.Size(75, 23);
            this.StopServer.TabIndex = 2;
            this.StopServer.Text = "StopServer";
            this.StopServer.UseVisualStyleBackColor = true;
            this.StopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // TestClientBtn
            // 
            this.TestClientBtn.Location = new System.Drawing.Point(185, 201);
            this.TestClientBtn.Name = "TestClientBtn";
            this.TestClientBtn.Size = new System.Drawing.Size(75, 23);
            this.TestClientBtn.TabIndex = 3;
            this.TestClientBtn.Text = "TestClient";
            this.TestClientBtn.UseVisualStyleBackColor = true;
            this.TestClientBtn.Click += new System.EventHandler(this.TestClientBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TestClientBtn);
            this.Controls.Add(this.StopServer);
            this.Controls.Add(this.StartServer);
            this.Controls.Add(this.InfoBox);
            this.Name = "MainForm";
            this.Text = "GServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox InfoBox;
        private System.Windows.Forms.Button StartServer;
        private System.Windows.Forms.Button StopServer;
        private System.Windows.Forms.Button TestClientBtn;
    }
}

