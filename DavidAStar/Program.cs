using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAStar
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph<string> graph;

            graph = new Graph<string>(new List<Vertex<string>>());

            while (true)
            {
                Console.Write("Operation: ");
                string input = Console.ReadLine().ToLower();


                if (input == "addpair")
                {
                    Console.Write("Node A: ");
                    string nodeA = Console.ReadLine();
                    Console.Write("Node B: ");
                    string nodeB = Console.ReadLine();

                    //calculate distance and say what it is
                    Console.WriteLine("Calculated Distance");
                    Console.WriteLine(graph.AddPair(nodeA, nodeB).Weight);
                    
                    Console.WriteLine("Done");
                }
                else if (input == "removepair")
                {
                    Console.Write("Node A: ");
                    string nodeA = Console.ReadLine();
                    Console.Write("Node B: ");
                    string nodeB = Console.ReadLine();
                    graph.RemoveEdge(nodeA, nodeB);
                    Console.WriteLine("Done");
                }
                else if (input == "addvertex")
                {
                    Console.Write("Value: ");
                    string value = Console.ReadLine();
                    Console.Write("Position X: ");
                    float posX = float.Parse(Console.ReadLine());
                    Console.Write("Posision Y: ");
                    float posY = float.Parse(Console.ReadLine());

                    graph.AddVertex(new Vertex<string>(value, posX, posY));
                    Console.WriteLine("Done");
                }
                else if (input == "removevertex")
                {
                    Console.Write("value: ");
                    string value = Console.ReadLine();
                    if (graph.RemoveVertex(new Vertex<string>(value)))
                    {
                        Console.WriteLine("Done");
                    }
                    else
                    {
                        Console.WriteLine("Vertex not found");
                    }
                }
                else if (input == "hasvertex")
                {
                    Console.Write("value: ");
                    string value = Console.ReadLine();
                    Console.WriteLine(graph.HasVertex(new Vertex<string>(value)));

                }
                else if(input == "path")
                {
                    Console.Write("Start Node: ");
                    string start = Console.ReadLine();
                    Console.Write("End Node: ");
                    string end = Console.ReadLine();

                    Stack<Vertex<string>> stack = graph.GetPathTo(start, end);
                    
                    if(stack.Count == 1)
                    {
                        Console.WriteLine("No path found");
                        continue;
                    }

                    while(stack.Count > 0)
                    {
                        Console.WriteLine(stack.Pop().Item);
                    }
                }
                else if(input == "lazy")
                {
                    graph.AddVertex(new Vertex<string>("a", 0, 0));
                    graph.AddVertex(new Vertex<string>("b", 5, 0));
                    graph.AddVertex(new Vertex<string>("c", 5, 4));
                    graph.AddVertex(new Vertex<string>("d", 5, 5));
                    graph.AddVertex(new Vertex<string>("e", 4, 4));
                    graph.AddVertex(new Vertex<string>("f", 5, 100));
                    graph.AddPair("a", "b");
                    graph.AddPair("b", "c");
                    graph.AddPair("c", "d");
                    graph.AddPair("a", "e");
                    graph.AddPair("f", "d");
                    graph.AddPair("e", "f");
                }
                else
                {
                    Console.WriteLine("Available commands: addpair addvertex removevertex hasvertex depth breadth");
                }
            }
        }
    }
}
