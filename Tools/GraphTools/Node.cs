namespace MazeAbstraction.Tools.GraphTools
{
    public class Node
    {
        private List<Link> links;
        private int id;

        public Node(int id){
            links = new List<Link>();
            this.id = id;
        }

        public void AddLink(Link link){
            links.Add(link);
        }

        public void RemoveLinkWith(Node linkNode){
            RemoveLinkWith(linkNode.GetId());
        }

        public void RemoveLinkWith(int nodeId){
            links.RemoveAll(v => v.GetNeighbour().GetId() == nodeId);
        }

        public bool HasLinkWith(Node linkNode){
            return HasLinkWith(linkNode.GetId());
        }

        public bool HasLinkWith(int nodeId){
            return links.Find(v => v.GetNeighbour().GetId() == nodeId) != null;
        }

        public List<Link> GetLinks(){
            return this.links;
        }

        public Link GetLinkWith(Node linkNode){
            return GetLinkWith(linkNode.GetId());
        }

        public Link GetLinkWith(int nodeId){
            return links.Find(v => v.GetNeighbour().GetId() == nodeId);
        }

        public int GetId(){
            return this.id;
        }
    }
}