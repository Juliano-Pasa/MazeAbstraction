using MazeAbstraction.Tools.GraphTools;
using MazeAbstraction.Tools.ImageTools;
using System.Drawing;


namespace MazeAbstraction.Source
{
    public class main
    {
        static void Main(){
            Bitmap bmp = ImageLoader.LoadImage("D:/Juliano Pasa/Pesquisa/MazeAbstraction/Images/maze.png");
            BinaryImage bimg = new BinaryImage(bmp, bmp.Width, bmp.Height);

            AbstractGraph graph = BinaryImageTranslator.BinaryImageToAbstractGraph(bimg, 6);

            ExtendedLink link = graph.GetLink(1, 1); 
            List<MazeAbstraction.Tools.GraphTools.Point> points = link.GetintermediatePath();
            foreach (MazeAbstraction.Tools.GraphTools.Point point in points){
                Console.WriteLine("row " + point.row + " col " + point.col);
            }
        }
    }
}
