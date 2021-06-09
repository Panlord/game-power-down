# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##


The player can press "start" to start the game. When it's pressed, the player can read about the lore and key mappings then click "go" to start the actual gameplay.

The player is expected to walk around the map using the standard movement keys (arrows, WASD, ...) and use the mouse to rotate. Player will go from one room to another looking for the "red book". To enter rooms and pick up the book you press "E". While looking for the book, the player may come across other lore items which he can also pick and read about; those items are also picked by pressing "E".
To access the inventory or pause the game, player can press ESC, which also pauses the timer (you are trying to beat the game as fast as possible so the timer is there to show you how long you spend each round)
After the player picks the objective book, he can try to escabe by looking for the double door with the Exit sign. There are multiple exits but only one works.
After picking up the book, all the lights turn off, but you can use the flashlight by clicking the left click to turn it on and adjust its brightness.
Picking up the object tregers the monster to spawn, so you will try to leave the map as fast as possible before the monster catches you.
If you are caught by the monster, the game ends and you lose. The only way to win is to pick up the book and leave without being caught.

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics (Sarah Almuqri and Aaron Pan)

The player moves in the standard physics model, he can interact with doors and objects to pick them up but he cannot go through stuff.
The camera is in first person so to move the player we use the mouse to rotate the camera and arrows to move it around.

The monster spawns after the player picks a certain object and start following the player. The monster can go through walls and rotates his body to be looking at the player at all times. Monster changes his position randomly every few seconds to find the player, once he is within certain distance of the player, the monster can start following him. If the player gets out of range (the set distance the monster can follow the player in) the monster goes back to randomly spawning around the map.
If the monster and the player's hitboxes collide, the game ends and the monster catches the player.


## Animation and Visuals (Aaron Pan)

### Assets and Visuals ###
For our game we wanted a map similar to UC Davis's Kemper Hall. Thus, I took notes regarding layout and color while walking through the hallways of Kemper and obtained Kemper Hall's floor plans from the College of Engineering Intranet (though I could only get the ones for the third floor and basement). From the gathered data, I created a map from scratch using structural building blocks from Unity's free SNAPS Prototype School and Modern Office Interior assets. The entire floorplan of the map I created can be seen [here](https://github.com/Panlord/game-power-down/blob/0b952799893d73af3419ba904daf9373685b3f22/EscapeFromKemperMapWithLegend.png). Then I browsed the Unity asset store to find various assets to populate the map to give a more university hall feel. After obtaining and importing the free assets, I manually created several variations of conference rooms, office rooms, bathrooms, and computer rooms by dragging and dropping the asset store assets. Some of the textures used were obtained from the asset store as well, although many were created by myself using Microsoft Paint. The textures I created can be found [here](https://github.com/Panlord/game-power-down/tree/master/Spooked/Assets/Materials/Textures). The texture I have of Professor McCoy is from a screenshot I snipped during lecture (find it in-game ;)). All used assets that I did not create were obtained from the Unity asset store and are listed below:  

