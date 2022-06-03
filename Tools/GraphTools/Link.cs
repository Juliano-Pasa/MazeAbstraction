namespace MazeAbstraction.Tools.GraphTools
{
    public class Link : ILink
    {
        protected List<INode> extremesNodes;

        public Link(List<INode> extremeNodes){
            this.extremesNodes = extremeNodes;
        }
        
        public Link(INode node1, INode node2) : this(new List<INode>(){node1, node2}){
        }

        public INode GetNeighbourOf(int nodeId){
            return extremesNodes.Find(node => node.GetId() != nodeId);
        }
        public List<INode> GetExtremesNodes(){
            return this.extremesNodes;
        }
    }
}