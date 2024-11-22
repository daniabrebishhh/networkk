using GraphApp.Models;
using GraphApp.Views;

namespace GraphApp.Controllers
{
    public class GraphController
    {
        private Graph _graph;
        private GraphCanvas _canvas;

        public GraphController(Graph graph, GraphCanvas canvas)
        {
            _graph = graph;
            _canvas = canvas;
        }

        // إضافة عقدة
        public void AddNode(Node node)
        {
            _graph.AddNode(node);
            _canvas.DrawNode(node); // تحديث الكانفاس
        }

        // حذف عقدة
        public void RemoveNode(Node node)
        {
            _graph.RemoveNode(node);
            _canvas.ClearCanvas(); // تنظيف وإعادة الرسم
            RenderGraph();
        }

        // إضافة حافة
        public void AddEdge(Edge edge)
        {
            _graph.AddEdge(edge);
            _canvas.DrawEdge(edge); // تحديث الكانفاس
        }

        // حذف حافة
        public void RemoveEdge(Edge edge)
        {
            _graph.RemoveEdge(edge);
            _canvas.ClearCanvas(); // تنظيف وإعادة الرسم
            RenderGraph();
        }

        // إعادة رسم القراف
        public void RenderGraph()
        {
            _canvas.ClearCanvas();

            foreach (var edge in _graph.Edges)
            {
                _canvas.DrawEdge(edge);
            }

            foreach (var node in _graph.Nodes)
            {
                _canvas.DrawNode(node);
            }
        }
    }
}
