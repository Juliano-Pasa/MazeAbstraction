namespace MazeAbstraction.Tools.GraphTools
{
    public class Link
    {
        private Node neighbour;

        public Link(Node neighbour){
            this.neighbour = neighbour;
        }

        public Node GetNeighbour(){
            return this.neighbour;
        }
    }
}