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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelResult = new System.Windows.Forms.Panel();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxComp = new System.Windows.Forms.CheckBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonRegistrate = new System.Windows.Forms.Button();
            this.panelRegistrate = new System.Windows.Forms.Panel();
            this.panelComeIn = new System.Windows.Forms.Panel();
            this.buttonComeIn = new System.Windows.Forms.Button();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelAccount.SuspendLayout();
            this.panelRegistrate.SuspendLayout();
            this.panelComeIn.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelAccount
            // 
            this.panelAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAccount.Controls.Add(this.panelInfo);
            this.panelAccount.Controls.Add(this.panelComeIn);
            this.panelAccount.Controls.Add(this.panelRegistrate);
            this.panelAccount.Location = new System.Drawing.Point(13, 28);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(240, 400);
            this.panelAccount.TabIndex = 2;
            this.panelAccount.Visible = false;
            // 
            // panelGame
            // 
            this.panelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGame.Location = new System.Drawing.Point(271, 27);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(240, 400);
            this.panelGame.TabIndex = 3;
            // 
            // panelResult
            // 
            this.panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResult.Location = new System.Drawing.Point(526, 27);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(240, 400);
            this.panelResult.TabIndex = 3;
            this.panelResult.Visible = false;
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(74, 15);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Игрок1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(74, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Игрок2";
            // 
            // checkBoxComp
            // 
            this.checkBoxComp.AutoSize = true;
            this.checkBoxComp.Location = new System.Drawing.Point(26, 72);
            this.checkBoxComp.Name = "checkBoxComp";
            this.checkBoxComp.Size = new System.Drawing.Size(145, 17);
            this.checkBoxComp.TabIndex = 2;
            this.checkBoxComp.Text = "Играть с компьютером";
            this.checkBoxComp.UseVisualStyleBackColor = true;
            this.checkBoxComp.Visible = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(27, 22);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(145, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonRegistrate
            // 
            this.buttonRegistrate.Enabled = false;
            this.buttonRegistrate.Location = new System.Drawing.Point(27, 61);
            this.buttonRegistrate.Name = "buttonRegistrate";
            this.buttonRegistrate.Size = new System.Drawing.Size(144, 23);
            this.buttonRegistrate.TabIndex = 4;
            this.buttonRegistrate.Text = "Зарегистрировать";
            this.buttonRegistrate.UseVisualStyleBackColor = true;
            // 
            // panelRegistrate
            // 
            this.panelRegistrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelRegistrate.Controls.Add(this.buttonRegistrate);
            this.panelRegistrate.Controls.Add(this.textBoxName);
            this.panelRegistrate.Location = new System.Drawing.Point(19, 146);
            this.panelRegistrate.Name = "panelRegistrate";
            this.panelRegistrate.Size = new System.Drawing.Size(200, 100);
            this.panelRegistrate.TabIndex = 5;
            // 
            // panelComeIn
            // 
            this.panelComeIn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelComeIn.Controls.Add(this.comboBoxName);
            this.panelComeIn.Controls.Add(this.buttonComeIn);
            this.panelComeIn.Location = new System.Drawing.Point(19, 270);
            this.panelComeIn.Name = "panelComeIn";
            this.panelComeIn.Size = new System.Drawing.Size(200, 100);
            this.panelComeIn.TabIndex = 6;
            // 
            // buttonComeIn
            // 
            this.buttonComeIn.Location = new System.Drawing.Point(27, 61);
            this.buttonComeIn.Name = "buttonComeIn";
            this.buttonComeIn.Size = new System.Drawing.Size(145, 23);
            this.buttonComeIn.TabIndex = 4;
            this.buttonComeIn.Text = "Войти";
            this.buttonComeIn.UseVisualStyleBackColor = true;
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(26, 21);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(145, 21);
            this.comboBoxName.TabIndex = 5;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.checkBoxComp);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.labelPlayer1);
            this.panelInfo.Location = new System.Drawing.Point(19, 25);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(200, 100);
            this.panelInfo.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelAccount);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Крестики-нолики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelAccount.ResumeLayout(false);
            this.panelRegistrate.ResumeLayout(false);
            this.panelRegistrate.PerformLayout();
            this.panelComeIn.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.CheckBox checkBoxComp;
        private System.Windows.Forms.Panel panelRegistrate;
        private System.Windows.Forms.Button buttonRegistrate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelComeIn;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Button buttonComeIn;
        private System.Windows.Forms.Panel panelInfo;
    }
}

