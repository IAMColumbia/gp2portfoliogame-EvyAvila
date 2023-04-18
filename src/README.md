Source Code goes Here

Make a branch for each milestone.
Commit work for each milestone to the branch.
Merge the brance back to the master for each Milestone
Produce a Build of each Milestone and add to build folder 

Dev Log 3:

I've created a MVP in Unity for my game Sneak. 

I first updated the Input System to use the new version. While it took some time
for converting and changing some of the methods, I only had one block. I wanted
to use one Action with three binding paths for the disguises. Where, it would hold 
three keys/buttons that would check if the specific button was pressed. However, 
while I was searching online and experimenting, nothing was working. Instead, as
a technical debt, I created three separate Actions. This resulted me into having to
check the value three times, which is not correct. I'll have to continue working on
it.

Next, I added a simple interface. The main purpose is to show which disguises the 
player found and are able to use. I attempted to include text with the Text Mesh Pro,
however, I didn't enjoy how much the text would move when adjusting the Game View. 
Even while it was anchored, I decided to remove it entirely and come up with a better solution
at a later time. 

Afterwards, I updated the Enemies by adding movement. I wanted to have the the enemies
feel a real threat as some will walk around or standing. Thus, it help create more of a fun 
challenge. I had an issue where the player would get caught at the start, which I change a 
few conditions for it to stop.

Finally, I expanding the levels by making them larger and longer. It gave room for both the enemies
and the walls to be placed. Thus, looking more active. 

The only point I didn't get to update was the art assets. While it was on my To Do List, it wasn't a 
priority to have completed.

For the Final update, I aim to:
* Add an additional obstacle
* Create a title screen
* Update the art
* Create and insert music
* Create ending transitions: A win and lose end screen
