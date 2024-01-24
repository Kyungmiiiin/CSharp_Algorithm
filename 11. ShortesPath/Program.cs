namespace _11._ShortesPath
{
    internal class Program
    {
        const int INF = 99999;

        static void Main( string [] args )
        {
            int [,] graph = new int [9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            Dijkstra.ShortestPath(in graph, 0, out int [] distance, out int [] parents);

            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, parents);
        }

        private static void PrintDijkstra( int [] distance, int [] path )
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Parents",8}");

            for ( int i = 0; i < distance.Length; i++ )
            {
                Console.Write($"{i,8}");

                if ( distance [i] >= INF )
                {
                    Console.Write($"{"INF",8}");
                }
                else
                {
                    Console.Write($"{distance [i],8}");
                }

                Console.WriteLine($"{path [i],8}");
            }
        }
    }
}