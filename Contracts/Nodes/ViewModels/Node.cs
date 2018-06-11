using Contracts.GraphWalker.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Nodes.ViewModels
{
    public class SkillNode
    {
        public string Name { get; set; }
        private bool isLocked { get; set; }
        private bool canBeUnlocked { get; set; }
        public List<SkillNode> DependsOn { get; set; }
        public List<SkillNode> DependantNodes { get; set; }
        public bool ShouldGoDown { get; set; }

        public SkillNode(string name, bool isLocked = true, bool canBeUnlocked = false)
        {
            Name = name;
            this.isLocked = isLocked;
            this.canBeUnlocked = canBeUnlocked;
            DependsOn = new List<SkillNode>();
            DependantNodes = new List<SkillNode>();
            ShouldGoDown = true;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public bool IsLocked()
        {
            return isLocked;
        }

        public void SetCanBeUnlocked()
        {
            canBeUnlocked = true;
        }

        public bool CanBeUnlocked()
        {
            return canBeUnlocked;
        }

        public void Unlock()
        {
            if (!canBeUnlocked)
                return;

            if (!isLocked)
                return;

            isLocked = false;
        }
    }
}
