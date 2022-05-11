namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private Node neighbour;

        public Link(Node neighbour){
            this.neighbour = neighbour;
        }

        public Node getNeighbour(){
            return this.neighbour;
        }
    }
}