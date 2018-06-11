using Contracts.Nodes.ViewModels;
using Services.GraphBuilder;
using Services.GraphProvider;
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
            RunWarriorSkillsGraph();
            RunMageSkillsGraph();
        }

        private static void RunMageSkillsGraph()
        {
            var graphBuilderMage = new GraphBuilder();
            var mageNode = new SkillNode("Mage", true, true);
            var fireBallNode = new SkillNode("FireBall");
            var elShockNode = new SkillNode("Electroshock");
            var thunderNode = new SkillNode("Thunderbolt");
            var freezeNode = new SkillNode("Freeze");
            var snowStormNode = new SkillNode("Snowstorm");
            graphBuilderMage
                .AddNode(mageNode)
                .AddBranchNode(fireBallNode)
                .AddNode(elShockNode)
                .AddNode(thunderNode)
                .AddNodeFromClosestBranchNode(freezeNode)
                .AddNode(snowStormNode);

            var skillGrappProvider = new SkillsGraphProvider(new GraphWalker(new LockMarkuper()));
            skillGrappProvider.Unlock(mageNode);

            skillGrappProvider.Unlock(fireBallNode);

            skillGrappProvider.Unlock(elShockNode);

            skillGrappProvider.Unlock(thunderNode);

            skillGrappProvider.Unlock(freezeNode);

            skillGrappProvider.Unlock(snowStormNode);
        }

        public static void RunWarriorSkillsGraph()
        {
            var graphBuilderWarrior = new GraphBuilder();
            var rootNode = new SkillNode("Warrior", true, true);
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

            var skillGrappProvider = new SkillsGraphProvider(new GraphWalker(new LockMarkuper()));
            skillGrappProvider.Unlock(rootNode);

            skillGrappProvider.Unlock(strikeNode);

            skillGrappProvider.Unlock(slashNode);

            skillGrappProvider.Unlock(hitNode);

            skillGrappProvider.Unlock(knockoutNode);
        }
    }
}
