using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Node<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;
        public Node<T> parent;
    }

    class BinarySearch<T> where T : IComparable
    {
        public Node<T> insert(Node<T> root, T v)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.value = v;
            }

            
            else if (v.CompareTo(root.value) < 0)
            {
                root.left = insert(root.left, v);
                root.left.parent = root;

            }
            else
            {
                root.right = insert(root.right, v);
                root.right.parent = root;

            }

            return root;
        }

        public Node<T> siblingNode(Node<T> root)
        {
            if (root.parent != null && root.parent.right.value.CompareTo(root.value) == 0)
            {
                return root.parent.left;
            }
            else if (root.parent != null && root.parent.left.value.CompareTo(root.value) == 0)
            {
                return root.parent.right;
            }
            else
            {
                return root;
            }
        }
        public Node<T> siblingofParent(Node<T> root)
        {
            //if parent is not null and if the node is the 'right' node
            if (root.parent != null && root.parent.right.value.CompareTo(root.value) == 0)
            {
                return siblingNode(root.parent);
            }
            //if parent is not null and if the node is the 'left' node
            else if (root.parent != null && root.parent.left.value.CompareTo(root.value) == 0)
            {
                return siblingNode(root.parent);
            }
            else
            {
                return root;
            }
        }



        // Algorithm from https://www.geeksforgeeks.org/binary-search-tree-set-2-delete/
        public Node<T> Delete(Node<T> root, T value)
        {
            // if their is nothing to delete
            if (root == null)
                return root;

            // traverse down the tree using the nodes values
            if (value.CompareTo(root.value) < 0)
            {
                root.left = Delete(root.left, value);
            }

            else if (value.CompareTo(root.value) > 0)
            {
                root.right = Delete(root.right, value);
            }


            //node that will be deleted
            else
            {
                // node with only one child or no child
                if (root.left == null)
                {
                    return root.right;
                }

                else if (root.right == null)
                {
                    return root.left;
                }

                // find the smallest number in the right subtree to put it at the top of the tree
                root.value = minValue(root.right);


                // deletes the old value
                root.right = Delete(root.right, root.value);


            }
            root.right.parent = root;
            root.left.parent = root;

            return root;
        }

        // method to find the smallest value
        T minValue(Node<T> root)
        {
            T minvalue = root.value;
            // finds the minimum value by traversing down the left side of the tree
            while (root.left != null)
            {
                minvalue = root.left.value;
                root = root.left;
            }
            return minvalue;
        }
        public Node<T> Search(Node<T> root, T value)
        {
            if (root == null ||
                root.value.CompareTo(value) == 0)
                return root;

            // value is greater than root's value
            if (value.CompareTo(root.value) < 0)
            {
                return Search(root.right, value);
            }
            else
            {
                return Search(root.left, value);
            }

        }


        // traversals
        public string inOrder(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }

            inOrder(root.left);
            total += " " + root.value.ToString();
            inOrder(root.right);

            return " " + total;
        }

        public string preOrder(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }

            total += " " + root.value.ToString();

            preOrder(root.left);
            preOrder(root.right);

            return " " + total;
        }
         public string total = "";
        public int iteration = 1;
        public string step = "";
        public string postOrder(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }

            postOrder(root.left);
            postOrder(root.right);
            total += " " + root.value.ToString();

            return " " + total;
        }

        public string breadthFirst(Node<T> root)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                Node<T> temp = queue.Dequeue();
                if (temp == null)
                    continue;
                Console.WriteLine(temp.value);

                queue.Enqueue(temp.left);
                queue.Enqueue(temp.right);
                iteration++;
            }

            return "";
        }
        public Node<T> smallest;
        private int numelements;

        public Node<T> findSmallest(Node<T> root)
        {
            if (root == null)
            {
                return default;
            }

            if (smallest == default)
            {
                smallest = root;
            }
            else if (root != default && root.value.CompareTo(smallest.value) < 0)
            {
                smallest = root;
            }

            findSmallest(root.left);
            findSmallest(root.right);

            return smallest;
        }
    }
}
