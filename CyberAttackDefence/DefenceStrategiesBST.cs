using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace CyberAttackDefence
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public TreeNode(int minSev, int maxSev, List<string> defenses)
        {
            Left = Right = null;
            MinSeverity = minSev;
            MaxSeverity = maxSev;
            Defenses = defenses;
        }

        public static List<TreeNode> JsonToArray()
        {
            string jsonPath = "C:\\Users\\mkf\\Desktop\\defenceStrategiesBalanced.json";
            using StreamReader reader = new(jsonPath);
            var json = reader.ReadToEnd();
            List<TreeNode> nodeList = JsonConvert.DeserializeObject<List<TreeNode>>(json);
            return nodeList;
        }
    }


    public class DefenceStrategiesBST
    {
        public TreeNode root;
        public DefenceStrategiesBST()
        {
            root = null;
        }


        public TreeNode Insert()
        {
            List<TreeNode> nodeList = TreeNode.JsonToArray();

            foreach (TreeNode node in nodeList)
            {
                RecursionIns(root, node);
            }
            return root;
        }

        private TreeNode RecursionIns(TreeNode currNode, TreeNode newNode)
        {
            if (root == null) { root = newNode;  return newNode; }
            if (currNode.MinSeverity >= newNode.MinSeverity)
            {
                if (currNode.Left == null)
                {
                    currNode.Left = newNode;
                    return newNode;
                }
                return RecursionIns(currNode.Left, newNode);
            }
            else if (currNode.MinSeverity < newNode.MinSeverity)
            {
                if (currNode.Right == null)
                {
                    currNode.Right = newNode;
                    return newNode;
                }
                return RecursionIns(currNode.Right, newNode);
            }
            return newNode;
        }


        // Print the tree in order
        public void Inorder(TreeNode root)
        {
            if (root != null)
            {
                Inorder(root.Left);
                Console.Write(root.MinSeverity + " " + root.MaxSeverity + " ");
                Inorder(root.Right);
            }
        }



        // PreOrder print
        public void PrintPreOrder(TreeNode node)
        {
            if (node == null) { return; }

            Console.Write(node.MinSeverity + " " + node.MaxSeverity + " ");

            PrintPreOrder(node.Left);
            PrintPreOrder(node.Right);
        }




        // Prints PreOrder tree
        public void PrintTree(TreeNode node)
        {
            PrintTreeRec(node, "", true);
        }

        private void PrintTreeRec(TreeNode node, string space, bool last)
        {
            if (node != null)
            {
                Console.Write(space);
                if (last)
                {
                    Console.Write("----Right ");
                    space += "   ";
                }
                else
                {
                    Console.Write("----Left ");
                    space += "|  ";
                }
                Console.WriteLine($"{node.MinSeverity} - {node.MaxSeverity} Defenses: {node.Defenses[0]}, {node.Defenses[1]}");

                PrintTreeRec(node.Left, space, false);
                PrintTreeRec(node.Right, space, true);
            }
        }
    }
}

