using static テトリス.定義;

namespace テトリス
{
    public class 背景
    {
        public Brush?[][] 背景データ { get; } = Enumerable.Range(0, 縦のブロック数).Select(_ => Enumerable.Range(0, 横のブロック数).Select(_ => (Brush?)null).ToArray()).ToArray();

        public void 絵を描く(Graphics g)
        {
            for (var y = 0; y < 縦のブロック数; y++)
            {
                for (var x = 0; x < 横のブロック数; x++)
                {
                    var 色 = 背景データ[y][x];
                    if (色 == null) continue;

                    var xPic = x * Side;
                    var yPic = y * Side;
                    g.FillRectangle(色, new Rectangle(xPic, yPic, Side, Side));
                    g.DrawRectangle(Pens.White, new Rectangle(xPic, yPic, Side, Side));
                }
            }
        }

        public int 追加(テトリミノBase block)
        {
            int 消した行の数 = 0;
            foreach (var 座標 in block.座標を取得())
            {
                背景データ[座標.Y][座標.X] = block.Color;
            }

            for (int y = 0; y < 背景データ.Length; y++)
            {
                var そろってる = true;
                for (int x = 0; x < 背景データ[y].Length; x++)
                {
                    if (背景データ[y][x] == null)
                    {
                        そろってる = false;
                        break;
                    }
                }
                if (そろってる)
                {
                    消した行の数++;
                    消す(y);
                }
            }

            return 消した行の数;
        }

        private void 消す(int 消すy)
        {

            for (int y = 消すy; 0 < y ; y--)
            {
                for (int x = 0; x < 背景データ[y].Length; x++)
                {
                    背景データ[y][x] = 背景データ[y - 1][x];
                }
            }

            for (int x = 0; x < 背景データ[0].Length; x++)
            {
                背景データ[0][x] = null;
            }

        }
    }
}
