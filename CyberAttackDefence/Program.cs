using CyberAttackDefence;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
public class Program
{
    public static void Main()
    {
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
    }



}