using System.Drawing;
using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
    public class ImageProcesser
    {
        private Bitmap img;

        public ImageProcesser(Bitmap img) {
            this.img = img;
        }

        public List<List<bool>> ImageToBool(){
            List<List<bool>> boolMatrix = new List<List<bool>>();
            for (int i = 0; i < img.Height; i++) {                
                List<bool> aux = new List<bool>();
                for (int j = 0; j < img.Width; j++) {
                    if (img.GetPixel(j, i) == Color.FromName("White")) {
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

        public Graph BoolMatrixToGraph(List<List<bool>> boolMatrix){
            int height = boolMatrix.Count();
            int width = boolMatrix[0].Count();

            Graph graph = new Graph();
            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){
                    if (boolMatrix[row][col]){    // Checks for valid maze position                 
                        if (TotalNeighbours(row, col, boolMatrix) != 2){    // Checks for crossroads
                            
                        }
                    }
                }
            }
            return null;
        }

        private int TotalNeighbours(int row, int column, List<List<bool>> boolMatrix){
            int height = boolMatrix.Count();
            int width = boolMatrix[0].Count();
            int total = 0;

            if (row > 0){
                if (boolMatrix[row-1][column]) total += 1;
            }
            if (row < height - 1){
                if (boolMatrix[row+1][column]) total += 1;
            }
            if (column > 0){
                if (boolMatrix[row][column-1]) total += 1;
            }            
            if (column < width - 1){
                if (boolMatrix[row][column+1]) total += 1;
            }

            return total;
        }

        private int Position(int row, int column, int width){
            return row*width + column;
        }

        
    }
}