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
                .AddNode(new Node("Mage"))
                .AddBranchNode(new Node("FireBall"))
                .AddNode(new Node("Electroshock"))
                .AddNode(new Node("Thunderbolt"))
                .AddNodeFromClosestBranchNode(new Node("Freeze"))
                .AddNode(new Node("Snowstorm"));

            Assert.AreEqual("Thunderbolt", graphBuilderMage.GetRoot().DependantNodes[0].DependantNodes[0].DependantNodes[0].Name);
        }

        [Test]
        public void TestMultipleDependsOnNodes()
        {
            var graphBuilderWarrior = new GraphBuilder();
            var roundHouseKick = new Node("Roundhouse Kick");

            graphBuilderWarrior
                    .AddBranchNode(new Node("Warrior"))
                    .AddBranchNode(new Node("Strike"))
                    .AddNode(new Node("Double Strike"))
                    .AddNodeFromClosestBranchNode(new Node("Slash"))
                    .AddNode(roundHouseKick)
                    .AddNodeFromClosestBranchNode(new Node("Hit"))
                    .AddNode(new Node("Knockout"))
                    .AddNode(roundHouseKick);

            Assert.AreEqual(2, graphBuilderWarrior.GetRoot().DependantNodes[0].DependantNodes[1].DependantNodes[0].DependsOn.Count);
        }
    
    }
}
