namespace MazeAbstraction.Tools.GraphTools
{
    public interface IGraph
    {
        public void AddNode(INode node);
        public void RemoveNode(INode node);
        public bool HasNode(INode node);
        public INode GetNode(int nodeId);
        public void AddLinkBetween(INode startNode, INode endNode, ILink link);

        public int GetSize();
    }
}