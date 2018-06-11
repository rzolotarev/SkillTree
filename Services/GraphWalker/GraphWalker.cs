using Contracts.GraphWalker;
using Contracts.GraphWalker.Contracts;
using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GraphWalker
{
    public class GraphWalker : IGraphWalker
    {
        private readonly IVisitor _visitor;
        public GraphWalker(IVisitor visitor)
        {
            _visitor = visitor;
        }

        public void WalkThrough(SkillNode currentNode)
        {   
            var walkingQueue = new Queue<SkillNode>(currentNode.DependantNodes);            
            while(walkingQueue.Count() != 0)
            {
                var skillNode = walkingQueue.Dequeue();
                _visitor.Visit(skillNode);
                if (skillNode.ShouldGoDown)
                    skillNode.DependantNodes.ForEach(walkingQueue.Enqueue);
            }            
        }
    }
}
