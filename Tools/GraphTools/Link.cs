namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private List<Node> extremesNodes;
        private List<Node> intermediateNodes;
        private int length;
        private int id;

        public Link(List<Node> extremeNodes, List<Node> intermediateNodes, int id){
            this.extremesNodes = extremeNodes;
            this.intermediateNodes = intermediateNodes;
            length = intermediateNodes.Count();
            this.id = id;
        }
        
        public Link(Node node1, Node node2, List<Node> intermediateNodes, int id) : this(new List<Node>(){node1, node2}, intermediateNodes, id){
        }

        public Node GetNeighbour(int originalNode){
            return extremesNodes.Find(node => node.GetId() != originalNode);
        }

        public int GetLength(){
            return this.length;
        }

        public int GetId(){
            return this.id;
        }

        public List<Node> GetIntermediateNodes(){
            return this.intermediateNodes;
        }
    }
}