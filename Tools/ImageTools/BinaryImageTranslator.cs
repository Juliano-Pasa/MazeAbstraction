using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
    public class BinaryImageTranslator
    {
        private BinaryImage bimg;
        private Graph graph;

        public BinaryImageTranslator(BinaryImage bimg, Graph graph){
            this.bimg = bimg;
            this.graph = graph;
        }

        public Graph BinaryImageToGraph(){
            int height = bimg.height;
            int width = bimg.width;

            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){
                    if (!bimg.IsValid(row, col)){    // Skips if maze position is invalid                 
                        continue;   
                    }

                    int totalNeighbours = bimg.TotalNeighbours(row, col);

                    if (totalNeighbours != 2){    // Checks for crossroads
                        Node originalNode = graph.GetNode(bimg.Position(row, col, width));

                        if (originalNode == null){
                            originalNode = new Node(bimg.Position(row, col, width));
                            CreateAllLinks(originalNode, row, col);
                        }

                        if (originalNode != null && totalNeighbours != 1) {
                            
                        }
                    }
                }
            }
            return null;
        }

        private void CreateAllLinks(Node node, int row, int col){
            if (bimg.IsValid(row-1, col)){
                CreateLink(node, row, col, Moved.up);
            }

            if (bimg.IsValid(row+1, col)){
                CreateLink(node, row, col, Moved.down);
            }

            if (bimg.IsValid(row, col-1)){
                CreateLink(node, row, col, Moved.left);
            }

            if (bimg.IsValid(row, col+1)){
                CreateLink(node, row, col, Moved.right);
            }
        }

        private void CreateLink(Node node, int row, int col, Moved moved){
            List<int> intermediatePath = FindIntermediatePath(row-1, col, moved);
            Node endingNode = graph.ForceGetNode(intermediatePath.Last());
            intermediatePath.RemoveAt(intermediatePath.Count - 1); // Removes last element from the list (extreme node)

            graph.CreateLinkBetween(node, endingNode, intermediatePath, 0);
        }

        private List<int> FindIntermediatePath(int row, int col, Moved lastMovement){
            List<int> path = new List<int>();
            path.Add(bimg.Position(row, col, bimg.width));

            if (bimg.TotalNeighbours(row, col) != 2){    // This will be the last point added do the path
                return path;
            }

            if (bimg.IsValid(row-1, col) && lastMovement != Moved.down){
                path.AddRange(FindIntermediatePath(row-1, col, Moved.up));
                return path;
            }

            if (bimg.IsValid(row+1, col) && lastMovement != Moved.up){
                path.AddRange(FindIntermediatePath(row+1, col, Moved.down));
                return path;
            }
            
            if (bimg.IsValid(row, col-1) && lastMovement != Moved.right){
                path.AddRange(FindIntermediatePath(row, col-1, Moved.left));
                return path;
            }
            
            if (bimg.IsValid(row, col+1) && lastMovement != Moved.left){
                path.AddRange(FindIntermediatePath(row-1, col, Moved.right));
                return path;
            }

            return path;
        }
    }
}