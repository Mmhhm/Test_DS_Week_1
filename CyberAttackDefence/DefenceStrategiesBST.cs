using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace CyberAttackDefence
{
    public class DefenceStrategiesBST
    {
        public TreeNode root;
        public DefenceStrategiesBST()
        {
            root = null;
        }


        // Insert the defences into a BST
        public TreeNode Insert()
        {
            string defenceJsonPath = "C:\\Users\\mkf\\Desktop\\defenceStrategiesBalanced.json";
            List<TreeNode> nodeList = TreeNode.JsonToList(defenceJsonPath);

            foreach (TreeNode node in nodeList)
            {
                RecursionIns(root, node);
            }
            return root;
        }

        private TreeNode RecursionIns(TreeNode currNode, TreeNode newNode)
        {
            if (root == null) { root = newNode; return newNode; }
            
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

        
        // Start the attacks and defences
        public void AttackDefenceInAction()
        {
            string weakAttack = "Attack severity is below the threshold. Attack is ignored.";
            string DefNotFound = "No suitble defence was found. Brace for impact!";

            string threatJsonPath = "C:\\Users\\mkf\\Desktop\\threats.json";
            List<Threat> threatList = Threat.JsonToList(threatJsonPath);

            foreach (Threat threat in threatList)
            {
                int threatSeverity = Threat.CalcThreatSeverity(threat);

                if (threatSeverity < GetMinDefence(root)) { Console.WriteLine(weakAttack + "\n"); Thread.Sleep(2000); continue; } // Break from loop if attack is weak

                TreeNode defence = Search(threatSeverity);  // Search the defence for the threat

                if (defence == null) { Console.WriteLine(DefNotFound + "\n"); Thread.Sleep(2000); continue; }
                Console.WriteLine($"-{defence.Defenses[0]}\n-{defence.Defenses[1]}\n");

                Thread.Sleep(2000);
            }

        }


        // Search the defence for the threat
        public TreeNode Search(int value)
        {
            return RecSearch(root, value);
        }

        public TreeNode RecSearch(TreeNode node, int value)
        {
            if (node == null) { return null; }

            int maxSev = node.MaxSeverity;
            int minSev = node.MinSeverity;

            if (value >= minSev && value <= maxSev)
            {
                return node;
            }
            else if (value < minSev)
            {
                return RecSearch(node.Left, value);
            }
            else if (value > maxSev)
            {
                return RecSearch(node.Right, value);
            }
            return node;
        }


        // Get the leftist node in the defence tree
        public int? GetMinDefence()
        {
            return GetMinDefence(root);
        }

        private int? GetMinDefence(TreeNode node)
        {
            if (node == null) return null;
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.MinSeverity;
        }


        // Print the tree PreOrder in a row (testing)
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

        private void PrintTreeRec(TreeNode node, string space, bool rightLast)
        {
            if (node != null)
            {
                Console.Write(space);
                if (rightLast)
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


        // Print the tree in order (for testing)
        public void Inorder(TreeNode root)
        {
            if (root != null)
            {
                Inorder(root.Left);
                Console.Write(root.MinSeverity + " " + root.MaxSeverity + " ");
                Inorder(root.Right);
            }
        }
    }
}

