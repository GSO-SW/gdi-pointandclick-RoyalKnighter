using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Color> rectanglesColors = new List<Color>();
        Random random = new Random();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(new SolidBrush(rectanglesColors[i]), rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            int size = random.Next(100) + 5;

            Rectangle r = new Rectangle(mausposition.X - size / 2, mausposition.Y - size / 2, size, size);
            rectanglesColors.Add(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));

            if (!rectangles.Contains(r))
            {
                rectangles.Add(r);  // Kurze Variante: rectangles.Add( new Rectangle(...)  );
            }

            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}