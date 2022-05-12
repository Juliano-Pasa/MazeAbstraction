namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private Node neighbour;
        private List<Node> intermediateNodes;
        private int length;
        private int id;

        public Link(Node neighbour, List<Node> intermediateNodes, int id){
            this.neighbour = neighbour;
            this.intermediateNodes = intermediateNodes;
            length = intermediateNodes.Count();
            this.id = id;
        }

        public Node GetNeighbour(){
            return this.neighbour;
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