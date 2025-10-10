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
            pictureBox1 = new WinFormsApp1.PictureBoxWithInterpolationMode();
            checkBox1 = new System.Windows.Forms.CheckBox();
            cbInterpolationMode = new System.Windows.Forms.ComboBox();
            cbCompositingQuality = new System.Windows.Forms.ComboBox();
            cbCompositingMode = new System.Windows.Forms.ComboBox();
            cbPixelOffsetMode = new System.Windows.Forms.ComboBox();
            nudFrameRate = new System.Windows.Forms.NumericUpDown();
            cbC64Dither = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFrameRate).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            pictureBox1.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            pictureBox1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
            pictureBox1.Size = new System.Drawing.Size(160, 200);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            checkBox1.Location = new System.Drawing.Point(12, 460);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(87, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Show Color";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cbInterpolationMode
            // 
            cbInterpolationMode.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            cbInterpolationMode.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            cbInterpolationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbInterpolationMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            cbInterpolationMode.FormattingEnabled = true;
            cbInterpolationMode.Location = new System.Drawing.Point(162, 349);
            cbInterpolationMode.Name = "cbInterpolationMode";
            cbInterpolationMode.Size = new System.Drawing.Size(202, 23);
            cbInterpolationMode.TabIndex = 2;
            cbInterpolationMode.TabStop = false;
            cbInterpolationMode.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cbCompositingQuality
            // 
            cbCompositingQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            cbCompositingQuality.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            cbCompositingQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCompositingQuality.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            cbCompositingQuality.FormattingEnabled = true;
            cbCompositingQuality.Location = new System.Drawing.Point(162, 383);
            cbCompositingQuality.Name = "cbCompositingQuality";
            cbCompositingQuality.Size = new System.Drawing.Size(202, 23);
            cbCompositingQuality.TabIndex = 3;
            cbCompositingQuality.TabStop = false;
            // 
            // cbCompositingMode
            // 
            cbCompositingMode.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            cbCompositingMode.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            cbCompositingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCompositingMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            cbCompositingMode.FormattingEnabled = true;
            cbCompositingMode.Location = new System.Drawing.Point(162, 417);
            cbCompositingMode.Name = "cbCompositingMode";
            cbCompositingMode.Size = new System.Drawing.Size(202, 23);
            cbCompositingMode.TabIndex = 4;
            cbCompositingMode.TabStop = false;
            // 
            // cbPixelOffsetMode
            // 
            cbPixelOffsetMode.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            cbPixelOffsetMode.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            cbPixelOffsetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPixelOffsetMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            cbPixelOffsetMode.FormattingEnabled = true;
            cbPixelOffsetMode.Location = new System.Drawing.Point(162, 451);
            cbPixelOffsetMode.Name = "cbPixelOffsetMode";
            cbPixelOffsetMode.Size = new System.Drawing.Size(202, 23);
            cbPixelOffsetMode.TabIndex = 5;
            cbPixelOffsetMode.TabStop = false;
            // 
            // nudFrameRate
            // 
            nudFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            nudFrameRate.Location = new System.Drawing.Point(162, 315);
            nudFrameRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFrameRate.Name = "nudFrameRate";
            nudFrameRate.Size = new System.Drawing.Size(198, 23);
            nudFrameRate.TabIndex = 6;
            nudFrameRate.Value = new decimal(new int[] { 30, 0, 0, 0 });
            nudFrameRate.ValueChanged += nudFrameRate_ValueChanged;
            nudFrameRate.Leave += nudFrameRate_Leave;
            // 
            // cbC64Dither
            // 
            cbC64Dither.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            cbC64Dither.AutoSize = true;
            cbC64Dither.Checked = true;
            cbC64Dither.CheckState = System.Windows.Forms.CheckState.Checked;
            cbC64Dither.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            cbC64Dither.Location = new System.Drawing.Point(12, 435);
            cbC64Dither.Name = "cbC64Dither";
            cbC64Dither.Size = new System.Drawing.Size(81, 19);
            cbC64Dither.TabIndex = 7;
            cbC64Dither.Text = "C64 Dither";
            cbC64Dither.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            ClientSize = new System.Drawing.Size(372, 491);
            Controls.Add(cbC64Dither);
            Controls.Add(nudFrameRate);
            Controls.Add(cbPixelOffsetMode);
            Controls.Add(cbCompositingMode);
            Controls.Add(cbCompositingQuality);
            Controls.Add(cbInterpolationMode);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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