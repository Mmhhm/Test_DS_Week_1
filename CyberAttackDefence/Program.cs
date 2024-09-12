using CyberAttackDefence;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
public class Program
{
    public static void GetTree()
    {
        string JsonPath = "C:\\Users\\mkf\\Desktop\\IDF DATA Course\\Tests\\CyberAttackDefence\\defenceStrategiesBalanced.json";
        List<TreeNode> nodeList = TreeNode.JsonToList(JsonPath);

/*        NonBalancedBT NBBT = new NonBalancedBT();

        NonBalancedBT.storeBSTNodes(NBBT.root, nodeList);*/

        foreach (TreeNode node in nodeList)
        {
            Console.WriteLine(node.MinSeverity + " " + node.MaxSeverity);
        }
    }
    public static void Main()
    {
        GetTree();

        var tree = new DefenceStrategiesBST();

        TreeNode root = tree.Insert();

        // Prints tree in order
        tree.Inorder(root); 

        Console.WriteLine();
        tree.PrintPreOrder(root);

        Console.WriteLine();
        tree.PrintTree(root);

        Console.WriteLine();
        tree.AttackDefenceInAction();
        // defenceStrategies

    }



}