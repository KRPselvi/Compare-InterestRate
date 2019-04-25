namespace Test
{
    partial class Form1
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
            this.GridView1 = new System.Windows.Forms.DataGridView();
            this.Btn6mthRate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView1
            // 
            this.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView1.Location = new System.Drawing.Point(12, 88);
            this.GridView1.Name = "GridView1";
            this.GridView1.Size = new System.Drawing.Size(1408, 690);
            this.GridView1.TabIndex = 0;
            // 
            // Btn6mthRate
            // 
            this.Btn6mthRate.Location = new System.Drawing.Point(24, 59);
            this.Btn6mthRate.Name = "Btn6mthRate";
            this.Btn6mthRate.Size = new System.Drawing.Size(101, 23);
            this.Btn6mthRate.TabIndex = 1;
            this.Btn6mthRate.Text = "Show 1 Month Rate";
            this.Btn6mthRate.UseVisualStyleBackColor = true;
            this.Btn6mthRate.Click += new System.EventHandler(this.Btn6MthRate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Show 10 Monthly Rate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DTFrom
            // 
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(24, 12);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.Size = new System.Drawing.Size(127, 20);
            this.DTFrom.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 742);
            this.Controls.Add(this.DTFrom);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Btn6mthRate);
            this.Controls.Add(this.GridView1);
            this.Name = "Form1";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn BkName;
        private System.Windows.Forms.Button Btn6mthRate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker DTFrom;
        //private System.Windows.Forms.DataGridViewTextBoxColumn BkName;
    }
}

