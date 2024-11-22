using System.Windows;
using System.Windows.Media;

namespace GraphApp.Models
{
    public class Node
    {
        // معرف فريد للعقدة
        public int Id { get; set; }

        // اسم العقدة (اختياري)
        public string Label { get; set; }

        // موقع العقدة على الكانفاس
        public Point Position { get; set; }

        // لون العقدة (افتراضي: رمادي)
        public Brush Color { get; set; } = Brushes.Gray;

        // حجم العقدة (قطر الدائرة)
        public double Size { get; set; } = 30;

        // كونستركتور
        public Node(int id, Point position, string label)
        {
            Id = id;
            Position = position;
            Label = label;
        }


        // دالة لتحديث الموقع
        public void UpdatePosition(double x, double y)
        {
            Position = new Point(x, y);
        }
    }
}
