using static テトリス.定義;

namespace テトリス
{
    public abstract class テトリミノBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract Brush Color { get; }

        protected abstract ブロック[] ブロック0度 { get; }
        protected abstract ブロック[] ブロック90度 { get; }
        protected abstract ブロック[] ブロック180度 { get; }
        protected abstract ブロック[] ブロック270度 { get; }

        private int 角度 { get; set; }
        private ブロック[] 今のブロック => 指定の角度のブロックを取得(角度);

        public bool 背景にぶつかってるか(背景 block)
        {
            foreach (var part in 今のブロック)
            {
                var x = part.X + X;
                var y = part.Y + Y;
                if (block.背景データ[y][x] != null) return true;
            }
            return false;
        }

        public void 右に回す(背景 block)
        {
            var 新しい角度 = 角度;
            新しい角度 -= 90;
            if (新しい角度 < 0) 新しい角度 = 270;

            var 回転後の部品 = 指定の角度のブロックを取得(新しい角度);

            foreach (var part in 回転後の部品)
            {
                var x = part.X + X;
                var y = part.Y + Y;
                if (x < 0) return;
                if (y < 0) return;
                if (横のブロック数 <= x) return;
                if (縦のブロック数 <= y) return;
                if (block.背景データ[y][x] != null) return;
            }

            角度 = 新しい角度;

        }

        public void 左に回す(背景 block)
        {
            var 新しい角度 = 角度;
            新しい角度 += 90;
            if (新しい角度 > 270) 新しい角度 = 0;
            var 回転後の部品 = 指定の角度のブロックを取得(新しい角度);

            foreach (var part in 回転後の部品)
            {
                var x = part.X + X;
                var y = part.Y + Y;
                if (x < 0) return;
                if (y < 0) return;
                if (横のブロック数 <= x) return;
                if (縦のブロック数 <= y) return;
                if (block.背景データ[y][x] != null) return;
            }

            角度 = 新しい角度;
        }

        public Point[] 座標を取得()
        {
            var 座標 = new Point[今のブロック.Length];
            for (int i = 0; i < 今のブロック.Length; i++)
            {
                var 部品 = 今のブロック[i];
                座標[i] = new Point(部品.X + X, 部品.Y + Y);
            }
            return 座標;
        }

        public void 絵を描く(Graphics g)
        {
            foreach (var part in 今のブロック)
            {
                var xPic = (part.X + X) * Side;
                var yPic = (part.Y + Y) * Side;
                g.FillRectangle(Color, new Rectangle(xPic, yPic, Side, Side));
                g.DrawRectangle(Pens.White, new Rectangle(xPic, yPic, Side, Side));
            }
        }

        public void 左に行く(背景 block)
        {
            foreach (var part in 今のブロック)
            {
                var x = part.X + X - 1;
                var y = part.Y + Y;
                if (x < 0) return;
                if (block.背景データ[y][x] != null) return;

            }

            X -= 1;
        }

        public void 右に行く(背景 block)
        {
            foreach (var part in 今のブロック)
            {
                var x = part.X + X + 1;
                var y = part.Y + Y;
                if (横のブロック数 <= x) return;
                if (block.背景データ[y][x] != null) return;

            }

            X += 1;
        }

        public bool 下に行く(背景 block)
        {
            foreach (var part in 今のブロック)
            {

                var x = part.X + X;
                var y = part.Y + Y + 1;
                if (縦のブロック数 <= y) return false;
                if (block.背景データ[y][x] != null) return false;

            }

            Y += 1;
            return true;
        }

        private ブロック[] 指定の角度のブロックを取得(int angle)
        {
            switch (angle)
            {
                case 0: return ブロック0度;
                case 90: return ブロック90度;
                case 180: return ブロック180度;
                case 270: return ブロック270度;
            }
            return ブロック0度;
        }
    }
}
