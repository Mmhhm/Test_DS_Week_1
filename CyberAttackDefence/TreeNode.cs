using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAttackDefence
{
    // TODO move this class to a new file
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

        // TODO move from here
        public static List<TreeNode> JsonToList(string jsonPath)
        {
            using StreamReader reader = new(jsonPath);
            var json = reader.ReadToEnd();
            List<TreeNode> nodeList = JsonConvert.DeserializeObject<List<TreeNode>>(json);
            return nodeList;
        }
    }
}
