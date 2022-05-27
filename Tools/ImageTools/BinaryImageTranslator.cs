using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
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

                    if (totalNeighbours != 2){    // Checks for crossroads               
                        Node originalNode = graph.GetNode(bimg.Position(row, col));

                        if (originalNode == null){
                            Console.WriteLine(bimg.Position(row, col));
                            originalNode = new Node(bimg.Position(row, col));
                            graph.AddNode(originalNode);
                            CreateAllLinks(originalNode, row, col, bimg, graph);
                        }

                        if (originalNode != null && totalNeighbours != 1) {
                            
                        }
                    }
                }
            }
            return graph;
        }

        private static void CreateAllLinks(Node node, int row, int col, BinaryImage bimg, Graph graph){
            if (bimg.IsValid(row-1, col)){
                CreateLink(node, row-1, col, Moved.up, bimg, graph);
            }

            if (bimg.IsValid(row+1, col)){
                CreateLink(node, row+1, col, Moved.down, bimg, graph);
            }

            if (bimg.IsValid(row, col-1)){
                CreateLink(node, row, col-1, Moved.left, bimg, graph);
            }

            if (bimg.IsValid(row, col+1)){
                CreateLink(node, row, col+1, Moved.right, bimg, graph);
            }
        }

        private static void CreateLink(Node node, int row, int col, Moved moved, BinaryImage bimg, Graph graph){
            List<int> intermediatePath = FindIntermediatePath(row, col, moved, bimg);
            
            Node endingNode = graph.ForceGetNode(intermediatePath.Last());
            intermediatePath.RemoveAt(intermediatePath.Count - 1); // Removes last element from the list (extreme node)

            graph.CreateLinkBetween(node, endingNode, intermediatePath, 0);
        }

        private static List<int> FindIntermediatePath(int row, int col, Moved lastMovement, BinaryImage bimg){
            List<int> path = new List<int>();
            path.Add(bimg.Position(row, col));

            if (bimg.TotalNeighbours(row, col) != 2){    // This will be the last point added do the path
                return path;
            }

            if (bimg.IsValid(row-1, col) && lastMovement != Moved.down){
                path.AddRange(FindIntermediatePath(row-1, col, Moved.up, bimg));
                return path;
            }

            if (bimg.IsValid(row+1, col) && lastMovement != Moved.up){
                path.AddRange(FindIntermediatePath(row+1, col, Moved.down, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col-1) && lastMovement != Moved.right){
                path.AddRange(FindIntermediatePath(row, col-1, Moved.left, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col+1) && lastMovement != Moved.left){
                path.AddRange(FindIntermediatePath(row, col+1, Moved.right, bimg));
                return path;
            }

            return path;
        }
    }
}