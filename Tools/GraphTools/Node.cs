namespace MazeAbstraction.Tools.GraphTools
{
    public class Node : INode
    {
        private List<ILink> links;
        private int id;

        public Node(int id){
            links = new List<ILink>();
            this.id = id;
        }

        public void AddLink(ILink link){
            links.Add(link);
        }

        public void RemoveLinkWith(Node linkNode){
            RemoveLinkWith(linkNode.GetId());
        }

        public void RemoveLinkWith(int nodeId){
            links.RemoveAll(l => l.GetNeighbourOf(this.id).GetId() == nodeId);
        }

        public bool HasLinkWith(Node linkNode){
            return HasLinkWith(linkNode.GetId());
        }

        public bool HasLinkWith(int nodeId){
            return links.Find(l => l.GetNeighbourOf(this.id).GetId() == nodeId) != null;
        }

        public List<ILink> GetLinks(){
            return this.links;
        }

        public ILink GetLinkWith(Node linkNode){
            return GetLinkWith(linkNode.GetId());
        }

        public ILink GetLinkWith(int nodeId){
            return links.Find(l => l.GetNeighbourOf(this.id).GetId() == nodeId);
        }

        public int GetId(){
            return this.id;
        }
    }
}