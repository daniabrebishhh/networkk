using System.Windows;

namespace GraphApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNode_Click(object sender, RoutedEventArgs e)
        {
            // منطق إضافة عقدة
        }

        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            // منطق إضافة حافة
        }

        private void DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            // منطق حذف عقدة
        }

        private void DeleteEdge_Click(object sender, RoutedEventArgs e)
        {
            // منطق حذف حافة
        }

        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            // منطق مسح الشاشة
        }

        private void RunDijkstra_Click(object sender, RoutedEventArgs e)
        {
            // منطق تنفيذ خوارزمية Dijkstra
        }

        private void RunBFS_Click(object sender, RoutedEventArgs e)
        {
            // منطق تنفيذ خوارزمية BFS
        }

        private void RunDFS_Click(object sender, RoutedEventArgs e)
        {
            // منطق تنفيذ خوارزمية DFS
        }

        private void RunPrim_Click(object sender, RoutedEventArgs e)
        {
            // منطق تنفيذ خوارزمية Prim
        }

        private void RunMaxST_Click(object sender, RoutedEventArgs e)
        {
            // منطق تنفيذ الشجرة الممتدة الكبرى
        }
    }
}
