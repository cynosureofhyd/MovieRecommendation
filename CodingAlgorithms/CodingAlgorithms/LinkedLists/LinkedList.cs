using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms
{
    public class LinkedList
    {
        public class Node
        {
            public object Value { get; set; }
            public Node Next { get; set; }
        }

        public Node Create(object value)
        {
            Node newNode = new Node()
            {
                Value = value,
                Next = null
            };
            return newNode;
        }

        private int size;
        public int Count
        {
            get
            {
                return size;
            }
        }

        private Node head;


        public Node Add(Node addNode, object data)
        {
            if(addNode == null)
            {
                return Create(data);
            }
            Node newNode = Create(data);
            newNode.Next = addNode;
            addNode = newNode;
            return addNode;
        }
    }
}
