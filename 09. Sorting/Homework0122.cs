using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace _240122_정렬실습
    {
        public static class Homework0122
        {

            public static void SelectionSort( List<int> list, int start, int end )
            {
                for ( int s = start; s <= end; s++ )   // 0번째 인덱스
                {
                    int minIndex = s;
                    for ( int i = s + 1; i <= end; i++ )       // 1번째 인덱스
                    {
                        if ( list [i] < list [minIndex] )           // 0번째와 1번째를 비교해서 1번째가 작으면
                        {
                            minIndex = i;                 // 1번째가 minIndex가 됨
                        }
                    }
                    Swap(list, s, minIndex);
                }
            }
            public static void InsertionSort( List<int> list, int start, int end )
            {
                for ( int s1 = start + 1; s1 <= end; s1++ )        // 1번째 인덱스
                {
                    for ( int i = s1; i > start; i-- )              // 0번째 인덱스
                    {
                        if ( list [i - 1] < list [i] )           // 바로 전 인덱스와 비교
                        {
                            break;
                        }
                        Swap(list, i - 1, i);
                    }
                }
            }

            public static void BubbleSort( List<int> list, int start, int end )
            {
                for ( int s = start; s < end; s++ )       // 0
                {
                    for ( int i = 0; i < end - start; i++ )
                    {
                        if ( list [i] > list [i + 1] )
                        {
                            Swap(list, i, i + 1);
                        }
                    }
                }

            }

            private static void Swap( IList<int> list, int left, int right )
            {
                int temp = list [left];
                list [left] = list [right];
                list [right] = temp;
            }
            static void Main( string [] args )
            {
                Random random = new Random();
                int count = 20;

                List<int> selectionList = new List<int>(count);
                List<int> insertionList = new List<int>(count);
                List<int> bubbleList = new List<int>(count);


                Console.WriteLine("숫자 랜덤 생성!");
                for ( int i = 0; i < count; i++ )
                {
                    int rand = random.Next() % 100;
                    Console.Write($"{rand,3}");

                    selectionList.Add(rand);
                    insertionList.Add(rand);
                    bubbleList.Add(rand);

                }
                Console.WriteLine();


                Console.WriteLine("선택 정렬 하기 !");
                Homework0122.SelectionSort(selectionList, 0, selectionList.Count - 1);
                foreach ( int i in selectionList )
                {
                    Console.Write($"{i,3}");
                }
                Console.WriteLine();


                Console.WriteLine("삽입 정렬 하기 !");
                Homework0122.InsertionSort(insertionList, 0, insertionList.Count - 1);
                foreach ( int i in insertionList )
                {
                    Console.Write($"{i,3}");
                }
                Console.WriteLine();


                Console.WriteLine("버블 정렬 하기 ! ");
                Homework0122.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
                foreach ( int i in bubbleList )
                {
                    Console.Write($"{i,3}");
                }
                Console.WriteLine();

            }
        }
    }


