namespace テトリス
{
    public class DrawControl : PictureBox
    {
        public Action<Graphics> DrawCore { get; set; } = _ => { };

        public DrawControl() 
            => DoubleBuffered = true;

        protected override void OnPaint(PaintEventArgs e)
            => DrawCore(e.Graphics);
    }
}
