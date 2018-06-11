using Contracts.GraphBuilder.Contracts;
using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GraphBuilder
{
    public class GraphBuilder : IGraphBuilder
    {
        private SkillNode root { get; set; }
        private SkillNode lastNode { get; set; }
        private Stack<SkillNode> branchNodes { get; set; }

        public GraphBuilder()
        {
            branchNodes = new Stack<SkillNode>();
        }

        public IGraphBuilder AddNode(SkillNode newNode)
        {
            if (root == null)
            {
                root = newNode;
                lastNode = newNode;
            }
            else
            {
                lastNode.DependantNodes.Add(newNode);
                newNode.DependsOn.Add(lastNode);                

                lastNode = newNode;
            }

            return this;
        }

        public IGraphBuilder AddBranchNode(SkillNode newNode)
        {
            if (root == null)
            {
                root = newNode;
                lastNode = newNode;
                branchNodes.Push(root);
            }
            else
            {
                lastNode.DependantNodes.Add(newNode);
                newNode.DependsOn.Add(lastNode);
                branchNodes.Push(newNode);

                lastNode = newNode;
            }

            return this;
        }

        public IGraphBuilder AddNodeFromClosestBranchNode(SkillNode newNode, bool withPop = true)
        {
            if (root == null)
            {
                root = newNode;
                lastNode = newNode;
            }
            else
            {
                if (branchNodes.Peek() == null)
                    return this;

                SkillNode branchNode;
                if (withPop) branchNode = branchNodes.Pop();
                else branchNode = branchNodes.Peek();

                branchNode.DependantNodes.Add(newNode);
                newNode.DependsOn.Add(branchNode);                
                lastNode = newNode;                
            }

            return this;
        }     

        public SkillNode GetRoot()
        {
            return root;
        } 
    }
}
