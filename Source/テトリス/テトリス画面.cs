namespace �e�g���X
{
    public partial class �e�g���X��� : Form
    {
        private �e�g���X�Q�[��? �Q�[�� { get; set; }

        public �e�g���X���()
        {
            InitializeComponent();

            DoubleBuffered = true;

            _drawControl.DrawCore = g =>
            {
                if (�Q�[�� == null)
                {
                    g.FillRectangle(Brushes.Black, _drawControl.ClientRectangle);
                }
                else
                { 
                    �Q�[��.�`��();
                    g.DrawImage(�Q�[��.�`��p�̃�����, new Point());
                }
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            �Q�[��?.�L�[����(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            if (_startButton.Text == "�J�n")
            {
                _startButton.Text = "�I��";
                �Q�[�� = new �e�g���X�Q�[��(�ʒm���󂯂����̏���);
                �Q�[��.�T�C�Y�ݒ�(Width, Height);
                �Q�[��.Start();
            }
            else
            {
                _startButton.Text = "�J�n";
                �Q�[��?.Dispose();
                �Q�[�� = null;
            }
            _drawControl.Invalidate();
        }

        private void �ʒm���󂯂����̏���()
        {
            _���_.Text = �Q�[��?.���_.ToString() ?? "0";
            _drawControl.Invalidate();
        }
    }
}
