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
        IGraphBuilder AddNode(Node newNode);
        IGraphBuilder AddBranchNode(Node newNode);
        IGraphBuilder AddNodeFromClosestBranchNode(Node newNode);        
        Node GetRoot();
    }
}
