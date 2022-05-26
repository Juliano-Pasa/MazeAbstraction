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

        public Node ForceGetNode(int nodeId){
            if (HasNode(nodeId)){
                return GetNode(nodeId);
            }

            Node node = new Node(nodeId);
            AddNode(node);
            return node;
        }

        public void CreateLinkBetween(Node startNode, Node endNode, List<int> intermediatePath, int linkId){
            if (!HasNode(startNode) || !HasNode(endNode)) return;

            Link link = new Link(startNode, endNode, intermediatePath, linkId);
            startNode.AddLink(link);
            endNode.AddLink(link);
        }

        public void CreateLinkBetween(int startNodeId, int endNodeId, List<int> intermediatePath, int linkId){
            Node startNode = GetNode(startNodeId);
            Node endNode = GetNode(endNodeId);

            CreateLinkBetween(startNode, endNode, intermediatePath, linkId);
        }
    }
}