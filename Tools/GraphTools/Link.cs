namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private List<Node> extremesNodes;
        private List<int> intermediatePath;
        private int length;
        private int id;

        public Link(List<Node> extremeNodes, List<int> intermediatePath, int id){
            this.extremesNodes = extremeNodes;
            this.intermediatePath = intermediatePath;
            length = intermediatePath.Count();
            this.id = id;
        }
        
        public Link(Node node1, Node node2, List<int> intermediatePath, int id) : this(new List<Node>(){node1, node2}, intermediatePath, id){
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

        public List<int> GetintermediatePath(){
            return this.intermediatePath;
        }
    }
}