using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAttackDefence
{
    public class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }


        // TODO move from here
        public static List<Threat> JsonToList(string jsonPath)
        {
            using StreamReader reader = new(jsonPath);
            var json = reader.ReadToEnd();
            List<Threat> nodeList = JsonConvert.DeserializeObject<List<Threat>>(json);
            return nodeList;
        }


        // Get threat sevirity
        public static int CalcThreatSeverity(Threat threat)
        {
            int severity = (threat.Volume * threat.Sophistication) + TargetValue(threat);
            return severity;
        }



        // Get target value
        private static int TargetValue(Threat threat)
        {
            string target = threat.Target;
            switch (target)
            {
                case "Web Server":
                    return 10;
                case "Database":
                    return 15;
                case "User Credentials":
                    return 20;
                default:
                    return 5;
            }
        }
    }
}
