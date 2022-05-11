using System.Drawing;

namespace MazeAbstraction.Tools.ImageTools
{
    public class ImageProcesser
    {
        private Bitmap img;

        public ImageProcesser(Bitmap img) {
            this.img = img;
        }

        public List<List<bool>> ImageToBool(){
            List<List<bool>> binaryImage = new List<List<bool>>();
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
                binaryImage.Add(aux);
            }
            return binaryImage;
        }
    }
}