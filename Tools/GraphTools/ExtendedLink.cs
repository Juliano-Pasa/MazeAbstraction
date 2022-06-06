namespace MazeAbstraction.Tools.GraphTools
{
    public class ExtendedLink : ILink
    {
        protected List<INode> extremesNodes;
        private List<Point> intermediatePath;
        private int length;
        private int id;

        public ExtendedLink(List<INode> extremeNodes, List<Point> intermediatePath, int id){
            this.extremesNodes = extremeNodes;
            this.intermediatePath = intermediatePath;
            length = intermediatePath.Count();
            this.id = id;
        }
        
        public ExtendedLink(INode node1, INode node2, List<Point> intermediatePath, int id) : this(new List<INode>(){node1, node2}, intermediatePath, id){
        }

        public INode GetNeighbourOf(int nodeId){
            return extremesNodes.Find(node => node.GetId() != nodeId);
        }

        public int GetLength(){
            return this.length;
        }

        public int GetId(){
            return this.id;
        }

        public List<Point> GetintermediatePath(){
            return this.intermediatePath;
        }

        public List<INode> GetExtremesNodes(){
            return this.extremesNodes;
        }
    }
}