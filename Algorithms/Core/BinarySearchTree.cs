using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    /// <summary>
    /// Classic binary search tree implmentation based on Bob sedgewicks cool recursion technique!
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class BinarySearchTree <K, V> where K:IComparable<K> {
        
        /// <summary>
        /// Inner class for treenode to hide the implmentation from others!
        /// </summary>
        /// <typeparam name="K">Key of type K</typeparam>
        /// <typeparam name="V">Value of type V.</typeparam>
        private class Node<K, V> where K : IComparable<K> {
            
            private K key;
            private V value;

            public Node(K key, V value) {

                if (null == key || null == value) {
                    throw new ArgumentNullException("Key and Value must be non-null.", innerException:null);
                }
               
                this.key = key;
                this.value = value;
            }

            public K Key
            {
                get { return key; }
                private set { }
            }

            public V Value
            {
                get { return value; }
                set { this.value = value; }
            }

            public Node<K, V> Left
            {
                get;
                set;
            }

            public Node<K, V> Right
            {
                get;
                set;
            }

            public int Size
            {
                get;
                set;
            }

            public override string ToString()
            {
                return key.ToString() + " - " + value.ToString();
            }
        }

        private Node<K, V> root = null;

        public virtual void Put(K key, V value) {

            if (null == value) {
                delete(root, key);
            }

            root = Put(root, key, value);
        }

        private Node<K, V> Put(Node<K, V> root, K key, V value)
        {
            if (null == root) {
                return new Node<K, V>(key, value);
            }

            if (key.CompareTo(root.Key) < 0) {
                root.Left = Put(root.Left, key, value);
            }
            else if (key.CompareTo(root.Key) > 0)
            {
                root.Right = Put(root.Right, key, value);
            }
            else
            {
                root.Value = value;
            }

            return root;
        }

        public V Get(K key)
        {
            if (null == key) {
                throw new ArgumentNullException("key");
            }

            Node<K, V> currentNode = root;
            while (null != currentNode)
            {
                if (key.CompareTo(currentNode.Key) < 0) {
                    currentNode = currentNode.Left;
                }
                else if (key.CompareTo(currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode.Value;
                }
            }

            return default(V);
        }

        private void delete(Node<K, V> root, K key)
        {
            throw new NotImplementedException();
        }

        #region Order Statistics

        public K Minimum() {
            if (null == root) { return default(K); }

            Node<K, V> currentNode = root;
            while (null != currentNode.Left) { currentNode = currentNode.Left; }

            return currentNode.Key;
        }

        public K Maximum()
        {
            if (null == root) { return default(K); }

            Node<K, V> currentNode = root;
            while (null != currentNode.Right) { currentNode = currentNode.Right; }

            return currentNode.Key;
        }

        #endregion
    }
}
