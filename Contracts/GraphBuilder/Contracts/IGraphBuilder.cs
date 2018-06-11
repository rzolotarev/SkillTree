using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.GraphBuilder.Contracts
{
    public interface IGraphBuilder
    {
        IGraphBuilder AddNode(SkillNode newNode);
        IGraphBuilder AddBranchNode(SkillNode newNode);
        IGraphBuilder AddNodeFromClosestBranchNode(SkillNode newNode, bool withPop = true);        
        SkillNode GetRoot();
    }
}
