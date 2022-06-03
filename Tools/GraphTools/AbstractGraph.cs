namespace MazeAbstraction.Tools.GraphTools
{
    public class AbstractGraph : Graph, IGraph
    {
        private List<List<ILink>> linkMap;
        private int clusterSize;
        private int linkMapWidth;

        public AbstractGraph(int clusterSize, int mapWidth, int mapHeight){
            this.clusterSize = clusterSize;
            linkMapWidth = (int) Math.Ceiling((decimal) mapWidth / clusterSize); 
            int linkMapHeight = (int) Math.Ceiling((decimal) mapHeight / clusterSize); 
            linkMap = new List<List<ILink>>(linkMapWidth * linkMapHeight);
        }



        public void AddToLinkMap(ILink link, Point point){
            int position = LinkMapPosition(point);

            List<ILink> linkList = linkMap[position];

            if (linkList == null){
                linkList = new List<ILink>();
            }
            else if (linkList.Contains(link)){
                return;
            }
            linkList.Add(link);
            linkMap[position] = linkList;
        }

        public List<ILink> GetLinks(Point point){
            int position = LinkMapPosition(point);
            return linkMap[position];
        }

        private int LinkMapPosition(Point point){
            return ((point.row / clusterSize) * linkMapWidth) + (point.col / clusterSize);
        }
    }
}