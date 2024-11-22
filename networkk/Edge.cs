using System.Windows.Media;

namespace GraphApp.Models
{
    public class Edge
    {
        // العقد الموصولة به الحافة
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        // وزن الحافة
        public double Weight { get; set; }

        // لون الحافة (افتراضي: أسود)
        public Brush Color { get; set; } = Brushes.Black;

        // سمك الحافة
        public double Thickness { get; set; } = 2;

        // كونستركتور
        public Edge() { }

        // دالة للتحقق إذا ما كانت الحافة بين نفس العقدتين
        public bool IsSelfLoop()
        {
            return StartNode == EndNode;
        }
    }
}
