using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.PathFinding
{
    public interface IPathFinder
    {
        public List<int> FindPath(int startingPosition, int endingPosition, Graph graph); 
    }
}