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
            if (!Nodes.Any(n => n.Id == node.Id)) // التأكد من عدم وجود عقدة بنفس Id
            {
                Nodes.Add(node);
            }
        }

        // حذف عقدة
        public void RemoveNode(Node node)
        {
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
            if (!Edges.Any(e => (e.StartNode == edge.StartNode && e.EndNode == edge.EndNode) ||
                                (e.StartNode == edge.EndNode && e.EndNode == edge.StartNode))) // منع التكرار
            {
                Edges.Add(edge);
            }
        }

        // حذف حافة
        public void RemoveEdge(Edge edge)
        {
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
            return Edges.Any(e => (e.StartNode == startNode && e.EndNode == endNode) ||
                                  (e.StartNode == endNode && e.EndNode == startNode));
        }
        public Node GetNodeAtPosition(Point position)
        {
            foreach (var node in Nodes)
            {
                double distance = Math.Sqrt(Math.Pow(node.Position.X - position.X, 2) +
                                            Math.Pow(node.Position.Y - position.Y, 2));
                if (distance <= node.Size / 2)
                {
                    return node;
                }
            }
            return null;
        }

    }
}
