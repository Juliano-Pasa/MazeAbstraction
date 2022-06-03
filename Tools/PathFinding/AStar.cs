using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.PathFinding
{
    public class AStar : IPathFinder
    {
        public int startingPosition;
        public int endingPosition;

        public AStar() : this(0, 0){
        }

        public AStar(int startingPosition, int endingPosition){
            this.startingPosition = startingPosition;
            this.endingPosition = endingPosition;
        }

        public List<int> FindPath(Graph graph){
            return FindPath(this.startingPosition, this.endingPosition, graph);
        }
        

        public List<int> FindPath(int startingPosition, int endingPosition, Graph graph){
            return new List<int>();
        }
    }
}