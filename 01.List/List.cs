using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;              // T 배열 생성
        private int count;

        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public List(int capacity)
        {
            items = new T[capacity];
            count = 0;
        }

        public int Capacity { get { return items.Length; } }      //읽기전용으로 생성 
        public int Count { get { return count; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (count == items.Length)  //가득 차 있을때
                Grow();

            items[count++] = item;       //item[count] = item
                                         // count++; 과 동일
        }
        private void Grow()    
        {
            T[] newItems = new T[items.Length * 2];      // 더 큰 배열 생성
            Array.Copy(items, newItems, items.Length);   // 새로운 배열에 기존의 데이터 복사
            items = newItems;                            // 기본 배열 대신 새로운 배열을 사용
        }
        //용량이 가득 차 있을때 더 큰 배열을 생성하는 과정

        public void Insert(int index, T item)
        {
            //예외처리 필요 : 크기를 벗어나게 중간에 끼워넣는것을 불가능

            if (index < 0 || count < index)
                throw new ArgumentOutOfRangeException();

            if (count >= items.Length)
                Grow();

            if (index < count)
                Array.Copy(items, index, items, index + 1, count - index);

            items[index] = item;
            count++;
        }

        public bool Remove(T item) 
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            //예외처리 필요 : 크기를 벗어나게 중간에 빼는 것을 불가능

            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            count--;
            Array.Copy(items, index + 1, items, index, count - index);
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (null == items[i])
                        return i;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (item.Equals(items[i]))
                        return i;
                }
            }

            return -1;
        }

        public int FindIndex(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException();

            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

    }
}
