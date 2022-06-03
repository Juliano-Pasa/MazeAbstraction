namespace MazeAbstraction.Tools.GraphTools
{
    public interface ILink
    {
        public List<INode> GetExtremesNodes();
        public INode GetNeighbourOf(int nodeId);
    }
}