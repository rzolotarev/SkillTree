using Contracts.GraphWalker.Contracts;
using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.GraphWalker
{
    public interface IGraphWalker
    {
        void WalkThrough(SkillNode rootNode);
    }
}
