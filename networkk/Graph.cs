using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GraphApp.Models
{
    public class Graph
    {
        // قائمة العقد
        public List<Node> Nodes { get; private set; }

        // قائمة الحواف
        public List<Edge> Edges { get; private set; }

        // كونستركتور
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        // إضافة عقدة جديدة
        public void AddNode(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node), "العقدة لا يمكن أن تكون null.");

            if (!Nodes.Any(n => n.Id == node.Id)) // التأكد من عدم وجود عقدة بنفس Id
            {
                Nodes.Add(node);
            }
        }

        // حذف عقدة
        public void RemoveNode(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node), "العقدة لا يمكن أن تكون null.");

            if (Nodes.Contains(node))
            {
                // إزالة جميع الحواف المرتبطة بالعقدة
                Edges.RemoveAll(e => e.StartNode == node || e.EndNode == node);

                // إزالة العقدة
                Nodes.Remove(node);
            }
        }

        // إضافة حافة جديدة
        public void AddEdge(Edge edge)
        {
            if (edge == null)
                throw new ArgumentNullException(nameof(edge), "الحافة لا يمكن أن تكون null.");

            // التأكد من عدم وجود حافة مشابهة مسبقًا
            if (!Edges.Any(e => AreEdgesEquivalent(e, edge)))
            {
                Edges.Add(edge);
            }
        }
        public Edge GetEdgeAtPosition(Point position)
        {
            double tolerance = 5.0; // مدى التسامح في المسافة لاعتبار النقطة قريبة من الحافة
            foreach (var edge in Edges)
            {
                // نحصل على النقاط النهائية للحافة
                var start = edge.StartNode.Position;
                var end = edge.EndNode.Position;

                // نتحقق إذا كانت النقطة قريبة من الحافة
                if (IsPointNearLine(position, start, end, tolerance))
                {
                    return edge;
                }
            }
            return null; // إذا لم يتم العثور على حافة
        }

        // دالة للتحقق إذا كانت النقطة قريبة من خط مستقيم
        private bool IsPointNearLine(Point point, Point lineStart, Point lineEnd, double tolerance)
        {
            double distance = Math.Abs((lineEnd.Y - lineStart.Y) * point.X -
                                       (lineEnd.X - lineStart.X) * point.Y +
                                       lineEnd.X * lineStart.Y -
                                       lineEnd.Y * lineStart.X) /
                              Math.Sqrt(Math.Pow(lineEnd.Y - lineStart.Y, 2) +
                                        Math.Pow(lineEnd.X - lineStart.X, 2));
            return distance <= tolerance;
        }


        // حذف حافة
        public void RemoveEdge(Edge edge)
        {
            if (edge == null)
                throw new ArgumentNullException(nameof(edge), "الحافة لا يمكن أن تكون null.");

            if (Edges.Contains(edge))
            {
                Edges.Remove(edge);
            }
        }

        // البحث عن عقدة بالمعرف
        public Node GetNodeById(int id)
        {
            return Nodes.FirstOrDefault(n => n.Id == id);
        }

        // التحقق إذا كان هناك حافة بين عقدتين
        public bool HasEdge(Node startNode, Node endNode)
        {
            return Edges.Any(e => AreNodesConnected(e, startNode, endNode));
        }

        // البحث عن عقدة بالنقر على موقع
        public Node GetNodeAtPosition(Point position)
        {
            foreach (var node in Nodes)
            {
                double distance = Math.Sqrt(Math.Pow(node.Position.X - position.X, 2) +
                                            Math.Pow(node.Position.Y - position.Y, 2));
                if (distance <= node.Size / 2) // تحقق من أن النقطة داخل نطاق العقدة
                {
                    return node;
                }
            }
            return null;
        }

        // التحقق إذا كانت الحافتان متكافئتين (بين نفس العقدتين)
        private bool AreEdgesEquivalent(Edge edge1, Edge edge2)
        {
            return (edge1.StartNode == edge2.StartNode && edge1.EndNode == edge2.EndNode) ||
                   (edge1.StartNode == edge2.EndNode && edge1.EndNode == edge2.StartNode);
        }

        // التحقق إذا كانت الحافة تربط بين عقدتين معينتين
        private bool AreNodesConnected(Edge edge, Node startNode, Node endNode)
        {
            return (edge.StartNode == startNode && edge.EndNode == endNode) ||
                   (edge.StartNode == endNode && edge.EndNode == startNode);
        }

    }
}
