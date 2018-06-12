## Description

Skill Tree.

Key points:
1. I used a visitor pattern to process nodes of a skill tree, because if logic is more complex and there is a need to use different types of nodes, the visitor will be a great helper 
to process every type of node independently;
2. GraphWalker can be run starting from the root, and not only from the just unlocked node;
3. GraphProvider provides a facade to Unlock a skillNode and run a GraphWalker to mark possible skill nodes as "CanBeUnlocked";