using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAStar
{
    class Edge<T>
    {
        public Vertex<T> A;
        public Vertex<T> B;
        public float Weight;

        public Edge(Vertex<T> a, Vertex<T> b, float weight)
        {
            A = a;
            B = b;
            Weight = weight;
        }
        
        int CompareTo(Edge<T> b)
        {
            return Weight.CompareTo(b.Weight);
        }
    }
}
