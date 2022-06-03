namespace MazeAbstraction.Tools.GraphTools
{
    public class Graph : IGraph
    {
        private List<INode> graph;

        public Graph(){
            graph = new List<INode>();
        }

        public void AddNode(INode node){
            graph.Add(node);
        }

        public void RemoveNode(INode node){
            if (node == null) return;

            graph.ForEach(value => value.RemoveLinkWith(node.GetId()));            
            graph.Remove(node);
        }

        public void RemoveNode(int nodeId){
            INode node = GetNode(nodeId);
            RemoveNode(node);
        }

        public bool HasNode(INode node){
            return graph.Contains(node);
        }

        public bool HasNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId) != null;
        }

        public INode GetNode(int nodeId){
            return graph.Find(value => value.GetId() == nodeId);
        }

        public void AddLinkBetween(INode startNode, INode endNode, ILink link){
            if (!HasNode(startNode) || !HasNode(endNode)) return;

            Console.WriteLine("Oi");

            startNode.AddLink(link);
            endNode.AddLink(link);
        }

        public void AddLinkBetween(int startNodeId, int endNodeId, ILink link){
            INode startNode = GetNode(startNodeId);
            INode endNode = GetNode(endNodeId);

            AddLinkBetween(startNode, endNode, link);
        }

        public int GetSize(){
            return graph.Count;
        }
    }
}