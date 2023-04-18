Source Code goes Here

Make a branch for each milestone.
Commit work for each milestone to the branch.
Merge the brance back to the master for each Milestone
Produce a Build of each Milestone and add to build folder 

Dev Log 2:
I've created a VS in Unity for my game Sneak. I was able to complete the main objectives from
my checklist.

I first worked on adding the enemies into the game. At the currest version, the enemies don't move,
but are placed near the door where the players needs to enter. Their purpose is to catch the player 
who isn't in disguise. If the player is close to their range without a disguise or is wearing the wrong
disguise will cause a game over.

Next, I added a function where the player can earn and use the disguises they find during the level.
I also fixed the issue where the player can easily switch between disguises. Now, if the player is 
wearing a disguise, they cannot switch until the player returns back to normal. 

Next, I expanded the level. It's in a similar format with the walls and set positions. The main addition
is the player changing their position to the next floor level. 

Finally, I created a simple end states for when the player wins or loses. The player wins by making to the
last floor or level. The player loses if they are caught by the enemies. I added a condition where, if the
player wins or loses, the controller method is not called. 

For the next update, I aim to:
* Convert the controls to the new Input System
* Add an interface
* Expand the level further
* Update the art assets
