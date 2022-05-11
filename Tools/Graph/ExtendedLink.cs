namespace MazeAbstraction.Tools.GraphTools
{
    public class ExtendedLink : Link
    {
        private List<Node> intermediateNodes;
        private int length;
        private int id;

        public ExtendedLink(List<Node> intermediateNodes, Node neighbour, int id) : base(neighbour){
            this.intermediateNodes = intermediateNodes;
            length = intermediateNodes.Count();
            this.id = id;
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