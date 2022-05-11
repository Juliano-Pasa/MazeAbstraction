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

        public void addLink(Link link){
            links.Add(link);
        }

        public void removeLinkWith(Node linkNode){
            links.RemoveAll(v => v.getNeighbour().GetId() == linkNode.GetId());
        }

        public void RemoveLinkWith(int nodeId){
            links.RemoveAll(v => v.getNeighbour().GetId() == nodeId);
        }

        public bool HasLinkWith(Node linkNode){
            return links.Find(v => v.getNeighbour().GetId() == linkNode.GetId()) != null;
        }

        public bool HasLinkWith(int nodeId){
            return links.Find(v => v.getNeighbour().GetId() == nodeId) != null;
        }

        public Link GetLinkWith(Node linkNode){
            return links.Find(v => v.getNeighbour().GetId() == linkNode.GetId());
        }

        public Link GetLinkWith(int nodeId){
            return links.Find(v => v.getNeighbour().GetId() == nodeId);
        }

        public List<Link> GetLinks(){
            return this.links;
        }

        public int GetId(){
            return this.id;
        }
    }
}