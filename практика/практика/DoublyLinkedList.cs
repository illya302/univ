using System;
using System.Collections.Generic;
using System.Collections;

namespace part1
{
    public class DoublyLinkedList<T> : IEnumerable<T> where T : Student
    {
        DoublyNode<T> head;
        DoublyNode<T> tail; 
        int count = 0;  
       
        public void AddLast(T data)
        {
            if(!(data is T)) 
            {
                throw new Exception("Argument error!");   
            }
            var node = new DoublyNode<T>(data);
            if (count == 0)
            {
                head = node;
                tail = node;
            }
            else 
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }   
            count++;
            
        }
        public void AddFirst(T data)
        {
            if (!(data is T))
            {
                throw new Exception("Argument error!");
            }
            var node = new DoublyNode<T>(data);
            if (count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            count++;
        }
        public void AddByIndex(T data, int index) 
        {
            if (!(data is T))
            {
                throw new Exception("Argument error!");
            }
            if (index<0||index>=count)
            {
                throw new Exception("Index out of range!");
            }
            var node = new DoublyNode<T>(data);
            if (index == 0)
            {
                AddFirst(data);
            }
            else if (index == count - 1)
            {
                AddLast(data);
            }
            else 
            {
                var current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                node.Previous = current.Previous;
                node.Next = current;
                current.Previous.Next = node;
                current.Previous = node;
            }
            count++;
        }
        public void DeleteByIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new Exception("Index out of range!");
            }
            if (index == 0)
            {
                DeleteFirst();
            }
            else if (index == count-1)
            {
                DeleteLast();
            }
            else
            {
                var current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next.Previous = current.Previous;
                current.Previous.Next = current.Next;
            }
            count--;
        }
        public void DeleteFirst()
        {
            if (count == 0)
            {
                throw new Exception("The list is empty");
            }
            else if (count == 1)
            {
                head = null;
                tail = null;
                count--;
            }
            else
            {
                head.Next.Previous = null;
                head = head.Next;
                count--;
            }
        }
        public void DeleteLast()
        {
            if (count == 0)
            {
                throw new Exception("The list is empty");
            }
            else if (count == 1)
            {
                head = null;
                tail = null;
                count--;
            }
            else 
            {
                tail.Previous.Next = null;
                tail = tail.Previous;
                count--;
            }
        }
        public T this[int i] 
        {
            get 
            {
                var current = head;
                if (current == null) 
                {
                    throw new NullReferenceException("The list is empty");
                }
                if (i > count || i < 0) 
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
                for (int a = 0; a < i; a++) 
                {
                    current = current.Next;
                }
                return current.Data;            
            }
            set 
            {
                var current = head;
                if (i > count || i < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
                if (!(value is T)) 
                {
                    throw new ArgumentException("Invalid data type!");
                }
                for (int a = 0; a <= i; a++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        public int LengthOfList() => count;

        public bool IncraseORDecrease = true;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (IncraseORDecrease)
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            else if(!IncraseORDecrease)
            {
                DoublyNode<T> current = tail;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Previous;
                }
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public void SortByInsert()
        {
            if (count == 0)
            {
                throw new Exception("The list is empty");
            }
            var current = head;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].averageMark < current.Data.averageMark)
                    {
                        if (j == 0)
                        {
                            this.AddFirst(current.Data);
                            this.DeleteByIndex(i + 1);
                            break;
                        }
                        else
                        {
                            this.AddByIndex(current.Data, j);
                            this.DeleteByIndex(i+1);
                            break;
                        }       
                    }
                }
                current = current.Next;
            }
        }
        public DoublyLinkedList<T> SearchStudent() 
        {
            if (count == 0)
            {
                throw new Exception("The list is empty");
            }
            var temp = new DoublyLinkedList<T>();
            var current = head;

            while (current != null) 
            {
                if (current.Data.attendingMusicLessons) 
                {
                    if (current.Data.averageMark > 90) 
                    {
                    temp.AddLast(current.Data);
                    }
                }
                current = current.Next;
            }
            return temp;
        }
    }
}

