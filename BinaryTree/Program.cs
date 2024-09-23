using System;

namespace BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }
        }

        public class BinaryTree
        {
            static int idx = -1;

            public Node BuildTree(int[] nodes)
            {
                idx++;
                if (nodes[idx] == -1)
                {
                    return null;
                }

                Node newNode = new Node(nodes[idx]);
                newNode.left = BuildTree(nodes);
                newNode.right = BuildTree(nodes);
                return newNode;
            }

            // Preorder traversal: Root -> Left -> Right
            public static void Preorder(Node root)
            {
                if (root == null)
                {
                    return;
                }
                Console.Write(root.data + " ");  // Print root first
                Preorder(root.left);            // Then left subtree
                Preorder(root.right);           // Then right subtree
            }

            // Inorder traversal: Left -> Root -> Right
            public static void Inorder(Node root)
            {
                if (root == null)
                {
                    return;
                }
                Inorder(root.left);            // Print left subtree first
                Console.Write(root.data + " "); // Then root
                Inorder(root.right);           // Then right subtree
            }

            // postorder traversal: Left -> Right ->  Root 
            public static void postorder(Node root)
            {
                if (root == null)
                {
                    return;
                }
                postorder(root.left); // print left subtree first
                postorder(root.right); // then right subtree
                Console.WriteLine(root.right + ""); // then root

            }

            public static void LevelOrder(Node root)
            {
                if (root == null)
                {
                    return;
                }

                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);
                q.Enqueue(null); // Marker for level change

                while (q.Count > 0)
                {
                    Node currNode = q.Dequeue();

                    if (currNode == null)
                    {
                        Console.WriteLine(); // New line for new level
                        if (q.Count == 0) // If the queue is empty, we're done
                        {
                            break;
                        }
                        else
                        {
                            q.Enqueue(null); // Add another level marker
                        }
                    }
                    else
                    {
                        Console.Write(currNode.data + " "); // Print current node

                        if (currNode.left != null)
                        {
                            q.Enqueue(currNode.left); // Add left child to the queue
                        }
                        if (currNode.right != null)
                        {
                            q.Enqueue(currNode.right); // Add right child to the queue
                        }
                    }
                }
            }


            // to find count  of nodes
            public static int countOfNodes(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                int leftnode = countOfNodes(root.left);
                int rightnode = countOfNodes(root.right);
                return leftnode + rightnode + 1;

            }

            // to find sum of nodes
            public static int sumofnodes(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                int leftsum = sumofnodes(root.left);
                int rightsum = sumofnodes(root.right);
                return leftsum + rightsum + root.data;
            }
            // to find the height of node
            public static int height(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                int leftheight = height(root.left);
                int rightheight = height(root.right);
                int myheight = Math.Max(leftheight, rightheight);
                return myheight;
            }

            //diamter of tree - no of nodes in the longest path between any 2 nodes
            //case 1 - it goes through root 
            //case 2- it goes  without root 

            public static int diameter(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                int diam1 = diameter(root.left);
                int diam2 = diameter(root.right);
                int diam3 = height(root.left) + height(root.right) + 1;
                return Math.Max(diam3, Math.Max(diam1, diam2));
            }

            public static void PrintLeafNodes(Node root)
            {
                if (root == null)
                {
                    return;
                }
                // A leaf node has no left and right children
                if (root.left == null && root.right == null)
                {
                    Console.Write(root.data + " "); // Print leaf node
                }
                // Recur for left and right children
                PrintLeafNodes(root.left);
                PrintLeafNodes(root.right);
            }


        }

        static void Main(string[] args)
        {
            int[] nodes = { 1, -2, 4, -1, -1, 5, -1, -1, 3, -1, 6, -1, -1 };
            BinaryTree tree = new BinaryTree();
            Node root = tree.BuildTree(nodes);

            Console.WriteLine("Preorder traversal:");
            BinaryTree.Preorder(root);

            Console.WriteLine("\nInorder traversal:");
            BinaryTree.Inorder(root);

            BinaryTree.postorder(root);
            BinaryTree.LevelOrder(root);
            BinaryTree.countOfNodes(root);
            BinaryTree.height(root);
            BinaryTree.diameter(root);

            Console.WriteLine("\nLeaf nodes:");
            BinaryTree.PrintLeafNodes(root);

            Console.ReadKey();
        }
    }

}
