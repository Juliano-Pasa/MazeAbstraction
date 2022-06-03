namespace MazeAbstraction.Tools.GraphTools
{
    public class AbstractGraph : Graph, IGraph
    {
        private List<List<ExtendedLink>> linkMap;
        private int clusterSize;
        private int linkMapWidth;

        public AbstractGraph(int clusterSize, int mapWidth, int mapHeight){
            this.clusterSize = clusterSize;
            linkMapWidth = (int) Math.Ceiling((decimal) mapWidth / clusterSize); 
            int linkMapHeight = (int) Math.Ceiling((decimal) mapHeight / clusterSize); 
            InitializeLinkMap(linkMapWidth * linkMapWidth);
        }

        public void AddToLinkMap(ExtendedLink link, Point point){
            int position = LinkMapPosition(point);

            List<ExtendedLink> linkList = linkMap[position];

            if (linkList == null){
                linkList = new List<ExtendedLink>();
            }
            else if (linkList.Contains(link)){
                return;
            }
            linkList.Add(link);
            linkMap[position] = linkList;
        }

        public List<ExtendedLink> GetAllLinks(Point point){
            int position = LinkMapPosition(point);
            return linkMap[position];
        }
        
        public List<ExtendedLink> GetAllLinks(int row, int col){
            return GetAllLinks(new Point(row, col));
        }

        public ExtendedLink GetLink(Point point){
            List<ExtendedLink> links = GetAllLinks(point);
            foreach (ExtendedLink link in links){
                if (link.GetintermediatePath().Contains(point)){
                    return link;
                }
            }
            return null;
        }

        public ExtendedLink GetLink(int row, int col){
            return GetLink(new Point(row, col));
        }

        private int LinkMapPosition(Point point){
            int x = ((int) Math.Floor((decimal) point.row / clusterSize) * linkMapWidth) + (int) Math.Floor((decimal) point.col / clusterSize);
            return x;
        }

        private void InitializeLinkMap(int size){
            this.linkMap = new List<List<ExtendedLink>>();
            for (int i = 0; i < size; i++){
                linkMap.Add(null);
            }
        }
    }
}