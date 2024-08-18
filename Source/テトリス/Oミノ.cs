namespace テトリス
{
    public class Oミノ : テトリミノBase
    {
        protected override ブロック[] ブロック0度 { get; } =
        [
                new(){ X = 1, Y = 0 },
                new(){ X = 2, Y = 0 },
                new(){ X = 1, Y = 1 },
                new(){ X = 2, Y = 1 },
        ];

        protected override ブロック[] ブロック90度 => ブロック0度;
        protected override ブロック[] ブロック180度 => ブロック0度;
        protected override ブロック[] ブロック270度 => ブロック0度;

        public override Brush Color { get; } = Brushes.Gold;
    }
}