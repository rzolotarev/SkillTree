using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.GraphWalker.Contracts
{
    public interface IVisitor
    {
        void Visit(SkillNode node);
    }
}
