namespace _10._Searching
{
    internal class Program
    {
        static void Main( string [] args )
        {
            // 순차탐색
            int [] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            Console.Write("순차탐색 배열 : ");
            foreach ( int i in array ) Console.Write($"{i,2}");

            int sequentialIndex = Searching.SequentialSearch(array, 2);
            Console.WriteLine();
            Console.WriteLine($"순차탐색 결과 위치 : {sequentialIndex}");
            Console.WriteLine();


            // 이진탐색
            Array.Sort(array);  // 이진탐색의 경우 우선 정렬이 필요
            Console.Write("이진탐색 배열 : ");
            foreach ( int i in array ) Console.Write($"{i,2}");

            int binaryIndex = Searching.BinarySearch(array, 2);
            Console.WriteLine();
            Console.WriteLine($"이진탐색 결과 위치 : {binaryIndex}");
            Console.WriteLine();


            bool [,] graph = new bool [8, 8]
            {
                { false,  true, false, false, false, false, false, false },
                {  true, false,  true, false, false,  true, false, false },
                { false,  true, false, false,  true,  true, false, false },
                { false, false, false, false, false,  true, false, false },
                { false, false,  true, false, false, false,  true,  true },
                { false,  true,  true,  true, false, false, false, false },
                { false, false, false, false,  true, false, false, false },
                { false, false, false, false,  true, false, false, false },
            };


            // DFS 탐색
            // Depth - First Search : 깊이 우선 탐색

            Searching.DFS(in graph, 0, out bool [] dfsVisited, out int [] dfsPath);
            Console.WriteLine("<DFS>");
            PrintGraphSearch(dfsVisited, dfsPath);
            Console.WriteLine();


            // BFS 탐색
            // Breadth - First Search : 너비 우선 탐색

            Searching.BFS(in graph, 0, out bool [] bfsVisited, out int [] bfsPath);
            Console.WriteLine("<BFS>");
            PrintGraphSearch(bfsVisited, bfsPath);
            Console.WriteLine();
        }

        private static void PrintGraphSearch( bool [] visited, int [] path )
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Path",8}");

            for ( int i = 0; i < visited.Length; i++ )
            {
                Console.WriteLine($"{i,8}{visited [i],8}{path [i],8}");
            }
        }
    }
}