using System;

namespace BTS
{
    public class BST<T> where T : IComparable<T>
    {
        Node root;

        public void Add(T value) //O(logN) -> O(n)
        {
            if (root == null) // empty tree
            {
                root = new Node(value);
                return;
            }

            Node tmp = root;
            while (true)
            {
                if (value.CompareTo(tmp.data) >= 0) // value >= tmp.data ->go right
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(value);
                        break;
                    }
                    tmp = tmp.right;
                }
                else // go left (value < tmp.data)
                {
                    if (tmp.left == null)
                    {
                        tmp.left = new Node(value);
                        break;
                    }
                    tmp = tmp.left;
                }
            }

        }
        public void Delete(T key) { root = Delete(root, key); }
        private Node Delete(Node root, T key)
        {

            if (root == null) // tree is empty
                return root;

            if (key.CompareTo(root.data) < 0)
                root.left = Delete(root.left, key);
            else if (key.CompareTo(root.data) > 0)
                root.right = Delete(root.right, key);

            else // key is same as root's key
            {
                // only one child or no child
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // two children
                root.data = MinValue(root.right);

                root.right = Delete(root.right, root.data);
            }
            return root;
        }

        private T MinValue(Node root)
        {
            T minValue = root.data;
            while (root.left != null)
            {
                minValue = root.left.data;
                root = root.left;
            }
            return minValue;
        }


        public bool Search(T item, out T foundItem)
        {
            Node tmp = root;

            while (tmp != null)
            {
                if (item.CompareTo(tmp.data) == 0)
                {
                    foundItem = tmp.data;
                    return true;
                }
                if (item.CompareTo(tmp.data) < 0)
                {
                    tmp = tmp.left;
                }
                else tmp = tmp.right;
            }

            foundItem = default;
            return false;
        }

        public void ScanInOrder(Action<T> itemAction) => ScanInOrder(root, itemAction);


        private void ScanInOrder(Node currentNode, Action<T> itemAction)
        {
            if (currentNode == null) return;

            ScanInOrder(currentNode.left, itemAction);
            itemAction(currentNode.data);
            ScanInOrder(currentNode.right, itemAction);
        }

        public int GetDepth() => GetDepth(root);



        private int GetDepth(Node currentNode)
        {
            if (currentNode == null) return 0;

            return Math.Max(GetDepth(currentNode.left), GetDepth(currentNode.right)) + 1;
        }

        class Node
        {
            public T data;
            public Node left;
            public Node right;

            public Node(T data)
            {
                this.data = data;
            }
        }
    }
}
