using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class RedBlackTree
    {
        private Node _root;
        public class Node
        {
            private int value;
            private Color color;
            private Node leftChild;
            private Node rightChild;

            public int Value
            {
                get { return value; }
                set { this.value = value; }
            }

            public Node LeftChild 
            { 
                get { return leftChild; } 
                set { leftChild = value; }
            }
            public Node RightChild 
            { 
                get { return rightChild; }
                set { rightChild = value; }
            }
            public Color Color
            {
                get { return color; }
                set { color = value; }
            }
            public override string ToString()
            {
                return $"Node(value {value}, color {color})";
            }
        }
        public enum Color { RED, BLACK }

        public bool add(int value)
        {
            if( _root != null)
            {
                bool result = AddNode(_root, value);
                _root = Rebalance(_root);
                _root.Color = Color.BLACK;
                return result;
            }
            else
            {
                _root = new Node();
                _root.Color = Color.BLACK;
                _root.Value = value;
                return true;
            }
        }

        /// <summary>
        /// добавление узла в дерево c корнем node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddNode(Node node, int value)
        {
            if(node.Value == value)
            {
                return false;
            }
            else
            {
                if(node.Value > value)
                {
                    if(node.LeftChild != null)
                    {
                        bool result = AddNode(node.LeftChild, value);
                        node.LeftChild = Rebalance(node.LeftChild);
                        return result;
                    }
                    else
                    {
                        node.LeftChild = new Node();
                        node.LeftChild.Color = Color.RED;
                        node.LeftChild.Value = value;
                        return true;
                    }
                }
                else
                {
                    if (node.RightChild != null)
                    {
                        bool result = AddNode(node.RightChild, value);
                        node.RightChild = Rebalance(node.RightChild);
                        return result;
                    }
                    else
                    {
                        node.RightChild = new Node();
                        node.RightChild.Color = Color.RED;
                        node.RightChild.Value = value;
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Смена цвета
        /// </summary>
        private void ColorSwap(Node node)
        {
            node.RightChild.Color = Color.BLACK;
            node.LeftChild.Color = Color.BLACK;
            node.Color = Color.RED;
        }
        /// <summary>
        /// Левый поворот
        /// </summary>
        private Node LeftSwap(Node node)
        {
            Node leftchild = node.LeftChild;
            Node betweenChild = leftchild.RightChild;
            leftchild.RightChild = node;
            node.LeftChild = betweenChild;
            leftchild.Color = node.Color;
            node.Color = Color.RED;
            return leftchild;
        }
        /// <summary>
        /// Правый поворот
        /// </summary>
        private Node RightSwap(Node node)
        {
            Node rightchild = node.RightChild;
            Node betweenChild = rightchild.LeftChild;
            rightchild.LeftChild = node;
            node.RightChild = betweenChild;
            rightchild.Color = node.Color;
            node.Color = Color.RED;
            return rightchild;
        }
        /// <summary>
        /// Проверка условий балансировки дерева
        /// </summary>
        private Node Rebalance(Node node)
        {
            Node result = node;
            bool needRebalance;
            do
            {
                needRebalance = false;
                if (result.RightChild != null && result.RightChild.Color == Color.RED &&
                    (result.LeftChild == null || result.LeftChild.Color == Color.BLACK))
                {
                    needRebalance = true;
                    result = RightSwap(result);
                }
                if (result.LeftChild != null && result.LeftChild.Color == Color.RED &&
                    result.LeftChild.LeftChild != null && result.LeftChild.LeftChild.Color == Color.RED)
                {
                    needRebalance = true;
                    result = LeftSwap(result);
                }
                if (result.LeftChild != null && result.LeftChild.Color == Color.RED &&
                    result.RightChild != null && result.RightChild.Color == Color.RED)
                {
                    needRebalance = true;
                    ColorSwap(result);
                }
            }
            while (needRebalance);
            return result;
        }
    }
}
