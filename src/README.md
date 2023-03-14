Source Code goes Here

Make a branch for each milestone.
Commit work for each milestone to the branch.
Merge the brance back to the master for each Milestone
Produce a Build of each Milestone and add to build folder 

Dev Log 1 
I've created a POC in Unity for my game Sneak. 

I first worked on creating an "auto generated" level.
It mainly has set locations and randomly sets the game object
and rotation. Since I was testing in a small location, I may expand
the area for the player to travel to the next level by teleporting. As
a way to feel as if they moved to another floor.
 
Next, I created a MainPlayerController script that consist of
simple movement and the ability to switch between disguises.
I used the old Input system as temporary use to make sure the 
commands and changes were correct.

Finally, I created a door interaction for the player to pass by and
enter the next level.

For the next update, I aim to:
* Insert enemies
* Add function to earn disguises
* Expand the level
* Create ending states (Win/Lose) 