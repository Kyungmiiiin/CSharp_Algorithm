using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sorting
{
    internal class Sorting
    {
        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 비교하며 가장 작은 데이터부터 앞에 정렬 
        // 시간복잡도 -  O(n²) - 2중 반복문을 사용하기 때문
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void SelectionSort( IList<int> list, int start, int end )
        {
            for ( int i = start; i <= end; i++ )     // 앞에것부터 하나씩 반복
            {
                int minIndex = i;
                for ( int j = i + 1; j <= end; j++ )
                {
                    if ( list [j] < list [minIndex] )
                    {
                        minIndex = j;                // 제일 작은 수 찾기
                    }
                }
                Swap(list, i, minIndex);             // 비교해서 순서바꾸기 (작은 수부터 앞에 정렬)
            }
        }



        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort( IList<int> list, int start, int end )
        {
            for ( int i = start + 1; i <= end; i++ )
            {
                for ( int j = i; j >= 1; j-- )           // 뒤에서부터 확인하고 비교하기
                {
                    if ( list [j - 1] < list [j] )       // 큰수는 밀어내고 작은 수의 뒤로 끼워넣기
                    {
                        break;
                    }

                    Swap(list, j - 1, j);                // 밀어내며 순서 바꾸기
                }
            }
        }



        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 비교하여 큰 데이터부터 뒤로 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort( IList<int> list, int start, int end )
        {
            for ( int i = start; i < end; i++ )                     
            {
                for ( int j = 0; j < end - start; j++ )
                {
                    if ( list [j] > list [j + 1] )              // 인접한 데이터를 비교
                    {
                        Swap(list, j, j + 1);                   // 비교해서 순서바꾸기 (큰 수부터 뒤에 정렬)
                    }
                }
            }
        }



        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O
        public static void MergeSort( IList<int> list, int start, int end )
        {
            if ( start == end )
            {
                return;
            }

            int mid = ( start + end ) / 2;       // 2분할 하여 따로 정렬
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            Merge(list, start, mid, end);        // 2분할 한 정렬을 병합
        }

        private static void Merge( IList<int> list, int start, int mid, int end )
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while ( leftIndex <= mid && rightIndex <= end )
            {
                if ( list [leftIndex] < list [rightIndex] )
                {
                    sortedList.Add(list [leftIndex++]);
                }
                else
                {
                    sortedList.Add(list [rightIndex++]);
                }
            }

            if ( leftIndex > mid )
            {
                for ( int i = rightIndex; i <= end; i++ )
                {
                    sortedList.Add(list [i]);
                }
            }
            else
            {
                for ( int i = leftIndex; i <= mid; i++ )
                {
                    sortedList.Add(list [i]);
                }
            }

            for ( int i = 0; i < sortedList.Count; i++ )
            {
                list [start + i] = sortedList [i];
            }
        }



        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void QuickSort( IList<int> list, int start, int end )
        {
            if ( start >= end ) return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while ( left <= right )
            {
                while ( list [left] <= list [pivot] && left < right )
                {
                    left++;
                }
                while ( list [right] > list [pivot] && left <= right )
                {
                    right--;
                }

                if ( left < right )
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list, pivot, right);
                    break;
                }
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }



        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void HeapSort( IList<int> list )
        {
            for ( int i = list.Count / 2 - 1; i >= 0; i-- )
            {
                Heapify(list, i, list.Count);
            }

            for ( int i = list.Count - 1; i > 0; i-- )
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void Heapify( IList<int> list, int index, int size )
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if ( left < size && list [left] > list [max] )
            {
                max = left;
            }
            if ( right < size && list [right] > list [max] )
            {
                max = right;
            }

            if ( max != index )
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }


        private static void Swap( IList<int> list, int left, int right )
        {
            int temp = list [left];
            list [left] = list [right];
            list [right] = temp;
        }
    }
}