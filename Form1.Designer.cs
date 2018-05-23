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
            this.mVictory = new System.Windows.Forms.Label();
            this.statusInfo = new System.Windows.Forms.StatusStrip();
            this.btnComeIn = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.labelGamer = new System.Windows.Forms.Label();
            this.nameReg = new System.Windows.Forms.TextBox();
            this.nameSelect = new System.Windows.Forms.ComboBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mVictory
            // 
            this.mVictory.Location = new System.Drawing.Point(4, 416);
            this.mVictory.Name = "mVictory";
            this.mVictory.Size = new System.Drawing.Size(350, 43);
            this.mVictory.TabIndex = 1;
            this.mVictory.Text = "label1";
            this.mVictory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusInfo
            // 
            this.statusInfo.Location = new System.Drawing.Point(0, 470);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(358, 22);
            this.statusInfo.TabIndex = 2;
            this.statusInfo.Text = "statusInfo";
            // 
            // btnComeIn
            // 
            this.btnComeIn.Enabled = false;
            this.btnComeIn.Location = new System.Drawing.Point(79, 233);
            this.btnComeIn.Name = "btnComeIn";
            this.btnComeIn.Size = new System.Drawing.Size(200, 50);
            this.btnComeIn.TabIndex = 3;
            this.btnComeIn.Text = "ВОЙТИ";
            this.btnComeIn.UseVisualStyleBackColor = true;
            this.btnComeIn.Click += new System.EventHandler(this.btnComeIn_Click);
            // 
            // btnReg
            // 
            this.btnReg.Enabled = false;
            this.btnReg.Location = new System.Drawing.Point(79, 152);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(200, 50);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // labelGamer
            // 
            this.labelGamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGamer.Location = new System.Drawing.Point(4, 62);
            this.labelGamer.Name = "labelGamer";
            this.labelGamer.Size = new System.Drawing.Size(350, 29);
            this.labelGamer.TabIndex = 5;
            this.labelGamer.Text = "ИГРОК 1";
            this.labelGamer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameReg
            // 
            this.nameReg.Location = new System.Drawing.Point(79, 113);
            this.nameReg.Name = "nameReg";
            this.nameReg.Size = new System.Drawing.Size(200, 20);
            this.nameReg.TabIndex = 6;
            this.nameReg.TextChanged += new System.EventHandler(this.nameReg_TextChanged);
            // 
            // nameSelect
            // 
            this.nameSelect.Enabled = false;
            this.nameSelect.FormattingEnabled = true;
            this.nameSelect.Location = new System.Drawing.Point(79, 301);
            this.nameSelect.Name = "nameSelect";
            this.nameSelect.Size = new System.Drawing.Size(200, 21);
            this.nameSelect.Sorted = true;
            this.nameSelect.TabIndex = 7;
            this.nameSelect.SelectedIndexChanged += new System.EventHandler(this.nameSelect_SelectedIndexChanged);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(79, 345);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(200, 50);
            this.btnRepeat.TabIndex = 8;
            this.btnRepeat.Text = "ПРОДОЛЖИТЬ ИГРУ";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Visible = false;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 492);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.nameSelect);
            this.Controls.Add(this.nameReg);
            this.Controls.Add(this.labelGamer);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnComeIn);
            this.Controls.Add(this.statusInfo);
            this.Controls.Add(this.mVictory);
            this.Name = "Form1";
            this.Text = "Игра Крестики-Нолики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mVictory;
        private System.Windows.Forms.StatusStrip statusInfo;
        private System.Windows.Forms.Button btnComeIn;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label labelGamer;
        private System.Windows.Forms.TextBox nameReg;
        private System.Windows.Forms.ComboBox nameSelect;
        private System.Windows.Forms.Button btnRepeat;
    }
}

