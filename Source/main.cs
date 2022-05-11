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

            graph.addNode(n1);
            graph.addNode(n2);
            graph.addNode(n3);
            graph.addNode(n4);
            graph.addNode(n5);

            graph.createLinkBetween(n1, n3);
            graph.createLinkBetween(n2, n3);
            graph.createLinkBetween(n2, n4);
            graph.createLinkBetween(n3, n4);
            graph.createLinkBetween(n4, n5);

            if (HasPath(graph, n1.GetId(), n5.GetId())) {
                Console.WriteLine("tem caminho!");
            }
        }

        public static bool HasPath(Graph graph, int startNodeId, int endNodeId){
            Node startNode = graph.getNode(startNodeId);
            Node endNode = graph.getNode(endNodeId);

            List<Node> visited = new List<Node>();
            visited.Add(startNode);
            Queue<Node> next = new Queue<Node>();
            next.Enqueue(startNode);

            while (next != null){
                Node current = next.Dequeue();
                List<Link> links = current.GetLinks();

                foreach (Link link in links){
                    if (!visited.Contains(link.getNeighbour())){
                        if (link.getNeighbour() == endNode){
                            return true;
                        }
                        next.Enqueue(link.getNeighbour());
                    }   
                }
            }
            return false;
        } 
    }
}