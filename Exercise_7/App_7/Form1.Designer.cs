
namespace App_7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlay = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelCountx2Text = new System.Windows.Forms.Label();
            this.labelCount1Text = new System.Windows.Forms.Label();
            this.labelCountx2 = new System.Windows.Forms.Label();
            this.labelCount1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(12, 160);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(126, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Играть";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(243, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(31, 20);
            this.toolStripMenuItem1.Text = "x2";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(33, 20);
            this.toolStripMenuItem2.Text = "+1";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 189);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(127, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Сбросить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(13, 38);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(13, 15);
            this.labelOutput.TabIndex = 5;
            this.labelOutput.Text = "0";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(13, 64);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(0, 15);
            this.labelNumber.TabIndex = 6;
            // 
            // labelCountx2Text
            // 
            this.labelCountx2Text.AutoSize = true;
            this.labelCountx2Text.Location = new System.Drawing.Point(13, 93);
            this.labelCountx2Text.Name = "labelCountx2Text";
            this.labelCountx2Text.Size = new System.Drawing.Size(128, 15);
            this.labelCountx2Text.TabIndex = 7;
            this.labelCountx2Text.Text = "Количество ходов x2: ";
            // 
            // labelCount1Text
            // 
            this.labelCount1Text.AutoSize = true;
            this.labelCount1Text.Location = new System.Drawing.Point(13, 121);
            this.labelCount1Text.Name = "labelCount1Text";
            this.labelCount1Text.Size = new System.Drawing.Size(130, 15);
            this.labelCount1Text.TabIndex = 8;
            this.labelCount1Text.Text = "Количество ходов +1: ";
            // 
            // labelCountx2
            // 
            this.labelCountx2.AutoSize = true;
            this.labelCountx2.Location = new System.Drawing.Point(147, 93);
            this.labelCountx2.Name = "labelCountx2";
            this.labelCountx2.Size = new System.Drawing.Size(13, 15);
            this.labelCountx2.TabIndex = 9;
            this.labelCountx2.Text = "0";
            // 
            // labelCount1
            // 
            this.labelCount1.AutoSize = true;
            this.labelCount1.Location = new System.Drawing.Point(147, 121);
            this.labelCount1.Name = "labelCount1";
            this.labelCount1.Size = new System.Drawing.Size(13, 15);
            this.labelCount1.TabIndex = 10;
            this.labelCount1.Text = "0";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 221);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(127, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Location = new System.Drawing.Point(89, 247);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(0, 15);
            this.labelGameOver.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 268);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelCount1);
            this.Controls.Add(this.labelCountx2);
            this.Controls.Add(this.labelCount1Text);
            this.Controls.Add(this.labelCountx2Text);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelCountx2Text;
        private System.Windows.Forms.Label labelCount1Text;
        private System.Windows.Forms.Label labelCountx2;
        private System.Windows.Forms.Label labelCount1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelGameOver;
    }
}

