using System.Drawing;

namespace MazeAbstraction.Tools.ImageTools
{
    public class ImageLoader
    {
        public static Bitmap LoadImage(string path) {
            try {
                Bitmap img = new Bitmap(path);
                return img;
            }
            catch (FileNotFoundException) {
                System.Console.WriteLine("Não foi possível encontrar a imagem, verifique o caminho informado");
                return null;
            }
        }
    }
}