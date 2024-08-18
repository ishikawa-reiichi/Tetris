namespace テトリス
{
    public class Iミノ : テトリミノBase
    {
        protected override ブロック[] ブロック0度 { get; } =
        [
                new(){ X = 0, Y = 0 },
                new(){ X = 0, Y = 1 },
                new(){ X = 0, Y = 2 },
                new(){ X = 0, Y = 3 },
        ];
        protected override ブロック[] ブロック90度 { get; } =
        [
                new(){ X = -1, Y = 2 },
                new(){ X = 0, Y = 2 },
                new(){ X = 1, Y = 2 },
                new(){ X = 2, Y = 2 },
        ];
        protected override ブロック[] ブロック180度 { get; } =
        [
                new(){ X = 0, Y = 0 },
                new(){ X = 0, Y = 1 },
                new(){ X = 0, Y = 2 },
                new(){ X = 0, Y = 3 },
        ];
        protected override ブロック[] ブロック270度 { get; } =
        [
                new(){ X = -1, Y = 2 },
                new(){ X = 2, Y = 2 },
                new(){ X = 1, Y = 2 },
                new(){ X = 0, Y = 2 },
        ];

        public override Brush Color { get; } = Brushes.LightSkyBlue;
    }
}