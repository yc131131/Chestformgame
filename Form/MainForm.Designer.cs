using System;
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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(957, 496);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.ResumeLayout(false);

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
    }
}