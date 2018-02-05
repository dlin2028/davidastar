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

                }
                else
                {
                    Console.WriteLine("Available commands: addpair addvertex removevertex hasvertex depth breadth");
                }
            }
        }
    }
}
