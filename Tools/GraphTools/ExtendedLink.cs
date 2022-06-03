namespace MazeAbstraction.Tools.GraphTools
{
    public class ExtendedLink : ILink
    {
        protected List<INode> extremesNodes;
        private List<int> intermediatePath;
        private int length;
        private int id;

        public ExtendedLink(List<INode> extremeNodes, List<int> intermediatePath, int id){
            this.intermediatePath = intermediatePath;
            length = intermediatePath.Count();
            this.id = id;
        }
        
        public ExtendedLink(INode node1, INode node2, List<int> intermediatePath, int id) : this(new List<INode>(){node1, node2}, intermediatePath, id){
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

        public List<int> GetintermediatePath(){
            return this.intermediatePath;
        }
    }
}