using Contracts.GraphWalker.Contracts;
using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GraphWalker.Visitor
{
    public class LockMarkuper : IVisitor
    {
        public void Visit(SkillNode skillNode)
        {
            if (!skillNode.IsLocked())
            {
                skillNode.ShouldGoDown = true;
                return;
            }

            bool canBeUnlocked = true;
            skillNode.DependsOn
                .ForEach(baseSkillNode => canBeUnlocked = canBeUnlocked && !baseSkillNode.IsLocked());

            if (canBeUnlocked) skillNode.SetCanBeUnlocked();
            skillNode.ShouldGoDown = false;            
        }
    }
}
