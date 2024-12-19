using System;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Windows.Forms;
namespace P230611988
{
    
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(588, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(957, 496);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);

            label1.Size = new Size(300, 200);
            label1 .AutoSize = false;
            label1.ForeColor = System.Drawing.Color.White;
            label1.Font = new Font(label1.Font.Name, 16);
            label1.Text = "";




            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public System.Windows.Forms.PictureBox _turnMessagePictureBox;
        public System.Windows.Forms.PictureBox _playerPictureBox;
        public System.Windows.Forms.PictureBox _BajiePictureBox;
        public System.Windows.Forms.PictureBox _TangSengPictureBox;
        public System.Windows.Forms.PictureBox _HonghaierPictureBox;
        public System.Windows.Forms.PictureBox _ErLangShengPictureBox;
        public System.Windows.Forms.PictureBox _HeiXiongPictureBox;
        public System.Windows.Forms.Button _AttackRangePictureBox;
        public System.Windows.Forms.Label PlayerSkillInfoLabel;
        public System.Windows.Forms.PictureBox _AARangePictureBox;
        public System.Windows.Forms.PictureBox _TangSengAPictureBox;
        public System.Windows.Forms.PictureBox _AHealPictureBox;
        public System.Windows.Forms.PictureBox _PBuffPictureBox;
        #endregion

        public Label label1;
    }
}