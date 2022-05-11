using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.GraphTools
{
    public class Graph
    {
        private List<Node> graph;

        public Graph(){
            graph = new List<Node>();
        }

        public void AddNode(Node node){
            graph.Add(node);
        }

        public void RemoveNode(Node node){
            if (node == null) return;

            graph.ForEach(value => value.RemoveLinkWith(node));            
            graph.Remove(node);
        }

        public void RemoveNode(int nodeId){
            Node node = GetNode(nodeId);
            RemoveNode(node);
        }

        public bool HasNode(Node node){
            return graph.Contains(node);
        }

        public bool HasNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId) != null;
        }

        public Node GetNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId);
        }

        public void CreateLinkBetween(Node startNode, Node endNode){
            if (!HasNode(startNode) || !HasNode(endNode)) return;

            Link l1 = new Link(endNode);
            Link l2 = new Link(startNode);
            startNode.AddLink(l1);
            endNode.AddLink(l2);
        }

        public void CreateLinkBetween(int startNodeId, int endNodeId){
            Node startNode = GetNode(startNodeId);
            Node endNode = GetNode(endNodeId);

            CreateLinkBetween(startNode, endNode);
        }
    }
}