namespace テトリス
{
    public partial class テトリス画面 : Form
    {
        private テトリスゲーム? ゲーム { get; set; }

        public テトリス画面()
        {
            InitializeComponent();

            DoubleBuffered = true;

            _drawControl.DrawCore = g =>
            {
                if (ゲーム == null)
                {
                    g.FillRectangle(Brushes.Black, _drawControl.ClientRectangle);
                }
                else
                { 
                    ゲーム.描画();
                    g.DrawImage(ゲーム.描画用のメモリ, new Point());
                }
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ゲーム?.キー処理(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            if (_startButton.Text == "開始")
            {
                _startButton.Text = "終了";
                ゲーム = new テトリスゲーム(通知を受けた時の処理);
                ゲーム.サイズ設定(Width, Height);
                ゲーム.Start();
            }
            else
            {
                _startButton.Text = "開始";
                ゲーム?.Dispose();
                ゲーム = null;
            }
            _drawControl.Invalidate();
        }

        private void 通知を受けた時の処理()
        {
            _得点.Text = ゲーム?.得点.ToString() ?? "0";
            _drawControl.Invalidate();
        }
    }
}
