namespace WeatherApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            CityNameLabel = new Label();
            CityCombo = new ComboBox();
            pictureBox1 = new PictureBox();
            ExitButton = new PictureBox();
            StatusPictureBox = new PictureBox();
            WeatherStatusLabel = new Label();
            TemparatureLabel = new Label();
            DateLabel = new Label();
            label2 = new Label();
            DNPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StatusPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DNPictureBox).BeginInit();
            SuspendLayout();
            // 
            // CityNameLabel
            // 
            CityNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CityNameLabel.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            CityNameLabel.Location = new Point(0, 119);
            CityNameLabel.Name = "CityNameLabel";
            CityNameLabel.Size = new Size(480, 49);
            CityNameLabel.TabIndex = 2;
            CityNameLabel.Text = "0";
            CityNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CityCombo
            // 
            CityCombo.BackColor = Color.FromArgb(229, 225, 218);
            CityCombo.ForeColor = Color.FromArgb(52, 49, 49);
            CityCombo.FormattingEnabled = true;
            CityCombo.ItemHeight = 20;
            CityCombo.Location = new Point(12, 75);
            CityCombo.MaxDropDownItems = 4;
            CityCombo.MaxLength = 100;
            CityCombo.Name = "CityCombo";
            CityCombo.Size = new Size(456, 28);
            CityCombo.TabIndex = 1;
            CityCombo.SelectedIndexChanged += City_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(480, 70);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Image = (Image)resources.GetObject("ExitButton.Image");
            ExitButton.Location = new Point(421, 8);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(52, 52);
            ExitButton.SizeMode = PictureBoxSizeMode.StretchImage;
            ExitButton.TabIndex = 5;
            ExitButton.TabStop = false;
            ExitButton.Click += pictureBox2_Click;
            // 
            // StatusPictureBox
            // 
            StatusPictureBox.Location = new Point(150, 189);
            StatusPictureBox.Name = "StatusPictureBox";
            StatusPictureBox.Size = new Size(180, 140);
            StatusPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            StatusPictureBox.TabIndex = 6;
            StatusPictureBox.TabStop = false;
            // 
            // WeatherStatusLabel
            // 
            WeatherStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WeatherStatusLabel.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            WeatherStatusLabel.Location = new Point(0, 352);
            WeatherStatusLabel.Name = "WeatherStatusLabel";
            WeatherStatusLabel.Size = new Size(480, 49);
            WeatherStatusLabel.TabIndex = 3;
            WeatherStatusLabel.Text = "0";
            WeatherStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TemparatureLabel
            // 
            TemparatureLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TemparatureLabel.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            TemparatureLabel.Location = new Point(0, 426);
            TemparatureLabel.Name = "TemparatureLabel";
            TemparatureLabel.Size = new Size(480, 49);
            TemparatureLabel.TabIndex = 4;
            TemparatureLabel.Text = "0";
            TemparatureLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Font = new Font("Calibri", 22.2F);
            DateLabel.Location = new Point(287, 586);
            DateLabel.Margin = new Padding(0);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(198, 45);
            DateLabel.TabIndex = 6;
            DateLabel.Text = "yyyy.mm.gg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 22.2F);
            label2.Location = new Point(181, 587);
            label2.Name = "label2";
            label2.Size = new Size(111, 45);
            label2.TabIndex = 5;
            label2.Text = "Tarih :";
            // 
            // DNPictureBox
            // 
            DNPictureBox.Location = new Point(12, 488);
            DNPictureBox.Name = "DNPictureBox";
            DNPictureBox.Size = new Size(130, 130);
            DNPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            DNPictureBox.TabIndex = 11;
            DNPictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 240, 232);
            ClientSize = new Size(480, 630);
            Controls.Add(DNPictureBox);
            Controls.Add(WeatherStatusLabel);
            Controls.Add(TemparatureLabel);
            Controls.Add(label2);
            Controls.Add(DateLabel);
            Controls.Add(StatusPictureBox);
            Controls.Add(ExitButton);
            Controls.Add(pictureBox1);
            Controls.Add(CityCombo);
            Controls.Add(CityNameLabel);
            ForeColor = Color.FromArgb(52, 49, 49);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(480, 630);
            MinimizeBox = false;
            MinimumSize = new Size(480, 630);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WeatherApp";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown_1;
            MouseMove += Form1_MouseMove_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)StatusPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)DNPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label CityNameLabel;
        private ComboBox CityCombo;
        private PictureBox pictureBox1;
        private PictureBox ExitButton;
        private PictureBox StatusPictureBox;
        private Label WeatherStatusLabel;
        private Label TemparatureLabel;
        private Label DateLabel;
        private Label label2;
        private PictureBox DNPictureBox;
    }
}
