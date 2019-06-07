using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class Node<T>
    {
        public  T Value { get; private set; }
        public  Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
