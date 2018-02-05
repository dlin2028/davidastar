using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAStar
{
    class Graph<T>
    {
        public Dictionary<T, Vertex<T>> Verticies;

        private List<Vertex<T>> verticies;

        public Graph(List<Vertex<T>> initialNodes)
        {
            verticies = initialNodes;
            Verticies = new Dictionary<T, Vertex<T>>();

            foreach (Vertex<T> vertex in verticies)
            {
                Verticies.Add(vertex.Item, vertex);
            }
        }

        public Edge<T> AddPair(T a, T b)
        {
            return AddPair(Verticies[a], Verticies[b]);
        }
        public Edge<T> AddPair(Vertex<T> a, Vertex<T> b)
        {
            try
            {
                return a.AddEdge(b);
            }
            catch
            {
                return null;
            }
        }

        public void AddVertex(Vertex<T> vertex)
        {
            verticies.Add(vertex);
            Verticies.Add(vertex.Item, vertex);
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (verticies.Contains(vertex))
            {
                vertex.RemoveEdges();
                verticies.Remove(vertex);
                return true;
            }
            return false;
        }

        public void RemoveEdge(T a, T b)
        {
            Vertex<T> vertexA = Verticies[a];
            Vertex<T> vertexB = Verticies[b];

            for (int i = 0; i < vertexA.Edges.Count; i++)
            {
                if (vertexA.Edges[i].A == vertexA && vertexA.Edges[i].B == vertexB)
                {
                    vertexA.Edges.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < vertexB.Edges.Count; i++)
            {
                if (vertexB.Edges[i].A == vertexA && vertexB.Edges[i].B == vertexB)
                {
                    vertexB.Edges.RemoveAt(i);
                    break;
                }
            }
        }
        public void RemoveEdge(Edge<T> edge)
        {
            foreach (Vertex<T> vertex in verticies)
            {
                if (vertex.Edges.Contains(edge))
                {
                    vertex.Edges.Remove(edge);
                }
            }
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return verticies.Contains(vertex);
        }

        public Stack<Vertex<T>> GetPathTo(T start, T end)
        {
            FindPath(Verticies[start], Verticies[end]);
            return GetPath(end);
        }


        public void FindPath(Vertex<T> start, Vertex<T> finish)
        {
            foreach (Vertex<T> v in verticies)
            {
                v.Distance = int.MaxValue;
                v.Host = null;
                v.Visited = false;
            }
            start.Distance = 0;

            SortedList<float, Vertex<T>> nextNodes;
            nextNodes = new SortedList<float, Vertex<T>>();

            nextNodes.Add(start.Heuristic, start);

            while (nextNodes.Count > 0)
            {
                Vertex<T> currentNode = nextNodes.Values[0];
                nextNodes.RemoveAt(0);

                currentNode.Visited = true;

                if (currentNode == finish)
                {
                    break;
                }

                foreach (Edge<T> edge in currentNode.Edges)
                {
                    Vertex<T> friend = edge.B;
                    if (edge.B == currentNode)
                    {
                        continue;
                    }
                    Console.Write(friend.Item);

                    if (friend.Visited) continue;

                    float newDistance = currentNode.Distance + edge.Weight;
                    if (friend.Distance > newDistance)
                    {
                        friend.Host = currentNode;
                        friend.Distance = newDistance;
                        friend.Heuristic = friend.Position.Distance(finish.Position);
                    }

                    if (!nextNodes.ContainsValue(friend))
                    {
                        nextNodes.Add(friend.distic, friend);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("OUTPUT");
            Console.WriteLine("--------------");
            //construct path
        }


        public Stack<Vertex<T>> GetPath(T key)
        {
            return GetPath(Verticies[key]);
        }
        public Stack<Vertex<T>> GetPath(Vertex<T> vertex)
        {
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();

            stack.Push(vertex);
            while (vertex.Host != null)
            {
                stack.Push(vertex.Host);
                vertex = vertex.Host;
            }
            return stack;
        }
    }
}
