using static テトリス.定義;

namespace テトリス
{
    public class テトリスゲーム : IDisposable
    {
        public Bitmap 描画用のメモリ { get; private set; } = new Bitmap(1, 1);
        public int 得点 { get; private set; }
        public bool ゲームオーバー { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private System.Windows.Forms.Timer タイマー = new System.Windows.Forms.Timer { Interval = 1000 };
        private テトリミノBase? 落ちてるブロック { get; set; }
        private 背景 背景 { get; set; } = new 背景();
        private Action 通知 { get; set; }

        private static Random 乱数 { get;} = new Random();

        public テトリスゲーム(Action 通知_)
        {
            タイマー.Tick += (_, __) => 下に行く処理();
            通知 = 通知_;
        }

        public void Start()
        {
            タイマー.Start();
            if (落ちてるブロック == null) 落ちてるブロック = CreateBlock();
        }

        public void Dispose() 
        {
            タイマー.Dispose();
            描画用のメモリ.Dispose();
        }

        public void サイズ設定(int width, int height)
        {
            Width = width;
            Height = height;
            描画用のメモリ = new Bitmap(Width, Height);
        }

        public void キー処理(Keys keyData)
        {
            if (落ちてるブロック == null) return;

            if (keyData == Keys.Left)
            {
                落ちてるブロック.左に行く(背景);
                通知();
            }
            else if (keyData == Keys.Right)
            {
                落ちてるブロック.右に行く(背景);
                通知();
            }
            else if (keyData == Keys.Down)
            {
                下に行く処理();
            }
            else if (keyData == Keys.A)
            {
                落ちてるブロック.左に回す(背景);
                通知();
            }
            else if (keyData == Keys.D)
            {
                落ちてるブロック.右に回す(背景);
                通知();
            }
        }

        public void 描画()
        {
            using var g = Graphics.FromImage(描画用のメモリ);
            g.FillRectangle(Brushes.Black, 0, 0, Width, Height);

            var 画面の高さ = 縦のブロック数 * Side;
            var 画面の幅 = 横のブロック数 * Side;

            //縦線を引いている
            for (int i = 0; i <= 横のブロック数; i++)
            {
                g.DrawLine(Pens.Gray, new Point(Side * i, 0), new Point(Side * i, 画面の高さ));
            }

            //横線を引く
            for (int i = 0; i <= 縦のブロック数; i++)
            {
                g.DrawLine(Pens.Gray, new Point(0, Side * i), new Point(画面の幅, Side * i));
            }

            //背景を書く
            背景.絵を描く(g);

            if (ゲームオーバー)
            {
                g.DrawString("ゲームオーバー", new Font(FontFamily.GenericSansSerif, 30), Brushes.Red, new Point());
            }

            //ブロックを書く
            落ちてるブロック?.絵を描く(g);
        }

        private void 下に行く処理()
        {
            if (落ちてるブロック == null) return;

            if (!落ちてるブロック.下に行く(背景))
            {
                var 消した行の数 = 背景.追加(落ちてるブロック);

                switch (消した行の数)
                {
                    case 0:
                        break;
                    case 1:
                        得点 += 10;
                        break;
                    case 2:
                        得点 += 50;
                        break;
                    case 3:
                        得点 += 100;
                        break;
                    case 4:
                        得点 += 500;
                        break;
                }

                var 次のブロック = CreateBlock();
                if (次のブロック.背景にぶつかってるか(背景))
                {
                    タイマー.Dispose();
                    落ちてるブロック = null;
                    ゲームオーバー = true;
                }
                else
                {
                    落ちてるブロック = 次のブロック;
                }
            }

            //得点が0～999までのとき 1000
            if (得点 < 1000) タイマー.Interval = 1000;
            else if (得点 < 2000) タイマー.Interval = 900;
            else if (得点 < 3000) タイマー.Interval = 800;
            else if (得点 < 4000) タイマー.Interval = 700;
            else if (得点 < 5000) タイマー.Interval = 500;
            else if (得点 < 6000) タイマー.Interval = 300;
            else if (得点 < 7000) タイマー.Interval = 250;
            else if (得点 < 8000) タイマー.Interval = 1000;
            else タイマー.Interval = 250;
            //得点が1000～1999までのとき 900
            //得点が2000～2999までのとき 700
            //得点が3000～3999までのとき 600
            //得点が4000以上は500

            通知();
        }

        static テトリミノBase CreateBlock()
        {

            switch (乱数.Next(1, 8))
            {
                case 1: return new Lミノ { X = 4 };
                case 2: return new Jミノ { X = 4 };
                case 3: return new Oミノ { X = 4 };
                case 4: return new Tミノ { X = 4 };
                case 5: return new Iミノ { X = 4 };
                case 6: return new Sブロック { X = 4 };
                case 7: return new Zブロック { X = 4 };

            }
            return new Sブロック { X = 4 };
        }
    }
}
