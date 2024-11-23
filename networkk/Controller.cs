using GraphApp.Models;
using GraphApp.Views;
using System.Linq;

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
            // حذف الحواف المرتبطة بالعقدة
            var edgesToRemove = _graph.Edges.Where(e => e.StartNode == node || e.EndNode == node).ToList();
            foreach (var edge in edgesToRemove)
            {
                RemoveEdge(edge);
            }

            // حذف العقدة من القراف
            _graph.Nodes.Remove(node);

            // تحديث الكانفاس
            _canvas.RemoveNode(node); // استخدم _canvas بدلاً من _graphCanvas
        }

        public void RemoveEdge(Edge edge)
        {
            // حذف الحافة من القراف
            _graph.Edges.Remove(edge);

            // تحديث الكانفاس
            _canvas.RemoveEdge(edge); // استخدم _canvas بدلاً من _graphCanvas
        }

        // إضافة حافة
        public void AddEdge(Edge edge)
        {
            _graph.AddEdge(edge);
            _canvas.DrawEdge(edge); // تحديث الكانفاس
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
