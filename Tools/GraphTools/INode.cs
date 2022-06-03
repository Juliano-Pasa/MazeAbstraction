namespace MazeAbstraction.Tools.GraphTools
{
    public interface INode
    {
        public void AddLink(ILink link);
        public void RemoveLinkWith(int nodeId);
        public bool HasLinkWith(int nodeId);
        public ILink GetLinkWith(int nodeId);
        public List<ILink> GetLinks();
        public int GetId();
    }
}