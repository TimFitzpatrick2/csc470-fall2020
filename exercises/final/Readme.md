# Target Practice

### Title Screen:
The title screen will use mouse input with left click to select a button. The user will have the option of beginning the game or reading the instructions first. Once the user has read the instructions they can click the begin game button which will take the user to the first level. 
### Details: ###
Target Practice is an archery shooting game. A Bow and Arrow will shoot arrows at targets. The users will only be given unlimited arrows and the users has to hit all of the targets to move to the next level. The Targets are made of 4 different layers as each layer will destroy as it is hit by an arrow. 
The game input will be the arrow keys and space bar. The arrow keys will be used to change the direction of the arrows. The space bar allows the user to shoot the arrows. 
Level 1 will take place in a Desert with a few mountains, Level 2 will take place in the Artic, and Level 3 will take place on a Farm. The game will be in 1st person and the user will see the scene of the game, the targets the user is shooting at, and the bow with an arrow. The user will see the arrows being shot toward the target. The user will also know when they have hit the target because the target will destroy. 
file:///C:/Users/fitz4/OneDrive/Desktop/Programs/final.html

[Start Screen](file:///C:/Users/fitz4/OneDrive/Desktop/Programs/final.html)


* Low Bar:
In my game I at least expect to get a target shooting game that has at least 2 levels. The game should be able to recognize when the target is hit by an arrow. Also, the game should keep a history board of which users’ accuracy. 

* Expectation:
I expect to have an archery game that has a clean title screen with the users’ name. The user will have 5 arrows to shoot at the 4 different targets. If the user misses two shots, then they will have to restart the level. I expect to have at least 3 different levels. The 2nd level will have targets that move at slow speed. The 3rd level will have targets that move both forward and side to side. On each level you will be able to either restart the game or go back to the title screen. 

* High Hopes: 
The game will have a clean title screen. In addition to the targets, each level will have birds flying around worth extra points. The game will also have a timer that will keep track of how long the user takes to complete all three levels. The time will be added to the history board along with the accuracy.


### What was attempted in my game: ###
My game did not end the way i wanted as the easier things such as score were causing problems but I put in a lot of time and effort for what I have created. 
* Trajectory:
I attempted to make a trajectory line that would show the user where they are shooting but ended up breaking other part of my game while adding this component such as my score.
* Force Meter:
My plan was to have a meter on the screen that would show the user how much force they are shooting the arrows with as they hold down the space bar but when i created the meter the UI would take up the entire screen. So i scaled the panel so it was it the bottom left of the screen but still it was taking up the whole screen. I did not worry about it becuase it knew it would be a simply fix. So i spent hours trying to get the meter to align with the force but it was not working. I got the meter to stop at a certain point then shoot an hour but it was not changing the force of the arrows so i took it out and moved on.
* Score:
I planned on having a score show how accurate the user was but for some reason my UI would not change although i instancitated my score text as well as made sure to drag it into the gameObject. Score was one of the very simple things that gave me a lot of trouble. I spent hours trying different was to call for my score but it was not happening.
* DontDestroyOnLoad:
I wanted the timer to stay on the screen through out each scene in my game and not restart as the scene changed but it did not work. The DontDestroyOnLoad was just keeping the gameManagerObject and not the timer that was in the gameManagerObject. 
* Attach a target to the moving tractor:
On the 3rd level i tried make a target move into the scene attached to the tractor.
* Changing Levels:
At first i made the user hit all of the targets before moving to the next level with no buttons involved but i ran into a problem when i had multiple scenes and i was trying to use the same "if" statement for all of them. In the OnTriggerEnter line i used an If statement to say that when all of the targets were gone load new scene.
