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
        private Node root { get; set; }
        private Node lastNode { get; set; }
        private Stack<Node> branchNodes { get; set; }

        public GraphBuilder()
        {
            branchNodes = new Stack<Node>();
        }

        public IGraphBuilder AddNode(Node newNode)
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

        public IGraphBuilder AddBranchNode(Node newNode)
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

        public IGraphBuilder AddNodeFromClosestBranchNode(Node newNode)
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

                var branchNode = branchNodes.Pop();
                branchNode.DependantNodes.Add(newNode);
                newNode.DependsOn.Add(branchNode);                
                lastNode = newNode;                
            }

            return this;
        }     

        public Node GetRoot()
        {
            return root;
        } 
    }
}
