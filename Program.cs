using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        public Node root;

        public BinaryTree(string v)
        {
            this.root = new Node(v);
        }

        internal void Add(string path, string value)
        {
            Node node = root;
            
            if (path.Length > 1)
            {
                string pathToTraverse = path.Substring(0, path.Length - 1);
                foreach (char c in pathToTraverse)
                {
                    if (c == 'L')
                    {
                        if (node.left == null)
                            node.left = new Node();
                        node = node.left;
                    }
                    else
                    {
                        if (node.right == null)
                            node.right = new Node();
                        node = node.right;
                    }
                }
            }
            
            if (path[path.Length - 1] == 'L')
            {
                if (node.left == null)
                    node.left = new Node(value);
                else
                    node.left.v = value;
            }
            else
            {
                if (node.right == null)
                    node.right = new Node(value);
                else
                    node.right.v = value;
            }
        }

        internal int Diameter()
        {
            int height = 0;
            return getDiameter(root, ref height);
        }

        private int getDiameter(Node root, ref int height)
        {
            if (root == null)
                return 0;

            int lheight = 0, rheight = 0, ldiameter = 0, rdiameter = 0;

            ldiameter = getDiameter(root.left, ref lheight);
            rdiameter = getDiameter(root.right, ref rheight);

            height = max(lheight, rheight) + 1;

            return max(lheight + rheight + 1, max(ldiameter, rdiameter));
        }

        private int max(int lheight, int rheight)
        {
            return lheight > rheight ? lheight : rheight;
        }
    }
    class Node
    {
        public Node left, right;
        public string v;

        public Node()
        {
        }

        public Node(string v)
        {
            this.v = v;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int t = int.Parse(tokens[0]);
            t--;

            BinaryTree bt = new BinaryTree(tokens[1]);

            while (t-- != 0)
            {
                string path = Console.ReadLine().Trim();
                string value = Console.ReadLine().Trim();
                bt.Add(path, value);
            }

            Console.WriteLine(bt.Diameter());
        }
    }
}
