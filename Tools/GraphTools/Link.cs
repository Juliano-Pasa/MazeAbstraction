namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private Node startNode, endNode;

        public Link(Node startNode, Node endNode){
            this.startNode = startNode;
            this.endNode = endNode;
        }

        public Node getStartNode(){
            return this.startNode;
        }

        public Node getEndNode(){
            return this.endNode;
        }
    }
}