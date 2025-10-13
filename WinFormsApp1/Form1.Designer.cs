namespace WinFormsApp1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBoxWithInterpolationMode();
            checkBox1 = new CheckBox();
            cbInterpolationMode = new ComboBox();
            cbCompositingQuality = new ComboBox();
            cbCompositingMode = new ComboBox();
            cbPixelOffsetMode = new ComboBox();
            nudFrameRate = new NumericUpDown();
            cbC64Dither = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFrameRate).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 242);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.AppWorkspace;
            checkBox1.Location = new Point(12, 502);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Show Color";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cbInterpolationMode
            // 
            cbInterpolationMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbInterpolationMode.BackColor = SystemColors.InactiveCaptionText;
            cbInterpolationMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInterpolationMode.ForeColor = SystemColors.ControlLightLight;
            cbInterpolationMode.FormattingEnabled = true;
            cbInterpolationMode.Location = new Point(350, 391);
            cbInterpolationMode.Name = "cbInterpolationMode";
            cbInterpolationMode.Size = new Size(202, 23);
            cbInterpolationMode.TabIndex = 2;
            cbInterpolationMode.TabStop = false;
            cbInterpolationMode.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cbCompositingQuality
            // 
            cbCompositingQuality.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbCompositingQuality.BackColor = SystemColors.InactiveCaptionText;
            cbCompositingQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCompositingQuality.ForeColor = SystemColors.ControlLightLight;
            cbCompositingQuality.FormattingEnabled = true;
            cbCompositingQuality.Location = new Point(350, 425);
            cbCompositingQuality.Name = "cbCompositingQuality";
            cbCompositingQuality.Size = new Size(202, 23);
            cbCompositingQuality.TabIndex = 3;
            cbCompositingQuality.TabStop = false;
            // 
            // cbCompositingMode
            // 
            cbCompositingMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbCompositingMode.BackColor = SystemColors.InactiveCaptionText;
            cbCompositingMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCompositingMode.ForeColor = SystemColors.ControlLightLight;
            cbCompositingMode.FormattingEnabled = true;
            cbCompositingMode.Location = new Point(350, 459);
            cbCompositingMode.Name = "cbCompositingMode";
            cbCompositingMode.Size = new Size(202, 23);
            cbCompositingMode.TabIndex = 4;
            cbCompositingMode.TabStop = false;
            // 
            // cbPixelOffsetMode
            // 
            cbPixelOffsetMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbPixelOffsetMode.BackColor = SystemColors.InactiveCaptionText;
            cbPixelOffsetMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPixelOffsetMode.ForeColor = SystemColors.ControlLightLight;
            cbPixelOffsetMode.FormattingEnabled = true;
            cbPixelOffsetMode.Location = new Point(350, 493);
            cbPixelOffsetMode.Name = "cbPixelOffsetMode";
            cbPixelOffsetMode.Size = new Size(202, 23);
            cbPixelOffsetMode.TabIndex = 5;
            cbPixelOffsetMode.TabStop = false;
            // 
            // nudFrameRate
            // 
            nudFrameRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nudFrameRate.Location = new Point(350, 357);
            nudFrameRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFrameRate.Name = "nudFrameRate";
            nudFrameRate.Size = new Size(198, 23);
            nudFrameRate.TabIndex = 6;
            nudFrameRate.Value = new decimal(new int[] { 30, 0, 0, 0 });
            nudFrameRate.ValueChanged += nudFrameRate_ValueChanged;
            nudFrameRate.Leave += nudFrameRate_Leave;
            // 
            // cbC64Dither
            // 
            cbC64Dither.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbC64Dither.AutoSize = true;
            cbC64Dither.Checked = true;
            cbC64Dither.CheckState = CheckState.Checked;
            cbC64Dither.ForeColor = SystemColors.AppWorkspace;
            cbC64Dither.Location = new Point(12, 477);
            cbC64Dither.Name = "cbC64Dither";
            cbC64Dither.Size = new Size(81, 19);
            cbC64Dither.TabIndex = 7;
            cbC64Dither.Text = "C64 Dither";
            cbC64Dither.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(560, 533);
            Controls.Add(cbC64Dither);
            Controls.Add(nudFrameRate);
            Controls.Add(cbPixelOffsetMode);
            Controls.Add(cbCompositingMode);
            Controls.Add(cbCompositingQuality);
            Controls.Add(cbInterpolationMode);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            DoubleClick += Form1_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFrameRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.CheckBox cbC64Dither;

        #endregion

        private WinFormsApp1.PictureBoxWithInterpolationMode pictureBox1;
        private CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbInterpolationMode;
        private System.Windows.Forms.ComboBox cbCompositingQuality;
        private System.Windows.Forms.ComboBox cbCompositingMode;
        private System.Windows.Forms.ComboBox cbPixelOffsetMode;
        private System.Windows.Forms.NumericUpDown nudFrameRate;
    }
}