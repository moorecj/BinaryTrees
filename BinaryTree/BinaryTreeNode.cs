using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode
    {
        public int value { get; set; }

        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }

        public static BinaryTreeNode FindNode(BinaryTreeNode root, int valueToFind)
        {
            if (root == null)
            {
                return root;
            }
            else if (root.value == valueToFind)
            {
                return root;
            }
            else if (valueToFind < root.value)
            {
                return FindNode(root.LeftNode, valueToFind);
            }
            else
            {
                return FindNode(root.RightNode, valueToFind);
            }
        }

        public void Insert(BinaryTreeNode node)
        {
            if (node.value < value)
            {
                if (LeftNode != null)
                    LeftNode.Insert(node);
                else
                    LeftNode = node;
            }
            else
            {
                if (RightNode != null)
                    RightNode.Insert(node);
                else
                    RightNode = node;
            }
        }

        public static BinaryTreeNode Delete(BinaryTreeNode rootNode, int valueToDelete)
        {
            if (rootNode == null)
                return rootNode;

            if (valueToDelete < rootNode.value)
            {
                rootNode.LeftNode = Delete(rootNode.LeftNode, valueToDelete);
            }
            else if (valueToDelete > rootNode.RightNode.value)
            {
                rootNode.RightNode = Delete(rootNode.RightNode, valueToDelete);
            }
            else
            {
                //no child case
                if (rootNode.LeftNode == null && rootNode.RightNode == null)
                {
                    rootNode = null;
                }
                else if (rootNode.LeftNode == null)
                {
                    BinaryTreeNode temp = rootNode;
                    rootNode = rootNode.RightNode;
                    temp = null;
                }
                else if (rootNode.RightNode == null)
                {
                    BinaryTreeNode temp = rootNode;
                    rootNode = rootNode.LeftNode;
                    temp = null;
                }
                else
                {
                    BinaryTreeNode min = FindMin(rootNode.RightNode);
                    rootNode.value = min.value;
                    rootNode.RightNode = Delete(rootNode.RightNode, min.value);
                }
            }

            return rootNode;
        }

        private static BinaryTreeNode FindMin(BinaryTreeNode node)
        {
            if (node.LeftNode == null)
                return node;
            else
                return FindMin(node.LeftNode);
        }
    }
}