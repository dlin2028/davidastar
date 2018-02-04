using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAStar
{
    class Vertex<T>
    {
        public T Item;
        public List<Edge<T>> Edges;

        public bool Visited;
        public float Distance;
        public float Heuristic;

        public float distic
        {
            get
            {
                return Distance + Heuristic;
            }
        }

        public Position Position;
        
        public Vertex<T> Host;

        public Vertex(T item)
            : this(item, new Position(0,0), new List<Edge<T>>())
        {
        }
        public Vertex(T item, List<Edge<T>> edges)
            : this(item, new Position(0, 0), edges)
        {
        }
        public Vertex(T item, float X, float Y)
            : this(item, new Position(X, Y), new List<Edge<T>>())
        {

        }
        public Vertex(T item, Position position)
            : this(item, position, new List<Edge<T>>())
        {

        }
        public Vertex(T item, Position position, List<Edge<T>> edges)
        {
            Item = item;
            Edges = edges;
            Position = position;
        }


        public Edge<T> AddEdge(Vertex<T> vertex)
        {
            foreach (Edge<T> edge in Edges)
            {
                if (edge.B == vertex)
                {
                    return null;
                }
            }
            Edge<T> newEdge = new Edge<T>(this, vertex, Position.Distance(vertex.Position));
            Edges.Add(newEdge);
            vertex.Edges.Add(newEdge);
            return newEdge;
        }

        public void RemoveEdges()
        {
            foreach (Edge<T> edge in Edges)
            {
                if (edge.A == this)
                {
                    edge.B.Edges.Remove(edge);
                }
                else
                {
                    edge.A.Edges.Remove(edge);
                }
            }
        }
    }
}
