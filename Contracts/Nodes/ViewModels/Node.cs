using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Nodes.ViewModels
{
    public class Node
    {
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public bool CanBeUnlocked { get; set; }
        public List<Node> DependsOn { get; set; }
        public List<Node> DependantNodes { get; set; }
        public bool ShouldGoDown { get; set; }

        public Node(string name, bool isLocked = true, bool canBeUnlocked = false)
        {
            Name = name;
            IsLocked = isLocked;
            CanBeUnlocked = canBeUnlocked;
            DependsOn = new List<Node>();
            DependantNodes = new List<Node>();
        }
    }
}
