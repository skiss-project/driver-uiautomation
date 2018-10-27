namespace Skiss.AutomationTarget.WinForms
{
	partial class AwesomeCalculatorForm
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
			if(disposing && (components != null))
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label operation;
            this.firstOperand = new System.Windows.Forms.TextBox();
            this.secondOperand = new System.Windows.Forms.TextBox();
            this.invoke = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            operation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(243, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(13, 13);
            label1.TabIndex = 0;
            label1.Text = "=";
            // 
            // operation
            // 
            operation.AutoSize = true;
            operation.Location = new System.Drawing.Point(118, 15);
            operation.Name = "operation";
            operation.Size = new System.Drawing.Size(13, 13);
            operation.TabIndex = 5;
            operation.Text = "+";
            // 
            // firstOperand
            // 
            this.firstOperand.Location = new System.Drawing.Point(12, 12);
            this.firstOperand.Name = "firstOperand";
            this.firstOperand.Size = new System.Drawing.Size(100, 20);
            this.firstOperand.TabIndex = 1;
            // 
            // secondOperand
            // 
            this.secondOperand.Location = new System.Drawing.Point(137, 12);
            this.secondOperand.Name = "secondOperand";
            this.secondOperand.Size = new System.Drawing.Size(100, 20);
            this.secondOperand.TabIndex = 2;
            // 
            // invoke
            // 
            this.invoke.Location = new System.Drawing.Point(200, 38);
            this.invoke.Name = "invoke";
            this.invoke.Size = new System.Drawing.Size(75, 23);
            this.invoke.TabIndex = 3;
            this.invoke.Text = "Go do!";
            this.invoke.UseVisualStyleBackColor = true;
            this.invoke.Click += new System.EventHandler(this.InvokeClick);
            // 
            // results
            // 
            this.results.AutoSize = true;
            this.results.Location = new System.Drawing.Point(262, 15);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(13, 13);
            this.results.TabIndex = 6;
            this.results.Text = "?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 74);
            this.Controls.Add(this.results);
            this.Controls.Add(operation);
            this.Controls.Add(this.invoke);
            this.Controls.Add(this.secondOperand);
            this.Controls.Add(this.firstOperand);
            this.Controls.Add(label1);
            this.Name = "Form1";
            this.Text = "Calculator!!!1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox firstOperand;
		private System.Windows.Forms.TextBox secondOperand;
		private System.Windows.Forms.Button invoke;
		private System.Windows.Forms.Label results;
	}
}

