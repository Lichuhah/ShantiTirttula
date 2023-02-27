namespace ShantiTirttula.Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btn_key = new System.Windows.Forms.Button();
            this.txt_mac = new System.Windows.Forms.TextBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_key
            // 
            this.btn_key.Location = new System.Drawing.Point(12, 12);
            this.btn_key.Name = "btn_key";
            this.btn_key.Size = new System.Drawing.Size(105, 24);
            this.btn_key.TabIndex = 1;
            this.btn_key.Text = "Get key";
            this.btn_key.UseVisualStyleBackColor = true;
            this.btn_key.Click += new System.EventHandler(this.btn_key_Click);
            // 
            // txt_mac
            // 
            this.txt_mac.Location = new System.Drawing.Point(124, 15);
            this.txt_mac.Name = "txt_mac";
            this.txt_mac.Size = new System.Drawing.Size(100, 20);
            this.txt_mac.TabIndex = 2;
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(230, 15);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(100, 20);
            this.txt_key.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.txt_mac);
            this.Controls.Add(this.btn_key);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_key;
        private System.Windows.Forms.TextBox txt_mac;
        private System.Windows.Forms.TextBox txt_key;
    }
}

