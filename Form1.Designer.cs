namespace CS_GUI
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
            this.statusStripInfo = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.panelComeIn = new System.Windows.Forms.Panel();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonComeIn = new System.Windows.Forms.Button();
            this.panelRegistrate = new System.Windows.Forms.Panel();
            this.buttonRegistrate = new System.Windows.Forms.Button();
            this.comboBoxRegistrate = new System.Windows.Forms.ComboBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.panelAccount.SuspendLayout();
            this.panelComeIn.SuspendLayout();
            this.panelRegistrate.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripInfo
            // 
            this.statusStripInfo.Location = new System.Drawing.Point(0, 540);
            this.statusStripInfo.Name = "statusStripInfo";
            this.statusStripInfo.Size = new System.Drawing.Size(384, 22);
            this.statusStripInfo.TabIndex = 0;
            this.statusStripInfo.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panelAccount
            // 
            this.panelAccount.AutoSize = true;
            this.panelAccount.Controls.Add(this.labelPlayer2);
            this.panelAccount.Controls.Add(this.labelPlayer1);
            this.panelAccount.Controls.Add(this.panelRegistrate);
            this.panelAccount.Controls.Add(this.panelComeIn);
            this.panelAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccount.Location = new System.Drawing.Point(0, 24);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(384, 516);
            this.panelAccount.TabIndex = 2;
            // 
            // panelComeIn
            // 
            this.panelComeIn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelComeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComeIn.Controls.Add(this.buttonRegistrate);
            this.panelComeIn.Controls.Add(this.textBoxName);
            this.panelComeIn.Location = new System.Drawing.Point(42, 93);
            this.panelComeIn.Name = "panelComeIn";
            this.panelComeIn.Size = new System.Drawing.Size(289, 115);
            this.panelComeIn.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(22, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(250, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // buttonComeIn
            // 
            this.buttonComeIn.Location = new System.Drawing.Point(22, 63);
            this.buttonComeIn.Name = "buttonComeIn";
            this.buttonComeIn.Size = new System.Drawing.Size(132, 31);
            this.buttonComeIn.TabIndex = 1;
            this.buttonComeIn.Text = "Войти";
            this.buttonComeIn.UseVisualStyleBackColor = true;
            this.buttonComeIn.Click += new System.EventHandler(this.buttonComeIn_Click);
            // 
            // panelRegistrate
            // 
            this.panelRegistrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelRegistrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRegistrate.Controls.Add(this.buttonComeIn);
            this.panelRegistrate.Controls.Add(this.comboBoxRegistrate);
            this.panelRegistrate.Location = new System.Drawing.Point(42, 256);
            this.panelRegistrate.Name = "panelRegistrate";
            this.panelRegistrate.Size = new System.Drawing.Size(289, 115);
            this.panelRegistrate.TabIndex = 1;
            // 
            // buttonRegistrate
            // 
            this.buttonRegistrate.Enabled = false;
            this.buttonRegistrate.Location = new System.Drawing.Point(22, 66);
            this.buttonRegistrate.Name = "buttonRegistrate";
            this.buttonRegistrate.Size = new System.Drawing.Size(126, 31);
            this.buttonRegistrate.TabIndex = 1;
            this.buttonRegistrate.Text = "Зарегистрироваться";
            this.buttonRegistrate.UseVisualStyleBackColor = true;
            this.buttonRegistrate.Click += new System.EventHandler(this.buttonRegistrate_Click);
            // 
            // comboBoxRegistrate
            // 
            this.comboBoxRegistrate.FormattingEnabled = true;
            this.comboBoxRegistrate.Location = new System.Drawing.Point(22, 20);
            this.comboBoxRegistrate.Name = "comboBoxRegistrate";
            this.comboBoxRegistrate.Size = new System.Drawing.Size(244, 21);
            this.comboBoxRegistrate.TabIndex = 2;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(65, 39);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "Игрок1";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Enabled = false;
            this.labelPlayer2.Location = new System.Drawing.Point(254, 39);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer2.TabIndex = 3;
            this.labelPlayer2.Text = "Игрок2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 562);
            this.Controls.Add(this.panelAccount);
            this.Controls.Add(this.statusStripInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Крестики-Нолики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAccount.ResumeLayout(false);
            this.panelAccount.PerformLayout();
            this.panelComeIn.ResumeLayout(false);
            this.panelComeIn.PerformLayout();
            this.panelRegistrate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Panel panelComeIn;
        private System.Windows.Forms.Button buttonComeIn;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelRegistrate;
        private System.Windows.Forms.ComboBox comboBoxRegistrate;
        private System.Windows.Forms.Button buttonRegistrate;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPlayer1;
    }
}

