using System.Windows;
using System.Windows.Input;
using GraphApp.Models;
using GraphApp.Views;
using GraphApp.Controllers;
using System.Windows.Media;

namespace GraphApp
{
    public partial class MainWindow : Window
    {
        private Graph _graph;
        private GraphCanvas _graphCanvas;
        private GraphController _controller;

        private Node _selectedNode; // العقدة المختارة لإضافة الحافة

        public MainWindow()
        {
            InitializeComponent();

            // إعداد القراف والكانفاس والكنترول
            _graph = new Graph();
            _graphCanvas = new GraphCanvas(graphCanvas);
            _controller = new GraphController(_graph, _graphCanvas);
        }

        // عند الضغط على زر "إضافة عقدة"
        private void AddNode_Click(object sender, RoutedEventArgs e)
        {
            // نافذة إدخال اسم العقدة
            string nodeName = Microsoft.VisualBasic.Interaction.InputBox(
                "أدخل اسم العقدة:",
                "إضافة عقدة",
                "عقدة جديدة");

            if (!string.IsNullOrEmpty(nodeName))
            {
                MessageBox.Show("انقر على الكانفاس لتحديد موقع العقدة.");
                graphCanvas.MouseLeftButtonDown += AddNodeAtClick;
            }
        }

        private void AddNodeAtClick(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(graphCanvas);

            // إنشاء العقدة
            int id = _graph.Nodes.Count + 1;
            Node newNode = new Node(id, position, "Node " + id);

            // إضافة العقدة إلى القراف
            _controller.AddNode(newNode);

            // إزالة الحدث
            graphCanvas.MouseLeftButtonDown -= AddNodeAtClick;
        }

        // عند الضغط على زر "إضافة حافة"
        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedNode == null)
            {
                MessageBox.Show("انقر على العقدة الأولى.");
                graphCanvas.MouseLeftButtonDown += SelectFirstNode;
            }
            else
            {
                MessageBox.Show("انقر على العقدة الثانية.");
                graphCanvas.MouseLeftButtonDown += SelectSecondNode;
            }
        }

        private void SelectFirstNode(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(graphCanvas);
            _selectedNode = _graph.GetNodeAtPosition(position);

            if (_selectedNode != null)
            {
                MessageBox.Show($"تم اختيار العقدة: {_selectedNode.Label}");
                graphCanvas.MouseLeftButtonDown -= SelectFirstNode;
            }
        }

        private void SelectSecondNode(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(graphCanvas);
            var secondNode = _graph.GetNodeAtPosition(position);

            if (secondNode != null && _selectedNode != null)
            {
                string weightInput = Microsoft.VisualBasic.Interaction.InputBox(
                    "أدخل وزن الحافة:",
                    "إضافة حافة",
                    "1");

                int weight = int.TryParse(weightInput, out weight) ? weight : 1;

                Edge newEdge = new Edge
                {
                    StartNode = _selectedNode,
                    EndNode = secondNode,
                    Weight = weight,
                    Color = Brushes.Black,
                    Thickness = 2
                };

                // إضافة الحافة للقراف والكانفاس
                _controller.AddEdge(newEdge);

                MessageBox.Show($"تمت إضافة الحافة بين {_selectedNode.Label} و {secondNode.Label}.");

                // تنظيف الحالة
                _selectedNode = null;
                graphCanvas.MouseLeftButtonDown -= SelectSecondNode;
            }
        }

        private void DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Node clicked!");
            // أضيفي منطق حذف العقدة هنا
        }
        private void DeleteEdge_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Edge clicked!");
            // أضيفي منطق حذف الحافة هنا
        }
        private void RunDijkstra_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Run Dijkstra clicked!");
            // أضيفي منطق تشغيل خوارزمية Dijkstra هنا
        }
        // دالة مسح الشاشة
        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("مسح الشاشة!");
        }

        // دالة تشغيل خوارزمية BFS
        private void RunBFS_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("تشغيل BFS!");
        }

        // دالة تشغيل خوارزمية DFS
        private void RunDFS_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("تشغيل DFS!");
        }

        // دالة تشغيل خوارزمية Prim
        private void RunPrim_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("تشغيل Prim!");
        }

        // دالة تشغيل الشجرة الممتدة الكبرى
        private void RunMaxST_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("تشغيل الشجرة الممتدة الكبرى!");
        }

    }
}
