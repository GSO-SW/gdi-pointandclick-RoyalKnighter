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

            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(new SolidBrush(rectanglesColors[i]), rectangles[i]);
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            int size = random.Next(100) + 5;

            Rectangle newRectangle = new Rectangle(mausposition.X - size / 2, mausposition.Y - size / 2, size, size);

            if (e.Button == MouseButtons.Left)
            {
                bool add = true;
                for (int i = rectangles.Count - 1; i >= 0; i--)
                {
                    if (rectangles[i].Contains(mausposition))
                    {
                        add = false;
                        break;
                    }
                }

                if (add)
                {
                    rectanglesColors.Add(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                    rectangles.Add(newRectangle);
                    Refresh();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = rectangles.Count - 1; i >= 0; i--)
                {
                    if (rectangles[i].Contains(mausposition))
                    {
                        rectangles.RemoveAt(i);
                        rectanglesColors.RemoveAt(i);
                        Refresh();
                        break;
                    }
                }
            }
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