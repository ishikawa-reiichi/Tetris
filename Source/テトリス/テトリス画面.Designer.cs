namespace テトリス
{
    partial class テトリス画面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(テトリス画面));
            _startButton = new Button();
            _得点 = new Label();
            _drawControl = new DrawControl();
            ((System.ComponentModel.ISupportInitialize)_drawControl).BeginInit();
            SuspendLayout();
            // 
            // _startButton
            // 
            _startButton.Location = new Point(12, 12);
            _startButton.Name = "_startButton";
            _startButton.Size = new Size(75, 23);
            _startButton.TabIndex = 1;
            _startButton.Text = "開始";
            _startButton.UseVisualStyleBackColor = true;
            _startButton.Click += _startButton_Click;
            // 
            // _得点
            // 
            _得点.AutoSize = true;
            _得点.Location = new Point(116, 16);
            _得点.Name = "_得点";
            _得点.Size = new Size(13, 15);
            _得点.TabIndex = 2;
            _得点.Text = "0";
            // 
            // _drawControl
            // 
            _drawControl.Location = new Point(10, 60);
            _drawControl.Name = "_drawControl";
            _drawControl.Size = new Size(300, 600);
            _drawControl.TabIndex = 3;
            _drawControl.TabStop = false;
            // 
            // テトリス画面
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 670);
            Controls.Add(_drawControl);
            Controls.Add(_得点);
            Controls.Add(_startButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "テトリス画面";
            ShowIcon = false;
            Text = "テトリス";
            ((System.ComponentModel.ISupportInitialize)_drawControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button _startButton;
        private Label _得点;
        private DrawControl _drawControl;
    }
}
