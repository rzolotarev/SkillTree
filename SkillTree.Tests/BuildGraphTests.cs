using Contracts.Nodes.ViewModels;
using NUnit.Framework;
using Services.GraphBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Tests
{
    [TestFixture]
    public class BuildGraphTests
    {
        [Test]
        public void TestAddingNode()
        {
            var graphBuilderMage = new GraphBuilder();
            graphBuilderMage
                .AddNode(new SkillNode("Mage"))
                .AddBranchNode(new SkillNode("FireBall"))
                .AddNode(new SkillNode("Electroshock"))
                .AddNode(new SkillNode("Thunderbolt"))
                .AddNodeFromClosestBranchNode(new SkillNode("Freeze"))
                .AddNode(new SkillNode("Snowstorm"));

            Assert.AreEqual("Thunderbolt", graphBuilderMage.GetRoot().DependantNodes[0].DependantNodes[0].DependantNodes[0].Name);
        }

        [Test]
        public void TestMultipleDependsOnNodes()
        {
            var graphBuilderWarrior = new GraphBuilder();
            var roundHouseKick = new SkillNode("Roundhouse Kick");

            graphBuilderWarrior
                    .AddBranchNode(new SkillNode("Warrior"))
                    .AddBranchNode(new SkillNode("Strike"))
                    .AddNode(new SkillNode("Double Strike"))
                    .AddNodeFromClosestBranchNode(new SkillNode("Slash"))
                    .AddNode(roundHouseKick)
                    .AddNodeFromClosestBranchNode(new SkillNode("Hit"))
                    .AddNode(new SkillNode("Knockout"))
                    .AddNode(roundHouseKick);

            Assert.AreEqual(2, graphBuilderWarrior.GetRoot().DependantNodes[0].DependantNodes[1].DependantNodes[0].DependsOn.Count);
        }
    
    }
}
