using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Source
{
    public class main
    {
        static void Main(){
            Graph graph = new Graph();

            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);

            graph.AddNode(n1);
            graph.AddNode(n2);
            graph.AddNode(n3);
            graph.AddNode(n4);
            graph.AddNode(n5);

            graph.CreateLinkBetween(n1, n3, new List<int>(), 0);
            graph.CreateLinkBetween(n2, n3, new List<int>(), 1);
            graph.CreateLinkBetween(n2, n4, new List<int>(), 2);
            graph.CreateLinkBetween(n3, n4, new List<int>(), 3);
            graph.CreateLinkBetween(n4, n5, new List<int>(), 4);

            if (HasPath(graph, n1.GetId(), n5.GetId())) {
                Console.WriteLine("tem caminho!");
            }
        }

        public static bool HasPath(Graph graph, int startNodeId, int endNodeId){
            Node startNode = graph.GetNode(startNodeId);
            Node endNode = graph.GetNode(endNodeId);

            List<Node> visited = new List<Node>();
            visited.Add(startNode);
            Queue<Node> next = new Queue<Node>();
            next.Enqueue(startNode);

            while (next != null){
                Node current = next.Dequeue();
                List<Link> links = current.GetLinks();
                visited.Add(current);

                foreach (Link link in links){
                    if (!visited.Contains(link.GetNeighbour(current.GetId()))){
                        if (link.GetNeighbour(current.GetId()) == endNode){
                            return true;
                        }
                        next.Enqueue(link.GetNeighbour(current.GetId()));
                    }   
                }
            }
            return false;
        } 
    }
}