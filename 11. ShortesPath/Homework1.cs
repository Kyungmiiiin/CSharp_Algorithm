using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortesPath
{
    internal class Homework1
    {
        const int INF = 99999;

        static void Main( string [] args )
        {
            int [,] graph = new int [8, 8]
            {
               //   0    1    2    3    4    5    6    7
                {   0, INF,   6,   6, INF, INF, INF, INF },
                { INF,   0,   9, INF, INF,   3, INF, INF },
                {   6,   9,   0, INF, INF, INF,   9, INF },
                {   6, INF, INF,   0, INF, INF, INF,   4 },
                { INF, INF, INF, INF,   0, INF,   9,   8 },
                { INF,   3, INF, INF, INF,   0, INF,   6 },
                { INF, INF,   9, INF,   9, INF,   0, INF },
                { INF, INF, INF,   4,   8,   6, INF,   0 },

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
