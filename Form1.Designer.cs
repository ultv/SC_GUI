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
            this.посмотретьИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripInfo = new System.Windows.Forms.StatusStrip();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.checkBoxComp = new System.Windows.Forms.CheckBox();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.panelComeIn = new System.Windows.Forms.Panel();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.buttonComeIn = new System.Windows.Forms.Button();
            this.panelRegistrate = new System.Windows.Forms.Panel();
            this.buttonRegistrate = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelGame = new System.Windows.Forms.Panel();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.labelNameVictory = new System.Windows.Forms.Label();
            this.labelNamePlayer = new System.Windows.Forms.Label();
            this.labelFocus = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.Panel();
            this.openFileDialogGame = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panelAccount.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelComeIn.SuspendLayout();
            this.panelRegistrate.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.посмотретьИгруToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // посмотретьИгруToolStripMenuItem
            // 
            this.посмотретьИгруToolStripMenuItem.Name = "посмотретьИгруToolStripMenuItem";
            this.посмотретьИгруToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.посмотретьИгруToolStripMenuItem.Text = "Посмотреть игру";
            this.посмотретьИгруToolStripMenuItem.Click += new System.EventHandler(this.посмотретьИгруToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // statusStripInfo
            // 
            this.statusStripInfo.Location = new System.Drawing.Point(0, 460);
            this.statusStripInfo.Name = "statusStripInfo";
            this.statusStripInfo.Size = new System.Drawing.Size(784, 22);
            this.statusStripInfo.TabIndex = 1;
            this.statusStripInfo.Text = "statusStrip1";
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
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.checkBoxComp);
            this.panelInfo.Controls.Add(this.labelPlayer2);
            this.panelInfo.Controls.Add(this.labelPlayer1);
            this.panelInfo.Location = new System.Drawing.Point(19, 25);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(200, 100);
            this.panelInfo.TabIndex = 6;
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
            this.checkBoxComp.CheckedChanged += new System.EventHandler(this.checkBoxComp_CheckedChanged);
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Enabled = false;
            this.labelPlayer2.Location = new System.Drawing.Point(74, 45);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(47, 13);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Text = "Игрок 2";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(74, 15);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(47, 13);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Игрок 1";
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
            // comboBoxName
            // 
            this.comboBoxName.Enabled = false;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(26, 21);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(145, 21);
            this.comboBoxName.TabIndex = 5;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // buttonComeIn
            // 
            this.buttonComeIn.Enabled = false;
            this.buttonComeIn.Location = new System.Drawing.Point(27, 61);
            this.buttonComeIn.Name = "buttonComeIn";
            this.buttonComeIn.Size = new System.Drawing.Size(145, 23);
            this.buttonComeIn.TabIndex = 4;
            this.buttonComeIn.Text = "Войти";
            this.buttonComeIn.UseVisualStyleBackColor = true;
            this.buttonComeIn.Click += new System.EventHandler(this.buttonComeIn_Click);
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
            // buttonRegistrate
            // 
            this.buttonRegistrate.Enabled = false;
            this.buttonRegistrate.Location = new System.Drawing.Point(27, 61);
            this.buttonRegistrate.Name = "buttonRegistrate";
            this.buttonRegistrate.Size = new System.Drawing.Size(144, 23);
            this.buttonRegistrate.TabIndex = 4;
            this.buttonRegistrate.Text = "Зарегистрировать";
            this.buttonRegistrate.UseVisualStyleBackColor = true;
            this.buttonRegistrate.Click += new System.EventHandler(this.buttonRegistrate_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(27, 22);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(145, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // panelGame
            // 
            this.panelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGame.Controls.Add(this.buttonNewGame);
            this.panelGame.Controls.Add(this.panelBtns);
            this.panelGame.Controls.Add(this.labelNameVictory);
            this.panelGame.Controls.Add(this.labelNamePlayer);
            this.panelGame.Controls.Add(this.labelFocus);
            this.panelGame.Location = new System.Drawing.Point(271, 27);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(240, 400);
            this.panelGame.TabIndex = 3;
            this.panelGame.Visible = false;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(80, 353);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 4;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Visible = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // panelBtns
            // 
            this.panelBtns.Location = new System.Drawing.Point(3, 51);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(232, 249);
            this.panelBtns.TabIndex = 3;
            // 
            // labelNameVictory
            // 
            this.labelNameVictory.Location = new System.Drawing.Point(8, 325);
            this.labelNameVictory.Name = "labelNameVictory";
            this.labelNameVictory.Size = new System.Drawing.Size(220, 13);
            this.labelNameVictory.TabIndex = 2;
            this.labelNameVictory.Text = "label1";
            this.labelNameVictory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNamePlayer
            // 
            this.labelNamePlayer.Location = new System.Drawing.Point(9, 28);
            this.labelNamePlayer.Name = "labelNamePlayer";
            this.labelNamePlayer.Size = new System.Drawing.Size(220, 13);
            this.labelNamePlayer.TabIndex = 1;
            this.labelNamePlayer.Text = "label1";
            this.labelNamePlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFocus
            // 
            this.labelFocus.AutoSize = true;
            this.labelFocus.Location = new System.Drawing.Point(102, 169);
            this.labelFocus.Name = "labelFocus";
            this.labelFocus.Size = new System.Drawing.Size(35, 13);
            this.labelFocus.TabIndex = 0;
            this.labelFocus.Text = "label1";
            this.labelFocus.Visible = false;
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
            // openFileDialogGame
            // 
            this.openFileDialogGame.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelAccount);
            this.Controls.Add(this.statusStripInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 520);
            this.MinimumSize = new System.Drawing.Size(300, 520);
            this.Name = "Form1";
            this.Text = "Крестики-нолики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelAccount.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelComeIn.ResumeLayout(false);
            this.panelRegistrate.ResumeLayout(false);
            this.panelRegistrate.PerformLayout();
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStripInfo;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.CheckBox checkBoxComp;
        private System.Windows.Forms.Panel panelRegistrate;
        private System.Windows.Forms.Button buttonRegistrate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelComeIn;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Button buttonComeIn;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelFocus;
        private System.Windows.Forms.Label labelNamePlayer;
        private System.Windows.Forms.Label labelNameVictory;
        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.ToolStripMenuItem посмотретьИгруToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogGame;
    }
}

