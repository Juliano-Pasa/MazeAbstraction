using System.Drawing;

namespace MazeAbstraction.Tools.ImageTools
{
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

        public BinaryImage(Bitmap bmp, int width, int height){
            this.width = width;
            this.height = height;
            this.bimg = ImageToBinaryImage(bmp);
        }

        public List<List<bool>> ImageToBinaryImage(Bitmap img){
            List<List<bool>> boolMatrix = new List<List<bool>>();
            Color white = Color.FromArgb(255, 255, 255, 255);

            for (int i = 0; i < img.Height; i++) {                
                List<bool> aux = new List<bool>();

                for (int j = 0; j < img.Width; j++) {
                    if (img.GetPixel(j, i) == white) {
                        aux.Add(true);
                    } 
                    else {
                        aux.Add(false);
                    }
                }
                boolMatrix.Add(aux);
            }

            return boolMatrix;
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

        public int Position(int row, int column){
            return row * this.width + column;
        }

        public bool IsValid(int row, int col){
            if (row >= 0 && row < this.height && col >= 0 && col < this.width){ // Checks if row and col are inside BinaryImage boundaries
                return bimg[row][col];                
            }
            return false;
        }
    }
}