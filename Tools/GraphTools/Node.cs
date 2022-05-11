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
            links.RemoveAll(v => v.getEndNode().getId() == linkNode.getId());
        }

        public void removeLinkWith(int nodeId){
            links.RemoveAll(v => v.getEndNode().getId() == nodeId);
        }

        public bool hasLinkWith(Node linkNode){
            return links.Find(v => v.getEndNode().getId() == linkNode.getId()) != null;
        }

        public bool hasLinkWith(int nodeId){
            return links.Find(v => v.getEndNode().getId() == nodeId) != null;
        }

        public Link GetLinkWith(Node linkNode){
            return links.Find(v => v.getEndNode().getId() == linkNode.getId());
        }

        public Link GetLinkWith(int nodeId){
            return links.Find(v => v.getEndNode().getId() == nodeId);
        }

        public int getId(){
            return this.id;
        }
    }
}