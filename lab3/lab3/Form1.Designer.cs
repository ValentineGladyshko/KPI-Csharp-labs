namespace lab3
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
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonSubtract = new System.Windows.Forms.Button();
            this.ButtonMultiply = new System.Windows.Forms.Button();
            this.ButtonDivide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Complex1 = new System.Windows.Forms.TextBox();
            this.Complex2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Complex1X = new System.Windows.Forms.TextBox();
            this.Complex1Y = new System.Windows.Forms.TextBox();
            this.Complex2X = new System.Windows.Forms.TextBox();
            this.Complex2Y = new System.Windows.Forms.TextBox();
            this.ClearMessageBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonAdd.Location = new System.Drawing.Point(320, 25);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(46, 46);
            this.ButtonAdd.TabIndex = 0;
            this.ButtonAdd.Text = "+";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonSubtract
            // 
            this.ButtonSubtract.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSubtract.Location = new System.Drawing.Point(372, 25);
            this.ButtonSubtract.Name = "ButtonSubtract";
            this.ButtonSubtract.Size = new System.Drawing.Size(46, 46);
            this.ButtonSubtract.TabIndex = 1;
            this.ButtonSubtract.Text = "-";
            this.ButtonSubtract.UseVisualStyleBackColor = true;
            this.ButtonSubtract.Click += new System.EventHandler(this.ButtonSubtract_Click);
            // 
            // ButtonMultiply
            // 
            this.ButtonMultiply.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonMultiply.Location = new System.Drawing.Point(320, 77);
            this.ButtonMultiply.Name = "ButtonMultiply";
            this.ButtonMultiply.Size = new System.Drawing.Size(46, 46);
            this.ButtonMultiply.TabIndex = 2;
            this.ButtonMultiply.Text = "*";
            this.ButtonMultiply.UseVisualStyleBackColor = true;
            this.ButtonMultiply.Click += new System.EventHandler(this.ButtonMultiply_Click);
            // 
            // ButtonDivide
            // 
            this.ButtonDivide.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDivide.Location = new System.Drawing.Point(372, 77);
            this.ButtonDivide.Name = "ButtonDivide";
            this.ButtonDivide.Size = new System.Drawing.Size(46, 46);
            this.ButtonDivide.TabIndex = 3;
            this.ButtonDivide.Text = "÷";
            this.ButtonDivide.UseVisualStyleBackColor = true;
            this.ButtonDivide.Click += new System.EventHandler(this.ButtonDivide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Комплексне число 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Комплексне число 2:";
            // 
            // Complex1
            // 
            this.Complex1.BackColor = System.Drawing.SystemColors.Window;
            this.Complex1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Complex1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Complex1.Location = new System.Drawing.Point(181, 25);
            this.Complex1.Name = "Complex1";
            this.Complex1.ReadOnly = true;
            this.Complex1.Size = new System.Drawing.Size(98, 20);
            this.Complex1.TabIndex = 9;
            // 
            // Complex2
            // 
            this.Complex2.BackColor = System.Drawing.SystemColors.Window;
            this.Complex2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Complex2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Complex2.Location = new System.Drawing.Point(181, 64);
            this.Complex2.Name = "Complex2";
            this.Complex2.ReadOnly = true;
            this.Complex2.Size = new System.Drawing.Size(98, 20);
            this.Complex2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Центр повідомлень:";
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Window;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageBox.Location = new System.Drawing.Point(52, 103);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MessageBox.Size = new System.Drawing.Size(227, 103);
            this.MessageBox.TabIndex = 13;
            this.MessageBox.Text = "";
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.SystemColors.Window;
            this.ResultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultBox.Location = new System.Drawing.Point(320, 142);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(98, 20);
            this.ResultBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Результат:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Операції:";
            // 
            // Complex1X
            // 
            this.Complex1X.Location = new System.Drawing.Point(52, 25);
            this.Complex1X.Name = "Complex1X";
            this.Complex1X.Size = new System.Drawing.Size(46, 20);
            this.Complex1X.TabIndex = 17;
            this.Complex1X.TextChanged += new System.EventHandler(this.Complex1X_TextChanged);
            this.Complex1X.Leave += new System.EventHandler(this.Complex1X_Leave);
            // 
            // Complex1Y
            // 
            this.Complex1Y.Location = new System.Drawing.Point(104, 25);
            this.Complex1Y.Name = "Complex1Y";
            this.Complex1Y.Size = new System.Drawing.Size(46, 20);
            this.Complex1Y.TabIndex = 18;
            this.Complex1Y.TextChanged += new System.EventHandler(this.Complex1Y_TextChanged);
            this.Complex1Y.Leave += new System.EventHandler(this.Complex1Y_Leave);
            // 
            // Complex2X
            // 
            this.Complex2X.Location = new System.Drawing.Point(52, 64);
            this.Complex2X.Name = "Complex2X";
            this.Complex2X.Size = new System.Drawing.Size(46, 20);
            this.Complex2X.TabIndex = 19;
            this.Complex2X.TextChanged += new System.EventHandler(this.Complex2X_TextChanged);
            this.Complex2X.Leave += new System.EventHandler(this.Complex2X_Leave);
            // 
            // Complex2Y
            // 
            this.Complex2Y.Location = new System.Drawing.Point(104, 64);
            this.Complex2Y.Name = "Complex2Y";
            this.Complex2Y.Size = new System.Drawing.Size(46, 20);
            this.Complex2Y.TabIndex = 20;
            this.Complex2Y.TextChanged += new System.EventHandler(this.Complex2Y_TextChanged);
            this.Complex2Y.Leave += new System.EventHandler(this.Complex2Y_Leave);
            // 
            // ClearMessageBox
            // 
            this.ClearMessageBox.Location = new System.Drawing.Point(320, 168);
            this.ClearMessageBox.Name = "ClearMessageBox";
            this.ClearMessageBox.Size = new System.Drawing.Size(98, 38);
            this.ClearMessageBox.TabIndex = 21;
            this.ClearMessageBox.Text = "Очистити повідомлення";
            this.ClearMessageBox.UseVisualStyleBackColor = true;
            this.ClearMessageBox.Click += new System.EventHandler(this.ClearMessageBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 221);
            this.Controls.Add(this.ClearMessageBox);
            this.Controls.Add(this.Complex2Y);
            this.Controls.Add(this.Complex2X);
            this.Controls.Add(this.Complex1Y);
            this.Controls.Add(this.Complex1X);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Complex2);
            this.Controls.Add(this.Complex1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonDivide);
            this.Controls.Add(this.ButtonMultiply);
            this.Controls.Add(this.ButtonSubtract);
            this.Controls.Add(this.ButtonAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonSubtract;
        private System.Windows.Forms.Button ButtonMultiply;
        private System.Windows.Forms.Button ButtonDivide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Complex1;
        private System.Windows.Forms.TextBox Complex2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox MessageBox;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Complex1X;
        private System.Windows.Forms.TextBox Complex1Y;
        private System.Windows.Forms.TextBox Complex2X;
        private System.Windows.Forms.TextBox Complex2Y;
        private System.Windows.Forms.Button ClearMessageBox;
    }
}