- [Snaps Prototype | Office](https://assetstore.unity.com/packages/3d/environments/snaps-prototype-office-137490) - Asset Store Originals
- [Snaps Prototype | School](https://assetstore.unity.com/packages/3d/environments/urban/snaps-prototype-school-154693) - Asset Store Originals
- [Snack Machines](https://assetstore.unity.com/packages/3d/props/interior/snack-machines-3517) - VIS Games
- [Low Poly Office Props - LITE](https://assetstore.unity.com/packages/3d/environments/low-poly-office-props-lite-131438) - RRFreelance / PiXelBurner
- [Zombie](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232) - Pxltiger
- [Flashlight](https://assetstore.unity.com/packages/3d/props/electronics/flashlight-18972) - RRFreelance / PiXelBurner
- [Door Free Pack Aferar](https://assetstore.unity.com/packages/3d/props/interior/door-free-pack-aferar-148411) - Andrey Ferar
- [QA Books](https://assetstore.unity.com/packages/3d/props/interior/qa-books-115415) - QAtmo

Animations for the zombie came with the asset, though Erik created the jumpscare image and implemented the jumpscare mechanics. I animated and implemented all of the doors by following [this YouTube tutorial](https://www.youtube.com/watch?v=K9jnIPnsQ_w) by SpeedTutor, and while Sarah helped with creating a texture to decorate the objective book item, it ultimately was not used.  

### Intersections with game feel, graphic design, and world-building ###
**Game Feel**: I based the map off of my observations and the floor plans of Kemper Hall and arranged the props in each room based off of my memory of visiting professors in their office hours to make the player feel like they are in an actual university hall. Furthermore, I darkened textures and littered a bunch of ceiling lights that give a little bit of light to give the scene a more spooky look and feel. I also gave the exit signs a bit of a glow (because exit signs glow in the dark, right?).  

**Graphic Design**: Many of the textures I made for the posters littered around the hallways were based off of the fliers I remember seeing littered throughout UCD's halls, so I guess my graphic designs of those posters are inspired by the work of the people who made those fliers. One of the [characters](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/GunrockAd.png) on some of the posters is based off of UCD's Gunrock. Another [character](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/Karameru.png) on another poster is inspired by the legendary [カラメル](https://www.youtube.com/channel/UCpGk56cJDZcVqIxZatX7nbQ). Also, the [texture](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/KemperFloorTexture.png) I made for the floor is based off of Kemper Hall's [floor tile patterns](https://theaggie.org/wp-content/uploads/2017/05/kemper_ca_Jero_Real.jpg).  

**World-building**: After reading Erik's work on the narrative and lore design, I threw in 20 collectable items and one objective item, all of which are either interactable books, notes, laptops, or cellphones. Each book I put down for the collectable item has a texture I thought would be fitting for the narrative.

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic (Erik Trinh)
Ah yes... the most daunting main role of them all...

The [GameController](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/GameController.cs) is the big brains of *Escape From Kemper*. It is connected to almost every script in the project and several GameObjects in the scene. Among its many jobs include:

1) Foster the current state of the game, whether it be paused, unpaused, in a menu, in the middle of a cutscene, etc. Receive signals from other scripts to transition the game state. 

2) Perform a series of checks on attached scripts. Scripts send 'signals' in the form of public bool methods called in `GameController`'s `Update` method. If `GameController` notices a change (a positive 'signal') in a script, it applies the appropriate action. This "call and response" also controls the menuing of the game.

3) Participate in mass setup and [resets]() of other assets and scripts. For example, [closing]() all the doors, [picking]() which exit is not locked, and [shutting]() off all the lights. All of these interactions involve calling public methods of attached scripts.

It draws heavy inspiration from the Observer design pattern in its real-time communication with other scripts. It also harkens back to command pattern very lightly in objects performing different duties depending on their "command," or in this case, the state of the game.

*Menu Logic*: 

The menus of this game are as follows:

- `MainMenu`: The first menu of the game. Leads into the `IntroMenu`. Can be returned to from the `PauseMenu` or `EndMenu` by calling [ReturntoMenu](). [script]()

- `IntroMenu`: A menu that shows an initial story blurb and hints about some button functionality. The user enters the game from a button on this menu. [script]()

- `PauseMenu`: A menu that shows when the user pauses the game with `Esc`. [script]()

- `LoreNotification`: A menu that shows when the user collects a lore piece. [script]()

- `InventoryMenu`: A menu accessible with `I`. Allows the user to read any lore pieces they have collected. [script]()

All menus share the `Activate`, `Deactivate`, `Show`, and `IsActivated` methods:

- `Activate()`: called when a specific button is pressed via Event Listeners. Sets `Activated` to `true`. `PauseMenu` has an extra `Quit` method. 

- `IsActivated()`: A call method for `GameController`. If `true`, GameController responds by making the appropriate menu/state transition. It then `Deactivate`s the calling menu.

- `Deactivate()`: Sets `Activated` to `false` and hides the menu.

- `Show()`: Called by `GameController` to make menus visible when performing menu/state transitions.

The `Activate`/`Deactivate` and `IsActivated()` relationship between the menu controllers and the `GameController` is part of the "call and response" structure of this game's logic, and echoes back to the Observer pattern, to which `GameController` notices that the state of a connected menu controller has changed. In this case, it notices that a menu button has been pressed, and makes the proper menu transition.

*Game States*: The state of the game is controlled using a series of booleansthat control what the GameController can and cannot do. The game states are as follows:

- `Paused`: The game is paused. The user cannot perform any in-game functions. Called `true` alone when the user presses [Esc]() mid-game.

- `InMenu`: Prevents the player from manually using [Esc]() to call `Pause()`. `Paused` + `InMenu` = Player is in a menu excluding the pause menu. Often `true` along with `Paused = true` in cases where we want to force-pause the game. 

- `CanScare`: `CanScare` + `Paused` + `InMenu` = Game Over State. Upon [touching the monster](), this bool and `Paused` and `InMenu` all hit `true`. `CanScare` stays [active for 5 seconds ]()to allow the player to take the jump scare in full effect, then it is rendered `false`, leaving `Paused + InMenu` as the player transitions to an ending menu.

- `!Paused + !InMenu  + !CanScare`: All of the above state variables are `false`. The player is actively playing the game as `GameController` awaits a response.

- `HasBook`: The player has picked up the objective book. Allows the player to use exits. Allows `GameController` to properly respond to [signals received]() by ExitDoors.

- `MonsterTriggered`: The lights are off and the monster is active. Set `true` once per game instance in [TriggerMonster]() in one of three ways.

    1) The player has picked up the book.
    2) The player reads a cursed lore piece.
    3) 120 seconds have passed.

    It is possible for the monster to be triggered despite the player not having the book.

(Menu and State transition diagram here.)

Game states are somewhat of a callback to Command Pattern. 

*Calls and Responses:* The defining feature of `GameController` is that both the control flow of the game and the actions of othe scripts follow a "call and response" system. If the . Here is a list of many different kinds of interactions:

- 

-

-

-

This logic of real-time "call and response" is based on the Observer pattern, albeit using public methods of other scripts instead of delegates. Essentially, similar to how Pikmini recognize that their color has changed and alter their appearance accordingly, `GameController` recognizes that a boolean value of a connected script has changed, and alters the game state or state of other objects accordingly. 

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

The CURSED sound effect that plays during the jump scare is a distorted, edited version of [this clip](https://soundbible.com/2085-Annoying-Speaker-Pulsing.html). The original sound effect is under public domain.

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design (Erik Trinh)

The original draft of the narrative is [here](https://docs.google.com/document/d/1R4GfQhAeZIhtjAVn3RB6_rSJpHV9qXOw5RC4De3xET0/edit?usp=sharing). Note that parts here and there might be different from the final product. It is a story of human perserverance and human nature at the brink of despair. The initial premise is that you are the friend of an assistant of a world-renowned professor. You are tasked with obtaining a particular sketchbook from his facility. They player gets this premise, their objective, and hints at controls in an [introduction screen](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/Intro.PNG) (Note, story text here is tenative).

There are many ways in which the player experiences in this narrative in-game.

*Assets and Displays*: The story of this game is scattered among 20 [ books, laptops, and devices](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/book2.PNG) in the facility as in-game interactable assets. Interacting with them will display [a screen](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/ViewingLore.PNG) showing bits and pieces of the story(Peter did a phenomenal job with the UI here). The player is also invited to open a [menu](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreMenu.PNG) to read all of the lore pieces thet have currently collected. This allows them to get a feeling for the world that they are in. The "sketchbook" the player is supposed to obtain is different from all the other books in that it is [both open and a solid deep red color](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/book.PNG) to make it stand out. 

*A Lore Class!?*: As the narrative designer, I was also tasked with implementing the lore system into the code. This was done using a [Lore Manager](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/LoreManager.cs) and a [Lore Notification](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/LoreNotification.cs) script. The two scripts contain three classes in total:

- `LoreItem`: A simple class representing a lore piece. Has a name, lore text, and a boolean denoting whether or not its cursed. Has getters for all three of these variables.

- `LoreManager`: Contains a base list of all possible `LoreItem`s. It returns random `LoreItem`s for use in the player's inventory and the `LoreNotification`. It uses a separate list copied from the base list such that no lore piece is obtained twice in any one game instance.

- `LoreNotification`: Handles displaying lore pieces upon picking them up. `Set()` takes a `LoreItem` and loads its text for display. The class contains menu logic that works in tandem with `GameController` to decide when it is appropriate to open and close this notification (*See: Game Logic*).

I also created [dummy lore menu](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreInventoryBeta.PNG), [display](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreDisplayBeta.PNG), and lore item raycast [scripts](https://github.com/Panlord/game-power-down/commit/52ae93d80c9794557238fd68873f5b071d21e699) as proofs of concept. Peter later took these scripts and cosolidated and optimized them into the menus you see in the *Assets and Displays* section.

*Gameplay and Atmosphere*: Aside from adding to the user experience, the lore system has little effect on the gameplay objective (getting the sketchbook). However, one touch is that "cursed" lore entries (cOnTaInS tExT fOrMaTtEd lIkE tHiS) will automatically shut off the lights and make the monster active. Along with the fact that [cursed entries have traces of blood on them](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/CursedLore.PNG), this is supposed to make the player feel that something is definitely amiss and that they should move fast, if able.

Finally, the [monster](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/zombo4.png) that chases you within this facility is none other than the story's professor, who had become that way due to self-experimentation. The [jump scare](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Zombie/JumpScare.jpg)  shows a true display of horror and malice that was once something the player might have had sympathy for from reading his descent into madness. 

## Press Kit and Trailer (Aaron Pan)

The press kit for our **game** can be found [here](https://panlord.github.io/game-power-down/EscapeFromKemper/index.html).  
The press kit for our **team** can be found [here](https://panlord.github.io/game-power-down/).  

The press kits were generated using Pixelnest Studio's [presskit.html](https://github.com/pixelnest/presskit.html), which is a complete re-implementation of [presskit()](http://dopresskit.com/) (basically, the press kit files are generated as static htmls rather than using php).  

The trailer for our game can be found [here](https://www.youtube.com/watch?v=eUepg_Dtnwc). 

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**  
I browsed through a bunch of horror game trailers and took notes of what people did in them. Those notes can be found [here](https://docs.google.com/document/d/1pdPiYV6ynshz_D6uh5Mk_mkcWD4GaDzEIM1u53sjhTM/edit?usp=sharing). Then I just structured the trailer based off of what I liked from observing other horror game trailers (a lot of inspiration from the Outlast trailer because I really liked that one). I began with a little bit of the narrative (not too detailed though, so there aren’t any story spoilers) so the audience knows what they’re going to be doing in the game. Next the trailer transitions into footage of a whole gameplay loop from spawn -> finding any collectable item(s) -> obtaining the objective item -> attempting to escape -> encountering the monster -> losing. I wanted the audience to see what playing the game might be like. I feel that is one purpose of a trailer-- to inform the viewers of what they will be getting into upon downloading the game. Thus, I made sure to show most aspects of the game (map exploration, item collection, etc.) but not all (cursed notes, easter eggs, nuanced mechanics, etc.) so that players can be ~~pleasantly~~ surprised. I also only showed a small portion of the map so that players have places to explore.  
As for the screenshots, I made sure to include many of the things I listed in the trailer. To reiterate, I chose them based on what I would imagine a prospective player would want to see before downloading the game-- the menu, several screenshots of various locations throughout the map, several collectable items, some lore pieces, the inventory, and a partially visible still of the monster in action (only partially visible with its face covered so the player is in for a surprise when they get attacked!).  


## Game Feel (Everyone)

- We added a start menu then a bit of lore at the beggening of the game to get the player excited (or scared) to start. When the player reads the lore and hits "go" the game starts.
- We also added a stopwatch that starts counting when the player hits "go", the player can see the stopwatch on the top left of the screen.
- When the players comes across a lore object, the screen displays "E to interact", when the player hits E, he can pick up the lore item, when the player is finished reading about the item, he can close it and continues playin. The stopwatch is paused when the player is on the lore screen.
- The player can also pause the game at anytime by hitting ESC, the stopwatch is paused when the game is.
- There are lore items scattered around the map so the player can attempt to understand the story while playing the game.
