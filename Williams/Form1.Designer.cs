namespace Williams
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
			this.buttonStart = new System.Windows.Forms.Button();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.textBoxDivident = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(164, 81);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(172, 63);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Факторизовать";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Location = new System.Drawing.Point(120, 39);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(267, 20);
			this.textBoxNumber.TabIndex = 1;
			// 
			// textBoxDivident
			// 
			this.textBoxDivident.Location = new System.Drawing.Point(120, 187);
			this.textBoxDivident.Name = "textBoxDivident";
			this.textBoxDivident.Size = new System.Drawing.Size(267, 20);
			this.textBoxDivident.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 258);
			this.Controls.Add(this.textBoxDivident);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.buttonStart);
			this.Name = "Form1";
			this.Text = "Факторизация p+1 методом Вилльямса";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.TextBox textBoxDivident;
	}
}

