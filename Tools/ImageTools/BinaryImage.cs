using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
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
                        }

                        if (originalNode != null && totalNeighbours != 1) {
                            
                        }
                    }
                }
            }
            return null;
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

        private void CreateAllLinks(Node node, int row, int col){
            if (IsValid(row-1, col)){
                
            }
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