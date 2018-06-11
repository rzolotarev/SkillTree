using Contracts.Nodes.ViewModels;
using NUnit.Framework;
using Services.GraphBuilder;
using Services.GraphWalker;
using Services.GraphWalker.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Tests
{
    [TestFixture]
    public class GraphWalkerTest
    {
        [Test]
        public void TestUnlockFirstElement()
        {
            var graphBuilderWarrior = new GraphBuilder();
            var roundHouseKick = new SkillNode("Roundhouse Kick");

            graphBuilderWarrior
                    .AddBranchNode(new SkillNode("Warrior", false, true))
                    .AddBranchNode(new SkillNode("Strike"))
                    .AddNode(new SkillNode("Double Strike"))
                    .AddNodeFromClosestBranchNode(new SkillNode("Slash"))
                    .AddNode(roundHouseKick)
                    .AddNodeFromClosestBranchNode(new SkillNode("Hit"))
                    .AddNode(new SkillNode("Knockout"))
                    .AddNode(roundHouseKick);

            var root = graphBuilderWarrior.GetRoot();
            root.Unlock();
            var graphWalker = new GraphWalker(new LockMarkuper());            
            graphWalker.WalkThrough(root);

            Assert.AreEqual(true, graphBuilderWarrior.GetRoot().DependantNodes[0].CanBeUnlocked());
            Assert.AreEqual(true, graphBuilderWarrior.GetRoot().DependantNodes[1].CanBeUnlocked());
        }

        [Test]
        public void TestCanBeUnlockedRoundHouseKick_WithPartlyUnlockedParents()
        {
            var graphBuilderWarrior = new GraphBuilder();
            var roundHouseKick = new SkillNode("Roundhouse Kick");

            graphBuilderWarrior
                    .AddBranchNode(new SkillNode("Warrior", false, true))
                    .AddBranchNode(new SkillNode("Strike"))
                    .AddNode(new SkillNode("Double Strike"))
                    .AddNodeFromClosestBranchNode(new SkillNode("Slash"))
                    .AddNode(roundHouseKick)
                    .AddNodeFromClosestBranchNode(new SkillNode("Hit"))
                    .AddNode(new SkillNode("Knockout"))
                    .AddNode(roundHouseKick);

            var root = graphBuilderWarrior.GetRoot();
            root.Unlock();
            var graphWalker = new GraphWalker(new LockMarkuper());            
            var strikeNode = graphBuilderWarrior.GetRoot().DependantNodes[0];
            strikeNode.Unlock();
            graphWalker.WalkThrough(root);
            var slashNode = strikeNode.DependantNodes[1];
            slashNode.Unlock();
            graphWalker.WalkThrough(root);

            Assert.AreEqual(false, slashNode.CanBeUnlocked());            
        }

        [Test]
        public void TestCanBeUnlockedRoundHouseKick_WithUnlockedParents()
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
            graphWalker.WalkThrough(strikeNode);

            slashNode.Unlock();
            graphWalker.WalkThrough(slashNode);

            hitNode.Unlock();
            graphWalker.WalkThrough(hitNode);

            knockoutNode.Unlock();
            graphWalker.WalkThrough(knockoutNode);

            Assert.AreEqual(true, roundHouseKick.CanBeUnlocked());
        }
    }
}
