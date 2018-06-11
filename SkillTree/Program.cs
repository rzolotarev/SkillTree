using Contracts.Nodes.ViewModels;
using Services.GraphBuilder;
using Services.GraphWalker;
using Services.GraphWalker.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphBuilderWarrior = new GraphBuilder();
            var rootNode = new SkillNode("Warrior", false, true);
            var strikeNode = new SkillNode("Strike");
            var roundHouseKick = new SkillNode("Roundhouse Kick");
            var slashNode = new SkillNode("Slash");
            var hitNode = new SkillNode("Hit");
            var knockoutNode = new SkillNode("Knockout");
            var doubleStrikeNode = new SkillNode("Double Strike");
            graphBuilderWarrior
                    .AddBranchNode(rootNode)
                    .AddBranchNode(strikeNode)
                    .AddNode(doubleStrikeNode)
                    .AddNodeFromClosestBranchNode(slashNode)
                    .AddNode(roundHouseKick)
                    .AddNodeFromClosestBranchNode(hitNode)
                    .AddNode(knockoutNode)
                    .AddNode(roundHouseKick);


            var graphWalker = new GraphWalker(new LockMarkuper());
            rootNode.Unlock();
            graphWalker.WalkThrough(rootNode);

            strikeNode.Unlock();
            graphWalker.WalkThrough(rootNode);

            slashNode.Unlock();
            graphWalker.WalkThrough(rootNode);

            hitNode.Unlock();
            graphWalker.WalkThrough(rootNode);

            knockoutNode.Unlock();
            graphWalker.WalkThrough(rootNode);
        }
    }
}
