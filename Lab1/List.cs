using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    //����� �������� ������
    public class ListNode<T>
    {
        public ListNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }
    }
    //����� �������� ������
    //����������� �� ���������� ������������
    public class List<T> : IEnumerable<T>
    {
        private ListNode<T> _first;       //������ ������� ������
        private ListNode<T> _last;        //��������� �������
        private int _count;        //���������� ���������

        // ��������� IEnumerable ��������� ���������� ������� � ����� foreach
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }


        public string PrintList()
        {
            var list = "\n";
            foreach (var item in this)
            {
                list += item + "  ";
            }
            list += "\n";
            return list;
        }

        //���������� �������� � ����� ������
        public void AddLast(T data)
        {
            var node = new ListNode<T>(data);
            if (_count != 0)
            {
                _last.Next = node;
            }
            else
            {
                _first = node;
            }
            _last = node;
            _count++;
        }
        //���������� �������� � ������ ������
        public void AddFirst(T data)
        {
            var node = new ListNode<T>(data) { Next = _first };
            _first = node;
            if (_count == 0)
                _last = _first;
            _count++;
        }
        //���������� �������� � ������������ ������� 
        public void Insert(int pos, T data)
        {
            if (pos == 0)
                AddFirst(data);
            else if (pos == _count)
                AddLast(data);
            else if (pos > 0 && pos < _count)
            {
                var previous = _first;
                for (var i = 0; i < pos - 1; i++)
                    previous = previous.Next;
                var next = previous.Next;
                var node = new ListNode<T>(data) { Next = next };
                previous.Next = node;
                _count++;
            }
        }
        //������� ������ �������
        public bool RemoveFirst()
        {
            if (_first == null)
                return false;

            _first = _first.Next;
            if (_first == null)
                _last = null;
            _count--;
            return true;
        }
        //������� ��������� �������
        public bool RemoveLast()
        {
            var previous = _first;
            if (previous == null)
                return false;

            while (previous.Next != _last)
            {
                previous = previous.Next;
            }
            previous.Next = null;
            _last = previous;
            _count--;
            return true;

        }
        //�������� �������� �� ������ �� �������
        public bool Remove(int index)
        {
            if (index >= _count || index < 0)
                return false;
            if (index == _count - 1)
                RemoveLast();
            else if (index == 0)
                RemoveFirst();
            else
            {
                var previous = _first;
                for (var i = 0; i < index - 1; i++)
                {
                    previous = previous.Next;
                }
                var current = previous.Next;
                var next = current.Next;
                previous.Next = next;
                current.Next = null;
                _count--;
                return true;
            }
            return false;
        }
        public void Reverse()
        {
            ListNode<T> current = _first,
                        previous = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _last = _first;
            _first = previous;
        }
    }
}
