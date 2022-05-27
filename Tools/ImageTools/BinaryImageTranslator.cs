using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
    public enum Direction {
        //Enums all possible moves going clockwise
        up,
        right,
        down,
        left
    }
    public class BinaryImageTranslator
    {
        public static Graph BinaryImageToAbstractGraph(BinaryImage bimg){
            Graph graph = new Graph();
            int height = bimg.height;
            int width = bimg.width;

            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){

                    if (!bimg.IsValid(row, col)){    // Skips if maze position is invalid                 
                        continue;   
                    }

                    int totalNeighbours = bimg.TotalNeighbours(row, col);

                    if (totalNeighbours == 2) { // Skips if it's not a crossroad
                        continue;
                    }

                    Node originalNode = graph.GetNode(bimg.Position(row, col));

                    if (originalNode == null){ // New position that hasnt been reached before
                        originalNode = new Node(bimg.Position(row, col));
                        graph.AddNode(originalNode);
                        CreateAllLinks(originalNode, row, col, bimg, graph);
                    }
                    else if (totalNeighbours == 1 && originalNode != null) { // Skips if it's a one-way node that already exists
                        continue;
                    }
                    else { // Existing node that has 3 or 4 neighbours and could have links that were not explored
                        CreateAllLinks(originalNode, row, col, bimg, graph);
                    }
                }
            }
            return graph;
        }

        private static void CreateAllLinks(Node node, int row, int col, BinaryImage bimg, Graph graph){
            if (bimg.IsValid(row-1, col)){
                CreateLink(node, row-1, col, Direction.up, bimg, graph);
            }

            if (bimg.IsValid(row+1, col)){
                CreateLink(node, row+1, col, Direction.down, bimg, graph);
            }

            if (bimg.IsValid(row, col-1)){
                CreateLink(node, row, col-1, Direction.left, bimg, graph);
            }

            if (bimg.IsValid(row, col+1)){
                CreateLink(node, row, col+1, Direction.right, bimg, graph);
            }
        }

        private static void CreateLink(Node node, int row, int col, Direction direction, BinaryImage bimg, Graph graph){
            List<int> intermediatePath = FindIntermediatePath(row, col, direction, bimg);
            
            Node endingNode = graph.ForceGetNode(intermediatePath.Last());
            intermediatePath.RemoveAt(intermediatePath.Count - 1); // Removes last element from the list (extreme node)

            graph.CreateLinkBetween(node, endingNode, intermediatePath, 0);
        }

        private static List<int> FindIntermediatePath(int row, int col, Direction lastMovement, BinaryImage bimg){
            List<int> path = new List<int>();
            path.Add(bimg.Position(row, col));

            if (bimg.TotalNeighbours(row, col) != 2){    // This will be the last point added do the path
                return path;
            }

            if (bimg.IsValid(row-1, col) && lastMovement != Direction.down){
                path.AddRange(FindIntermediatePath(row-1, col, Direction.up, bimg));
                return path;
            }

            if (bimg.IsValid(row+1, col) && lastMovement != Direction.up){
                path.AddRange(FindIntermediatePath(row+1, col, Direction.down, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col-1) && lastMovement != Direction.right){
                path.AddRange(FindIntermediatePath(row, col-1, Direction.left, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col+1) && lastMovement != Direction.left){
                path.AddRange(FindIntermediatePath(row, col+1, Direction.right, bimg));
                return path;
            }

            return path;
        }
    }
}