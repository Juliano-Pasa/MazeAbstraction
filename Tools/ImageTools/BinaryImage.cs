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
        public int width {get; private set;}
        public int height {get; private set;}
        private List<List<bool>> bimg;

        public BinaryImage(List<List<bool>> bimg, int width, int height){
            this.bimg = bimg;
            this.width = width;
            this.height = height;
        }

        public int TotalNeighbours(int row, int col){
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

        public int Position(int row, int column, int width){
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