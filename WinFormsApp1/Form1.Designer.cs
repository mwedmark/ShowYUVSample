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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFrameRate).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            pictureBox1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
            pictureBox1.Size = new Size(352, 288);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.ForeColor = SystemColors.AppWorkspace;
            checkBox1.Location = new Point(12, 455);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(107, 24);
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
            cbInterpolationMode.Location = new Point(162, 349);
            cbInterpolationMode.Name = "cbInterpolationMode";
            cbInterpolationMode.Size = new Size(202, 28);
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
            cbCompositingQuality.Location = new Point(162, 383);
            cbCompositingQuality.Name = "cbCompositingQuality";
            cbCompositingQuality.Size = new Size(202, 28);
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
            cbCompositingMode.Location = new Point(162, 417);
            cbCompositingMode.Name = "cbCompositingMode";
            cbCompositingMode.Size = new Size(202, 28);
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
            cbPixelOffsetMode.Location = new Point(162, 451);
            cbPixelOffsetMode.Name = "cbPixelOffsetMode";
            cbPixelOffsetMode.Size = new Size(202, 28);
            cbPixelOffsetMode.TabIndex = 5;
            cbPixelOffsetMode.TabStop = false;
            // 
            // nudFrameRate
            // 
            nudFrameRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nudFrameRate.Location = new Point(162, 315);
            nudFrameRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFrameRate.Name = "nudFrameRate";
            nudFrameRate.Size = new Size(198, 27);
            nudFrameRate.TabIndex = 6;
            nudFrameRate.Value = new decimal(new int[] { 30, 0, 0, 0 });
            nudFrameRate.ValueChanged += nudFrameRate_ValueChanged;
            nudFrameRate.Leave += nudFrameRate_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(372, 491);
            Controls.Add(nudFrameRate);
            Controls.Add(cbPixelOffsetMode);
            Controls.Add(cbCompositingMode);
            Controls.Add(cbCompositingQuality);
            Controls.Add(cbInterpolationMode);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
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

        #endregion

        private PictureBoxWithInterpolationMode pictureBox1;
        private CheckBox checkBox1;
        private ComboBox cbInterpolationMode;
        private ComboBox cbCompositingQuality;
        private ComboBox cbCompositingMode;
        private ComboBox cbPixelOffsetMode;
        private NumericUpDown nudFrameRate;
    }
}