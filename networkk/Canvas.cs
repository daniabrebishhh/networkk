using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphApp.Models;

namespace GraphApp.Views
{
    public class GraphCanvas
    {
        private Canvas _canvas;

        public GraphCanvas(Canvas canvas)
        {
            _canvas = canvas;
        }

        // تنظيف الكانفاس
        public void ClearCanvas()
        {
            _canvas.Children.Clear();
        }

        // رسم عقدة
        public void DrawNode(Node node)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = node.Size,
                Height = node.Size,
                Fill = node.Color,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            Canvas.SetLeft(ellipse, node.Position.X - node.Size / 2);
            Canvas.SetTop(ellipse, node.Position.Y - node.Size / 2);

            _canvas.Children.Add(ellipse);

            if (!string.IsNullOrEmpty(node.Label))
            {
                TextBlock text = new TextBlock
                {
                    Text = node.Label,
                    Foreground = Brushes.Black,
                    FontSize = 12
                };

                Canvas.SetLeft(text, node.Position.X - text.Text.Length * 3);
                Canvas.SetTop(text, node.Position.Y - 10);

                _canvas.Children.Add(text);
            }
        }

        // رسم حافة
        public void DrawEdge(Edge edge)
        {
            Line line = new Line
            {
                X1 = edge.StartNode.Position.X,
                Y1 = edge.StartNode.Position.Y,
                X2 = edge.EndNode.Position.X,
                Y2 = edge.EndNode.Position.Y,
                Stroke = edge.Color,
                StrokeThickness = edge.Thickness
            };

            _canvas.Children.Add(line);

            if (edge.Weight > 0)
            {
                TextBlock text = new TextBlock
                {
                    Text = edge.Weight.ToString(),
                    Foreground = Brushes.Black,
                    FontSize = 12
                };

                double midX = (edge.StartNode.Position.X + edge.EndNode.Position.X) / 2;
                double midY = (edge.StartNode.Position.Y + edge.EndNode.Position.Y) / 2;

                Canvas.SetLeft(text, midX);
                Canvas.SetTop(text, midY);

                _canvas.Children.Add(text);
            }
        }
    }
}
