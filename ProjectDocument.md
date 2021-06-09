# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


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

## Movement/Physics

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

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer (Aaron Pan)

The press kit for our **game** can be found [here](https://panlord.github.io/game-power-down/EscapeFromKemper/index.html).  
The press kit for our **team** can be found [here](https://panlord.github.io/game-power-down/).  

The press kits were generated using Pixelnest Studio's [presskit.html](https://github.com/pixelnest/presskit.html), which is a complete re-implementation of [presskit()](http://dopresskit.com/) (basically, the press kit files are generated as static htmls rather than using php).  

The trailer for our game can be found [here](https://www.youtube.com/watch?v=eUepg_Dtnwc). 

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**  
I browsed through a bunch of horror game trailers and took notes of what people did in them. Those notes can be found [here](https://docs.google.com/document/d/1pdPiYV6ynshz_D6uh5Mk_mkcWD4GaDzEIM1u53sjhTM/edit?usp=sharing). Then I just structured the trailer based off of what I liked from observing other horror game trailers (a lot of inspiration from the Outlast trailer because I really liked that one). I began with a little bit of the narrative (not too detailed though, so there aren’t any story spoilers) so the audience knows what they’re going to be doing in the game. Next the trailer transitions into footage of a whole gameplay loop from spawn -> finding any collectable item(s) -> obtaining the objective item -> attempting to escape -> encountering the monster -> losing. I wanted the audience to see what playing the game might be like. I feel that is one purpose of a trailer-- to inform the viewers of what they will be getting into upon downloading the game. Thus, I made sure to show most aspects of the game (map exploration, item collection, etc.) but not all (cursed notes, easter eggs, nuanced mechanics, etc.) so that players can be ~~pleasantly~~ surprised. I also only showed a small portion of the map so that players have places to explore.  
As for the screenshots, I made sure to include many of the things I listed in the trailer. To reiterate, I chose them based on what I would imagine a prospective player would want to see before downloading the game-- the menu, several screenshots of various locations throughout the map, several collectable items, some lore pieces, the inventory, and a partially visible still of the monster in action (only partially visible with its face covered so the player is in for a surprise when they get attacked!).  


## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

- We added a start menu then a bit of lore at the beggening of the game to get the player excited (or scared) to start. When the player reads the lore and hits "go" the game starts.
- We also added a stopwatch that starts counting when the player hits "go", the player can see the stopwatch on the top left of the screen.
- When the players comes across a lore object, the screen displays "E to interact", when the player hits E, he can pick up the lore item, when the player is finished reading about the item, he can close it and continues playin. The stopwatch is paused when the player is on the lore screen.
- The player can also pause the game at anytime by hitting ESC, the stopwatch is paused when the game is.
