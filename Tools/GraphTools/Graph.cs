using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.GraphTools
{
    public class Graph
    {
        private List<Node> graph;

        public Graph(){
            graph = new List<Node>();
        }

        public void addNode(Node node){
            graph.Add(node);
        }

        public void removeNode(int nodeId){
            Node node = getNode(nodeId);
            if (node == null) return;

            graph.ForEach(value => value.removeLinkWith(node));            
            graph.Remove(node);
        }

        public bool hasNode(int nodeId){
            return graph.Find(value => value.getId() == nodeId) != null;
        }

        public Node getNode(int nodeId){
            return graph.Find(value => value.getId() == nodeId);
        }
    }
}