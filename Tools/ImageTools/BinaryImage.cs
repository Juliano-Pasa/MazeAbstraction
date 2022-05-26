using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
    public enum Moved {
        //Enums all possible moves going clockwise
        up,
        right,
        down,
        left
    }
    public class BinaryImage
    {
        private int width {get;}
        private int height{get;}
        private List<List<bool>> bimg;

        public BinaryImage(List<List<bool>> bimg, int width, int height){
            this.bimg = bimg;
            this.width = width;
            this.height = height;
        }

        public Graph BinaryImageToGraph(){
            int height = bimg.Count();
            int width = bimg[0].Count();

            Graph graph = new Graph();

            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){
                    if (!IsValid(row, col)){    // Skips if maze position is invalid                 
                        continue;   
                    }

                    int totalNeighbours = TotalNeighbours(row, col);

                    if (totalNeighbours != 2){    // Checks for crossroads
                        Node originalNode = graph.GetNode(Position(row, col, width));

                        if (originalNode == null){
                            originalNode = new Node(Position(row, col, width));
                            CreateAllLinks(originalNode, row, col, graph);
                        }

                        if (originalNode != null && totalNeighbours != 1) {
                            
                        }
                    }
                }
            }
            return null;
        }

        private void CreateAllLinks(Node node, int row, int col, Graph graph){
            if (IsValid(row-1, col)){
                CreateLink(node, row, col, Moved.up, graph);
            }

            if (IsValid(row+1, col)){
                CreateLink(node, row, col, Moved.down, graph);
            }

            if (IsValid(row, col-1)){
                CreateLink(node, row, col, Moved.left, graph);
            }

            if (IsValid(row, col+1)){
                CreateLink(node, row, col, Moved.right, graph);
            }
        }

        private void CreateLink(Node node, int row, int col, Moved moved, Graph graph){
            List<int> intermediatePath = FindIntermediatePath(row-1, col, moved);
            Node endingNode = graph.ForceGetNode(intermediatePath.Last());
            intermediatePath.RemoveAt(intermediatePath.Count - 1); // Removes last element from the list (extreme node)

            graph.CreateLinkBetween(node, endingNode, intermediatePath, 0);
        }

        private List<int> FindIntermediatePath(int row, int col, Moved lastMovement){
            List<int> path = new List<int>();
            path.Add(Position(row, col, width));

            if (TotalNeighbours(row, col) != 2){    // This will be the last point added do the path
                return path;
            }

            if (IsValid(row-1, col) && lastMovement != Moved.down){
                path.AddRange(FindIntermediatePath(row-1, col, Moved.up));
                return path;
            }

            if (IsValid(row+1, col) && lastMovement != Moved.up){
                path.AddRange(FindIntermediatePath(row+1, col, Moved.down));
                return path;
            }
            
            if (IsValid(row, col-1) && lastMovement != Moved.right){
                path.AddRange(FindIntermediatePath(row, col-1, Moved.left));
                return path;
            }
            
            if (IsValid(row, col+1) && lastMovement != Moved.left){
                path.AddRange(FindIntermediatePath(row-1, col, Moved.right));
                return path;
            }

            return path;
        }

        private int TotalNeighbours(int row, int col){
            int height = bimg.Count();
            int width = bimg[0].Count();
            int total = 0;

            if (IsValid(row-1, col)){
                total += 1;
            }

            if (IsValid(row+1, col)){
                total += 1;
            }

            if (IsValid(row, col-1)){
                total += 1;
            }

            if (IsValid(row, col+1)){
                total += 1;
            }

            return total;
        }    

        private int Position(int row, int column, int width){
            return row*width + column;
        }

        public bool IsValid(int row, int col){
            if (row > 0 && row < this.height && col > 0 && col < this.width){ // Checks if row and col are inside BinaryImage boundaries
                return bimg[row][col];                
            }
            return false;
        }
    }
}