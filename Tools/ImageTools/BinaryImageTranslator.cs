using MazeAbstraction.Tools.GraphTools;

namespace MazeAbstraction.Tools.ImageTools
{
    public enum Direction {
        //Enums all possible moves going clockwise
        up,
        right,
        down,
        left
    }
    public class BinaryImageTranslator
    {
        public static Graph BinaryImageToGraph(BinaryImage bimg){
            Graph graph = new Graph();
            int height = bimg.height;
            int width = bimg.width;

            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){
                    if (!bimg.IsValid(row, col)){    // Skips if maze position is invalid                 
                        continue;   
                    }

                    INode originalNode = graph.GetNode(bimg.Position(row, col));

                    if (originalNode == null){
                        originalNode = new Node(bimg.Position(row, col));
                        graph.AddNode(originalNode);
                    }

                    CreateLink(originalNode, row-1, col, bimg, graph);
                    CreateLink(originalNode, row, col-1, bimg, graph);
                }
            }

            return graph;
        }
        
        public static AbstractGraph BinaryImageToAbstractGraph(BinaryImage bimg, int clusterSize){
            AbstractGraph graph = new AbstractGraph(clusterSize, bimg.width, bimg.height);
            int height = bimg.height;
            int width = bimg.width;

            for (int row = 0; row < height; row++){
                for (int col = 0; col < width; col++){

                    if (!bimg.IsValid(row, col)){    // Skips if maze position is invalid                 
                        continue;   
                    }

                    int totalNeighbours = bimg.TotalNeighbours(row, col);

                    if (totalNeighbours == 2) { // Skips if it's not a crossroad
                        continue;
                    }

                    INode originalNode = graph.GetNode(bimg.Position(row, col));

                    if (originalNode == null){ // New position that hasnt been reached before
                        originalNode = new Node(bimg.Position(row, col));
                        graph.AddNode(originalNode);
                        CreateAllAbsctractLinks(originalNode, row, col, bimg, graph);
                    }
                    else if (totalNeighbours == 1 && originalNode != null) { // Skips if it's a one-way node that already exists
                        continue;
                    }
                    else { // Existing node that has 3 or 4 neighbours and could have links that were not explored
                        CreateAllAbsctractLinks(originalNode, row, col, bimg, graph);
                    }
                }
            }
            return graph;
        }

        private static void CreateAllAbsctractLinks(INode node, int row, int col, BinaryImage bimg, AbstractGraph graph){
            if (bimg.IsValid(row-1, col)){
                CreateAbstractLink(node, row-1, col, Direction.up, bimg, graph);
            }

            if (bimg.IsValid(row+1, col)){
                CreateAbstractLink(node, row+1, col, Direction.down, bimg, graph);
            }

            if (bimg.IsValid(row, col-1)){
                CreateAbstractLink(node, row, col-1, Direction.left, bimg, graph);
            }

            if (bimg.IsValid(row, col+1)){
                CreateAbstractLink(node, row, col+1, Direction.right, bimg, graph);
            }
        }

        private static void CreateAbstractLink(INode node, int row, int col, Direction direction, BinaryImage bimg, AbstractGraph graph){
            List<Point> intermediatePath = FindIntermediatePath(row, col, direction, bimg);
            
            Point endingNodePosition = intermediatePath.Last();
            int endingNodeId = bimg.Position(endingNodePosition.row, endingNodePosition.col);
            INode endingNode = graph.GetNode(endingNodeId);

            if (endingNode == null){
                endingNode = new Node(endingNodeId); // Implements Node
                graph.AddNode(endingNode);
            }
            
            intermediatePath.RemoveAt(intermediatePath.Count - 1); // Removes last element from the list (extreme node)
            ExtendedLink xlink = new ExtendedLink(node, endingNode, intermediatePath, 0); // Implements ExtendedLink

            foreach (Point position in intermediatePath){
                graph.AddToLinkMap(xlink, position);
            }

            graph.AddLinkBetween(node, endingNode, xlink);
        }

        private static List<Point> FindIntermediatePath(int row, int col, Direction lastMovement, BinaryImage bimg){
            List<Point> path = new List<Point>();
            path.Add(new Point(row, col));

            if (bimg.TotalNeighbours(row, col) != 2){    // This will be the last point added do the path
                return path;
            }

            if (bimg.IsValid(row-1, col) && lastMovement != Direction.down){
                path.AddRange(FindIntermediatePath(row-1, col, Direction.up, bimg));
                return path;
            }

            if (bimg.IsValid(row+1, col) && lastMovement != Direction.up){
                path.AddRange(FindIntermediatePath(row+1, col, Direction.down, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col-1) && lastMovement != Direction.right){
                path.AddRange(FindIntermediatePath(row, col-1, Direction.left, bimg));
                return path;
            }
            
            if (bimg.IsValid(row, col+1) && lastMovement != Direction.left){
                path.AddRange(FindIntermediatePath(row, col+1, Direction.right, bimg));
                return path;
            }

            return path;
        }

        private static void CreateLink(INode node, int row, int col, BinaryImage bimg, Graph graph){
            if (bimg.IsValid(row, col)){
                Node neighbour = new Node(bimg.Position(row, col));
                graph.AddNode(neighbour);

                Link link = new Link(node, neighbour);
                graph.AddLinkBetween(node, neighbour, link);
            }
        }
    }
}