using Contracts.GraphBuilder.Contracts;
using Contracts.GraphProvider.Contracts;
using Contracts.GraphWalker;
using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GraphProvider
{
    public class SkillsGraphProvider : IGraphProvider
    {        
        private readonly IGraphWalker _graphWalker;

        public SkillsGraphProvider(IGraphWalker graphWalker)
        {            
            _graphWalker = graphWalker;
        }

        public void Unlock(SkillNode skillNode)
        {
            skillNode.Unlock();
            _graphWalker.WalkThrough(skillNode);            
        }
    }
}
