/*using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CyberAttackDefence
{
    public class NonBalancedBT
    {
        public TreeNode root;

        This function traverse the skewed binary tree and
           stores its nodes pointers in vector nodes[]
        public static void storeBSTNodes(TreeNode root, List<TreeNode> nodes)
        {
            // Base case 
            if (root == null)
            {
                return;
            }

            // Store nodes in Inorder (which is sorted 
            // order for BST) 
            storeBSTNodes(root.Left, nodes);
            nodes.Add(root);
            storeBSTNodes(root.Right, nodes);
        }

        Recursive function to construct binary tree
        public virtual TreeNode buildTreeUtil(List<TreeNode> nodes, int start, int end)
        {
            // base case 
            if (start > end)
            {
                return null;
            }

            Get the middle element and make it root
            int mid = (start + end) / 2;
            TreeNode node = nodes[mid];

            Using index in Inorder traversal, construct
               left and right subtress
            node.Left = buildTreeUtil(nodes, start, mid - 1);
            node.Right = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }

        // This functions converts an unbalanced BST to 
        // a balanced BST 
        public virtual TreeNode buildTree(TreeNode root)
        {
            // Store nodes of given BST in sorted order 
            List<TreeNode> nodes = new List<TreeNode>();
            storeBSTNodes(root, nodes);

            // Constructs BST from nodes[] 
            int n = nodes.Count;
            return buildTreeUtil(nodes, 0, n - 1);
        }

        Function to do preorder traversal of tree
        public virtual void preOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.MinSeverity + " " + node.MaxSeverity + " ");
            preOrder(node.Left);
            preOrder(node.Right);
        }

        public static List<TreeNode> JsonToList(string jsonPath)
        {
            using StreamReader reader = new(jsonPath);
            var json = reader.ReadToEnd();
            List<TreeNode> nodeList = JsonConvert.DeserializeObject<List<TreeNode>>(json);
            return nodeList;
        }
    }
}*/