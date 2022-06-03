namespace MazeAbstraction.Tools.GraphTools
{
    public interface ILink
    {
        public INode GetNeighbourOf(int nodeId);
    }
}