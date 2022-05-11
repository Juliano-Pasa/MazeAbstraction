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

        public void removeNode(Node node){
            if (node == null) return;

            graph.ForEach(value => value.removeLinkWith(node));            
            graph.Remove(node);
        }

        public void removeNode(int nodeId){
            Node node = getNode(nodeId);
            removeNode(node);
        }

        public bool hasNode(Node node){
            return graph.Contains(node);
        }

        public bool hasNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId) != null;
        }

        public Node getNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId);
        }

        public void createLinkBetween(Node startNode, Node endNode){
            if (!hasNode(startNode) || !hasNode(endNode)) return;

            Link l1 = new Link(endNode);
            Link l2 = new Link(startNode);
            startNode.addLink(l1);
            endNode.addLink(l2);
        }

        public void createLinkBetween(int startNodeId, int endNodeId){
            Node startNode = getNode(startNodeId);
            Node endNode = getNode(endNodeId);

            createLinkBetween(startNode, endNode);
        }
    }
}