# Game Basic Information #

## Summary ##

**"I am sorry to put this task onto you, but you are the only one who can do it.
Within this facility is an extremely important sketchbook that you must procure. The lives of many hang in the balance."**

There is an abandoned facility in town. You have been tasked with obtaining a particular red book from this facility under the claim that it will save lives. 

Flashlight in hand, you enter the facility and find notes scattered around. Among them is the deep red book. As you pick it up, and read some of the notes as you go, the lights shut off, and you hear some odd noises in the distance. You power your flashlight off, and swear to yourself to only use it when necessary. 

But, you can't see. You have to turn it back on at some point.

It's all or nothing. **You must make your escape**.

Walk, sprint, explore, open doors and pick up notes as you learn the story of what once transpired, or what is still going on, inside this supposedlty abandoned building.

(Adapted from Erik's [Lore Synopsis](https://docs.google.com/document/d/1R4GfQhAeZIhtjAVn3RB6_rSJpHV9qXOw5RC4De3xET0/edit?usp=sharing))

## Gameplay Explanation ##

### Erik's Ultimate Gameplay Manual and Strategy Guide ###

Controls (PC):

- WASD: Move, navigate inventory menu

- Left Click: Toggle Flashlight

- Shift: Sprint

- E: Interact with doors and items

- I: Open the Inventory Menu

- Esc: Pause the game or close a menu

**Objective**: Search the facility and collect a particular red book. Then, exit the facility using one of the three exits that is unlocked.

**Basic Mechanics**:

- The flashlight has 3 light settings that you can cycle through. Higher levels provide more visibility. Do note the monster is sensitive to the flashlight: keeping it on for too long will cause the monster to chase you from anywhere. Higher flashlight levels lower the time needed for this to happen.
    - The threshold for "too long" is 15. 
    - Level 1 flashlight adds 1 per second.
    - Level 2 flashlight adds 2 per second.
    - Level 3 flashlight adds 3 per second.
- Sprinting is very fast compared to walking. However, the amount of time you spend sprinting acculumates as you run and decreases as you walk. If this amount reaches 1.5, you will become exhausted and must wait 1.5 seconds before sprinting again.

**Lore**: There are 20 lore pieces to collect. 7 of them are "cursed." They contain vital information about the game's story and are a side task.
- Pressing `E` on a lore piece will pick it up and display its text.
- Cursed entries are different in that the page is soaked in blood and are written in a very strange fashion.
- Note that after finishing reading a cursed entry, if they have already not done so, the lights will shut off and the monster will spawn.
- Press `I` to open up the inventory menu. Here you can press up and down (WS or the up and down arrows) to navigate through and read the lore pieces you have already read.

**Danger State**: The danger state is a condition in which the lights turn pitch black and the monster is awakened. It is so dark that usage of the flashlight is almost always necessary.

It is triggered only once per game instance when any of the three conditions are met

1) The player picks up the red book.
2) The player opens a cursed lore piece.
3) Neither 1 nor 2 happened and 120 seconds have passed.

It is possible for the danger state to be active when the player does not have the book. This situation is the most dangerous. Try to get to the exit as soon as possible.

**The Monster**: The monster appears during the danger state.
- It is only active while the flashlight is on. If you turn off the flashlight while the monster is active it will disappear.
- It can walk through walls and doors. Beware of rooms.
- If you are within the monster's vision range, it will chase you. If you hear a loud growl, the monster has noticed you and is currently chasing you.
- If the player has the flashlight out for too long, it will chase the player regardless of where they are. This is known as the **omniscient** state.
- If it is a considerable distance away, it will periodically teleport until it ends up in position such that it notices you. It makes a high pitched sound every time it teleports.
- Touching the monster is a **game over**.

**Escaping**: After picking up the book, you still need to escape the facility. There are three exits, each with large signs above them. Note that only one exit works and the other two will notify you that they are locked.

**Helpful Tips**

- Learn the map. All of the obtainable items have preset spawn positions. The player has 3 possible spawn points. Learn the position of the red book and the best path from any of the spawn positions. This part is key if you are a speedrunner.

- Minimize usage of the flashlight as much as you can. The monster is only active while the flashlight is on. Try not to use it while inside rooms if you know the monster is nearby, since it can bypass walls.

- Make sure that you understand the monster's audio cues. If you hear the monster growl but do not see them, always check behind you.

- If the monster is headed straight in your direction, either 

    a) turn off the flashlight and walk far enough away such that when you turn the flashlight back on, the monster no longer sees you.

    b) make a sharp turn to the left or the right when it gets very close, as the monster is very poor at making turns.

Programmers' Note:
- Everybody became exterminators with how many bugs we all killed.
- Some playtesters cried while playing the game. Some developers cried for different reasons.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface (Peter Lin)

### Minimal UI  
As people who played the game are aware, there is barely any non-diagetic (not part of the game world) UI elements that show at all times on the screen, except for the timer. This choice was made to help immerse the player in the world, by reducing most if not all distracting content from the player's screen. There is no health bar (the player just loses if caught) and no stamina bar (the player instead hears a heavy breathing audio to denote exhaustion). Since this is a first person survival horror game, trying to keep player immersion is especially important to the player experience.

### On-screen Prompts
As there are many interactable objects in the 3-D space (notes, doors, etc.) there needed to be a way to notify the player that something could be interacted with. Thus, similar to other horror and adventure games, I opted to go with an on-screen prompt that appears when the player looks at an object within a certain range. This was done by adding a `Raycast` to the `Main Camera` via [`InteractiveItemManager.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/InteractiveItemManager.cs). This script checks if the `Raycast` [hits any interactable item](https://github.com/Panlord/game-power-down/blob/d6a263b60904d37ae62292027fa421fc636c2f83/Spooked/Assets/Scripts/InteractiveItemManager.cs#L31) and, based on the item, shows a prompt to interact via [`InterfaceController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/InterfaceController.cs). If the player interacts (presses down `E`) with a valid item, then [`InteractiveItemManager.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/InteractiveItemManager.cs) calls upon the corresponding `Interact()` method from the Controller script attached to the GameObject.  

The [special cases](https://github.com/Panlord/game-power-down/blob/d4a9319d83b802c3e79172a025307512d54c91dd/Spooked/Assets/Scripts/ExitDoorController.cs#L300) are if the player approaches an exit door without the objective item, or a locked door. In that case, then the on-screen prompt tells the player to either retrieve the book, or that the door is locked, omitting the `[E]` to show that the player cannot interact with the item.

**Relevant Controller Scripts:**
- [`CollectibleItemController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/CollectibleItemController.cs)
- [`DoorController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/DoorController.cs)
- [`DoubleDoorController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/DoubleDoorController.cs)
- [`ExitDoorController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/ExitDoorController.cs)
- [`ObjectiveItemController.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/ObjectiveItemController.cs)

### Typeface Choice
I decided to use one typeface ([YitziScript](https://yitzilitt.itch.io/yitziscript)) for the entire game. This style of font matched what we wanted: handwritten, slightly creepy text. As a lot of the lore was based on written (not digital) notes, I looked for something that could emulate physical script, and ended up with this one. It also especially helped showcase the (monster) professor's descent into madness when tHe TeXt ShIFtEd To ThIs StYlE. The decision was made to not add other types of fonts, as consistency and continuity with the game feel was an important aspect that we wanted to address. Everything from the menus, notes, and buttons use the same typeface to keep the player immersed in the game.

### Menus and Buttons  
Many of the menus and buttons are styled with a page image that I found and edited from [here](https://davidrichard.itch.io/2-simple-sheets-of-paper]. The vintage paper was integral to the game's aesthetic as it, like the typeface, allowed for a handwritten, creepy atmosphere while the player went around collecting items and viewing the menus. Most of the menus's functionality were initially created by Erik, then visually edited later by me.

### Inventory
This is actually one of the bigger parts of the UI that I'm proud of creating. Upon pressing `I`, the player opens up a list of their collected items, denoted by tabs on the left side, and a visual representation of the note and its text on the right side. The player can swap between notes to view each lore piece and understand how the game world came to be. This is created via a combination of three scripts: [`Inventory.cs`][https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/Inventory.cs] (which trakcs what notes the player has collected and generates a random note whenever an item is collected), [`InventoryMenuController.cs`][https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/InventoryMenuController.cs] (which handles which note is currently shown), and [`ListCreator.cs`][https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/ListCreator.cs] (which manages the scroll offset of the notes tab on the left if there are more tabs than fits on the screen).

### Diegetic Brightness Meter on Flashlight
As the flashlight is an integral tool in helping the player progress through the game with the lights off, emphasis was added to make the flashlight a part of the world instead of just on the side. Since there are multiple brightness levels (including off), I decided to add brightness meters via `Canvas` `Image`s (circles) on the flashlight itself. This was done by adding a `Sphere` `GameObject` on the flashlight object and attaching [`ClampMeter.cs`](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/ClampMeter.cs) that takes the "meters" as `SerializedField`s and projects them onto the screen space based on the `Sphere`'s world space.

## Movement/Physics (Sarah Almuqri and Aaron Pan)

The player moves in the standard physics model, he can interact with doors and objects to pick them up but he cannot go through stuff.
The camera is in first person so to move the player we use the mouse to rotate the camera and arrows to move it around.

The monster spawns after the player picks a certain object and start following the player. The monster can go through walls and rotates his body to be looking at the player at all times. Monster changes his position randomly every few seconds to find the player, once he is within certain distance of the player, the monster can start following him. If the player gets out of range (the set distance the monster can follow the player in) the monster goes back to randomly spawning around the map.
If the monster and the player's hitboxes collide, the game ends and the monster catches the player.


## Animation and Visuals (Aaron Pan)

### Assets and Visuals ###
For our game we wanted a map similar to UC Davis's Kemper Hall. Thus, I took notes regarding layout and color while walking through the hallways of Kemper and obtained Kemper Hall's floor plans from the College of Engineering Intranet (though I could only get the ones for the third floor and basement). From the gathered data, I created a map from scratch using structural building blocks from Unity's free SNAPS Prototype School and Modern Office Interior assets. The entire floorplan of the map I created can be seen [here](https://github.com/Panlord/game-power-down/blob/6cfb26652caefcec6d888b88f8fe274e3098a9fb/Pics%20and%20Diagrams/EscapeFromKemperMapWithLegend.png). Then I browsed the Unity asset store to find various assets to populate the map to give a more university hall feel. After obtaining and importing the free assets, I manually created several variations of [conference rooms, office rooms, bathrooms, and computer rooms](https://github.com/Panlord/game-power-down/tree/master/Spooked/Assets/Prefabs) by dragging and dropping the asset store assets. Some of the textures used were obtained from the asset store as well, although many were created by myself using Microsoft Paint. The textures I created can be found [here](https://github.com/Panlord/game-power-down/tree/master/Spooked/Assets/Materials/Textures). The texture I have of Professor McCoy is from a screenshot I snipped during lecture (find it in-game ;)). All used assets that I did not create were obtained from the Unity asset store and are listed below:  

- [Snaps Prototype | Office](https://assetstore.unity.com/packages/3d/environments/snaps-prototype-office-137490) - Asset Store Originals
- [Snaps Prototype | School](https://assetstore.unity.com/packages/3d/environments/urban/snaps-prototype-school-154693) - Asset Store Originals
- [Snack Machines](https://assetstore.unity.com/packages/3d/props/interior/snack-machines-3517) - VIS Games
- [Low Poly Office Props - LITE](https://assetstore.unity.com/packages/3d/environments/low-poly-office-props-lite-131438) - RRFreelance / PiXelBurner
- [Zombie](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232) - Pxltiger
- [Flashlight](https://assetstore.unity.com/packages/3d/props/electronics/flashlight-18972) - RRFreelance / PiXelBurner
- [Door Free Pack Aferar](https://assetstore.unity.com/packages/3d/props/interior/door-free-pack-aferar-148411) - Andrey Ferar
- [QA Books](https://assetstore.unity.com/packages/3d/props/interior/qa-books-115415) - QAtmo

Animations for the zombie came with the asset, though Erik created the [jumpscare image](https://github.com/Panlord/game-power-down/blob/6cfb26652caefcec6d888b88f8fe274e3098a9fb/Pics%20and%20Diagrams/zombo4.png) and implemented the [jumpscare mechanics](https://github.com/Panlord/game-power-down/blob/6cfb26652caefcec6d888b88f8fe274e3098a9fb/Spooked/Assets/Scripts/GameController.cs#L451). I [animated and implemented all](https://github.com/Panlord/game-power-down/tree/master/Spooked/Assets/Animations) of the doors by following [this YouTube tutorial](https://www.youtube.com/watch?v=K9jnIPnsQ_w) by SpeedTutor (thus contributing to [DoorController.cs](https://github.com/Panlord/game-power-down/blob/6cfb26652caefcec6d888b88f8fe274e3098a9fb/Spooked/Assets/Scripts/DoorController.cs), [DoubleDoorController.cs](https://github.com/Panlord/game-power-down/blob/6cfb26652caefcec6d888b88f8fe274e3098a9fb/Spooked/Assets/Scripts/DoubleDoorController.cs), and several other code files that have since been reworked) , and while Sarah helped with creating a texture to decorate the objective book item, it ultimately was not used.  

### Intersections with game feel, graphic design, and world-building ###
**Game Feel**: I based the map off of my observations and the floor plans of Kemper Hall and arranged the props in each room based off of my memory of visiting professors in their office hours to make the player feel like they are in an actual university hall. Furthermore, I darkened textures and littered a bunch of ceiling lights that give a little bit of light to give the scene a more spooky look and feel. I also gave the exit signs a bit of a glow (because exit signs glow in the dark, right?).  

**Graphic Design**: Many of the textures I made for the posters littered around the hallways were based off of the fliers I remember seeing littered throughout UCD's halls, so I guess my graphic designs of those posters are inspired by the work of the people who made those fliers. One of the [characters](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/GunrockAd.png) on some of the posters is based off of UCD's Gunrock. Another [character](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/Karameru.png) on another poster is inspired by the legendary [カラメル](https://www.youtube.com/channel/UCpGk56cJDZcVqIxZatX7nbQ). Also, the [texture](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Materials/Textures/KemperFloorTexture.png) I made for the floor is based off of Kemper Hall's [floor tile patterns](https://theaggie.org/wp-content/uploads/2017/05/kemper_ca_Jero_Real.jpg). All of the wonderful [menu and UI elements](https://github.com/Panlord/game-power-down/tree/master/Spooked/Assets/Menus) were created and done by Peter.  

**World-building**: After reading Erik's work on the narrative and lore design, I threw in 20 collectable items and one objective item, all of which are either interactable books, notes, laptops, or cellphones. Each book I put down for the collectable item has a texture I thought would be fitting for the narrative.

## Input (Victor Palencia)

**Describe the default input configuration.**

The game is mainly based on keyboard and mouse inputs but it is also completely playable on a PS4 controller (and possibly other controllers). 

**Mouse + Keyboard**
- Player movement is done with WASD and camera look is done with the mouse. 
- I wrote the MouseLook.cs script and allowed for both mouse and joystick inputs. 
- I used the Unity's new Input System (https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html) to handle the the mouse look for gamepads. 

```C#
    y =  Gamepad.current.rightStick.x.ReadValue() * JoystickSens * Time.deltaTime;
    XRotation += Gamepad.current.rightStick.y.ReadValue() * JoystickSens * Time.deltaTime;
```
For the mouse it was done with the older way
```C#
    y = Input.GetAxis("Mouse X") * MouseSensitivity;
    XRotation += Input.GetAxis("Mouse Y") * MouseSensitivity;
```

For player movement, I used the old unity system and allowed for sprinting with left shift or circle with a ps4 controller. 
```C#
    float x = Input.GetAxis("Horizontal") * (isRunning ? RunningSpeed : WalkingSpeed);
    float z = Input.GetAxis("Vertical") * (isRunning ? RunningSpeed : WalkingSpeed);
```

The other input buttons were done through the old Input Manager. This allowed me to only write the input once instead of having to write a separate version for kb+m and gamepad. 


### PS4 Dualshock Controls
- Left joystick: player movement
- Right joystick: camera look
- Square: flashlight toggle 
- X: Interact/PickUp/ and close menus
- Options: Brings up pause menu, press it again to exit the game or X to close it
- Circle: Sprint
- Triangle: Inventory menu

### Keyboard controls
- WASD: player movement
- ESC: bring up pause menu and exit pause menu
- I: Enter and exit inventory menu
- Left Click: change flashlight intensity 
- E: Interact with lore items and doors 
- L Shift: Sprint

## Game Logic (Erik Trinh)
Ah yes... the most daunting main role of them all...

The [GameController](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/GameController.cs) is the big brains of *Escape From Kemper*. It is connected to almost every script in the project and several GameObjects in the scene. Among its many jobs include:

1) Foster the current state of the game, whether it be paused, unpaused, in a menu, in the middle of a cutscene, etc. Receive signals from other scripts to transition the game state. 

2) Perform a series of checks on attached scripts. Scripts send 'signals' in the form of public bool methods called in `GameController`'s `Update` method. If `GameController` notices a change (a positive 'signal') in a script, it applies the appropriate action. This "call and response" also controls the menuing of the game.

3) Participate in mass setup and [resets](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L162) of other assets and scripts. For example, [closing](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L121) all the doors, [picking](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L81) which exit is not locked, and [shutting](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L143) off all the lights. All of these interactions involve calling public methods of attached scripts.

It draws heavy inspiration from the Observer design pattern in its real-time communication with other scripts. It also harkens back to command pattern very lightly in objects performing different duties depending on their "command," or in this case, the state of the game.

*Menu Logic*: 

The menus of this game are as follows:

- `MainMenu`: The first menu of the game. Leads into the `IntroMenu`. Can be returned to from the `PauseMenu` or `EndMenu` by calling [ReturntoMenu](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L212). [script](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/MainMenuController.cs)

- `IntroMenu`: A menu that shows an initial story blurb and hints about some button functionality. The user enters the game from a button on this menu. [script](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/IntroMenuController.cs)

- `PauseMenu`: A menu that shows when the user pauses the game with `Esc`. [script](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/PauseMenuController.cs)

- `LoreNotification`: A menu that shows when the user collects a lore piece. [script](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/LoreNotification.cs)

- `InventoryMenu`: A menu accessible with `I`. Allows the user to read any lore pieces they have collected. [script](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/InventoryMenuController.cs)

All menus share the `Activate`, `Deactivate`, `Show`, and `IsActivated` methods:

- `Activate()`: called when a specific button is pressed via Event Listeners. Sets `Activated` to `true`. `PauseMenu` has an extra `Quit` method. 

- `IsActivated()`: A call method for `GameController`. If `true`, GameController responds by making the appropriate menu/state transition. It then `Deactivate`s the calling menu.

- `Deactivate()`: Sets `Activated` to `false` and hides the menu.

- `Show()`: Called by `GameController` to make menus visible when performing menu/state transitions.

The `Activate`/`Deactivate` and `IsActivated()` relationship between the menu controllers and the `GameController` is part of the "call and response" structure of this game's logic, and echoes back to the Observer pattern, to which `GameController` notices that the state of a connected menu controller has changed. In this case, it notices that a menu button has been [activated](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L296), and makes the proper menu transition.

*Game States*: The state of the game is controlled using a series of booleansthat control what the GameController can and cannot do. The game states are as follows:

- `Paused`: The game is paused. The user cannot perform any in-game functions. Called `true` alone when the user presses [Esc](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L345) mid-game, and when `true` alone, the user can also exit the pause menu with `Esc`

- `InMainMenu`: Prevents the player from manually using `Esc` to call [Pause()](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L226). `Paused` + `InMainMenu` = Player is in `MainMenu`, `IntroMenu`, or `EndMenu`. Often `true` along with `Paused = true` in cases where we want to force pause the game with no option to use `Esc`. 

- `CanScare`: `CanScare` + `Paused` + `InMainMenu` = Game Over State. Upon [touching the monster](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L487), this bool and `Paused` and `InMainMenu` all hit `true`. `CanScare` stays [active for 5 seconds](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L464) to allow the player to take the jump scare in full effect, then it is rendered `false`, leaving `Paused + InMainMenu` as the player transitions to an ending menu.

- `!Paused + !InMainMenu  + !CanScare`: All of the above state variables are `false`. The player is actively playing the game as `GameController` awaits a response.

- `HasBook`: The player has picked up the objective book. Allows the player to use exits. Allows `GameController` to properly respond to [signals received](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L411) by ExitDoors.

- `MonsterTriggered`: The lights are off and the monster is active. Set `true` once per game instance in [TriggerMonster](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L277) in one of three ways.

    1) The player has picked up the book.
    2) The player reads a cursed lore piece.
    3) 120 seconds have passed.

    It is possible for the monster to be triggered despite the player not having the book.

Game states are somewhat of a callback to Command Pattern, albeit with a lack of command files. Rather, the central `GameController` is what orders everything what to do depending on the current state of the game.

![Game Flow](https://raw.githubusercontent.com/Panlord/game-power-down/master/Pics%20and%20Diagrams/MenuStateFlow.PNG)

![Victory Conditions](https://raw.githubusercontent.com/Panlord/game-power-down/master/Pics%20and%20Diagrams/MenuStateFlow2.PNG)

*Calls and Responses:* The defining feature of `GameController` is that both the control flow of the game and the actions of other scripts follow a "call and response" system. Here is a list of of some of the different kinds of interactions:

- Menus: `GameController` recognizes button presses in menus by checking if a menu's `IsActivated` return true. If it does, it figures out which menu sent it, which button was pressed, and then applies the appropriate menu transitions.

- Exit Doors: `ExitDoorController` returns [a value](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/ExitDoorController.cs#L55) depending on if it was interacted with and the current state of the game. It usually returns `-1` if the player has not interacted with it. When `GameController` recognizes that an `ExitDoorController` returned a [different value](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L411), it applies logic depending on:
    1) The returned value is 0, indicating the player doesn't have the sketchbook.
    2) The returned value is 1, indicating the player does have the book, but the exit is locked.
    3) The returned value is 2, indicating the player has the book and found the right exit. `GameController` declares victory and transitions the game state.

- Lore Pieces: When the player interacts with a lore piece, the [player's inventory](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/Inventory.cs#L36) indicates that it has obtained either a lore item or the objective book using `GotLore` and `GotBook`, respectively. Upon the `GameController` recognizing this change, it makes the following [adjustments](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L441):
    1) If `GotLore` triggered, show the lore notification.
    2) If `GotBook` triggered, set the `HasBook` state to `true` and `TriggerMonster` if it hasn't already.

- FlashLight and Monster: The `FlashLightController` has an [internal counter](https://github.com/Panlord/game-power-down/blob/0846983f60adca3840ec75296583a3d678660c47/Spooked/Assets/Scripts/FlashLightController.cs#L120) that counts up as long as its on. Higher flashlight settings makes the count go up faster. When that is over 15, the `FlashLightController`'s [OverTime()]https://github.com/Panlord/game-power-down/blob/0846983f60adca3840ec75296583a3d678660c47/Spooked/Assets/Scripts/FlashLightController.cs#L37) method starts returning true. The `GameController` recognizes this, and [signals](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L499) to the monster to become `omniscient`. In `MonsterMovement`, if the monster is `omniscient`, it will [chase the player](https://github.com/Panlord/game-power-down/blob/80630e44b867a99aa8c7cd5fb50d954198e58072/Spooked/Assets/Scripts/GameController.cs#L499) regardless of where the monster is and if it can see the player.

This logic of real-time "call and response" is based on the Observer pattern, albeit using public methods of other scripts instead of delegates. Essentially, similar to how Pikmini recognize that their color has changed and alter their appearance accordingly, `GameController` recognizes that a boolean value of a connected script has changed, and alters the game state or state of other objects accordingly. 

![On Too Long](https://raw.githubusercontent.com/Panlord/game-power-down/master/Pics%20and%20Diagrams/OnTooLong.PNG)

![Exit Doors](https://raw.githubusercontent.com/Panlord/game-power-down/master/Pics%20and%20Diagrams/FindExit.PNG)

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**
### Audio Assets
- The screeching sound played when the zombie is looking for the player is from [InspectorJ Sound Effects](https://assetstore.unity.com/packages/audio/sound-fx/96-general-library-free-sample-pack-185157). I used an audio editor to reverse the sound and adjust its length and speed to give it a more inhuman and horror-like sound. This audio is free from the unity store. 
- The door opening and closing sounds [this site](https://www.fesliyanstudios.com/royalty-free-sound-effects-download/opening-closing-door-54). I edited the clip to match the length of the door opening and closing animations. This audio is royalty free. 
- The footstep sound comes from [John Leonard French](https://assetstore.unity.com/packages/audio/sound-fx/western-audio-music-67788). This audio is free from the unity store.
- The main music playing throughout the game is from [DHSFX](https://assetstore.unity.com/packages/audio/ambient/unnerving-ambient-sounds-horror-game-sound-effect-pack-30-sounds-170590). This audio is free from the unity store.
- The out of breath sound effect comes from [this site again](https://www.fesliyanstudios.com/royalty-free-sound-effects-download/breathing-150). It is royalty free. 
- The CURSED sound effect that plays during the jump scare is a distorted, edited version of [this clip](https://soundbible.com/2085-Annoying-Speaker-Pulsing.html). The original sound effect is under public domain.

**Describe the implementation of your audio system.**
- The main track being played, Alone at Twilight, is played by the AudioManager gameobject. It had a script to play another track but I disabled it because I felt the first track was more subtle. 
- The monster has an Audio Source component attached to it and in one of the scripts (MonsterMovement.cs) I added two AudioClips. One is for his gutteral growl and another for a higher pitched demonic screech. 
- I didn't want every screech from the monster to sound the same so I gave the pitch of the screech a range of randomized pitches and volume levels. A similar treatment was given to the monster's growl. 
- The ```footsteps.cs``` script also uses randomized pitches and volumes in order for the footsteps to sound more natural. This script is a part of the player and it accesses the player's AudioSource component. 
- Every door and double door prefab was given an opening and closing sound which was played when the animation was triggered. 

```C# 
    Audio.volume = Random.Range(0.3f, 0.45f);
    Audio.pitch = Random.Range(0.8f, 1.1f);
    Audio.Play();
```

**Document the sound style.**  
- The sound style is supposed to be like that of psychological horror games like Silent Hill or Resident Evil 7. The player should not be distracted by the music, instead, the music should allow the player to be immersed in our world. 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design (Erik Trinh)

The original draft of the narrative is [here](https://docs.google.com/document/d/1R4GfQhAeZIhtjAVn3RB6_rSJpHV9qXOw5RC4De3xET0/edit?usp=sharing). Note that parts here and there might be different from the final product. It is a story of human perserverance and human nature at the brink of despair. The initial premise is that you are the friend of an assistant of a world-renowned professor. You are tasked with obtaining a particular sketchbook from his facility. They player gets this premise, their objective, and hints at controls in an [introduction screen](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/Intro.PNG) (Note, story text here is tenative).

There are many ways in which the player experiences in this narrative in-game.

*Assets and Displays*: The story of this game is scattered among 20 [ books, laptops, and devices](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/book2.PNG) in the facility as in-game interactable assets. Interacting with them will display [a screen](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/ViewingLore.PNG) showing bits and pieces of the story(Peter did a phenomenal job with the UI here). The player is also invited to open a [menu](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreMenu.PNG) to read all of the lore pieces they have currently collected. This allows them to get a feeling for the world that they are in. The "sketchbook" the player is supposed to obtain is different from all the other books in that it is [both open and a solid deep red color](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/book.PNG) to make it stand out. 

*A Lore Class!?*: As the narrative designer, I was also tasked with implementing the lore system into the code. This was done using a [Lore Manager](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/LoreManager.cs) and a [Lore Notification](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Scripts/LoreNotification.cs) script. The two scripts contain three classes in total:

- `LoreItem`: A simple class representing a lore piece. Has a name, lore text, and a boolean denoting whether or not its cursed. Has getters for all three of these variables.

- `LoreManager`: Contains a base list of all possible `LoreItem`s. It returns random `LoreItem`s for use in the player's inventory and the `LoreNotification`. It uses a separate list copied from the base list such that no lore piece is obtained twice in any one game instance.

- `LoreNotification`: Handles displaying lore pieces upon picking them up. `Set()` takes a `LoreItem` and loads its text for display. The class contains menu logic that works in tandem with `GameController` to decide when it is appropriate to open and close this notification (*See: Game Logic*).

I also created [dummy lore menu](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreInventoryBeta.PNG), [display](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/LoreDisplayBeta.PNG), and lore item raycast [scripts](https://github.com/Panlord/game-power-down/commit/52ae93d80c9794557238fd68873f5b071d21e699) as proofs of concept. Peter later took these scripts and consolidated and optimized them into the menus you see in the *Assets and Displays* section.

*Gameplay and Atmosphere*: Aside from adding to the user experience, the lore system has little effect on the gameplay objective (getting the sketchbook). However, one touch is that "cursed" lore entries (cOnTaInS tExT fOrMaTtEd lIkE tHiS) will automatically shut off the lights and make the monster active. Along with the fact that [cursed entries have traces of blood on them](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/CursedLore.PNG), this is supposed to make the player feel that something is definitely amiss and that they should move fast, if able.

Finally, the [monster](https://github.com/Panlord/game-power-down/blob/master/Pics%20and%20Diagrams/zombo4.png) that chases you within this facility is none other than the story's professor, who had become that way due to self-experimentation. The [jump scare](https://github.com/Panlord/game-power-down/blob/master/Spooked/Assets/Zombie/JumpScare.jpg)  shows a true display of horror and malice that was once something the player might have had sympathy for from reading his descent into madness. 

## Press Kit and Trailer (Aaron Pan)

The press kit for our **game** can be found [here](https://panlord.github.io/game-power-down/EscapeFromKemper/index.html).  
The press kit for our **team** can be found [here](https://panlord.github.io/game-power-down/).  

The press kits were generated using Pixelnest Studio's [presskit.html](https://github.com/pixelnest/presskit.html), which is a complete re-implementation of [presskit()](http://dopresskit.com/) (basically, the press kit files are generated as static htmls rather than using php). Also, the description was an edited version of the synopsis Erik wrote in the Initial Plan Document.  

The trailer for our game can be found [here](https://www.youtube.com/watch?v=eUepg_Dtnwc). 

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**  
I browsed through a bunch of horror game trailers and took notes of what people did in them. Those notes can be found [here](https://docs.google.com/document/d/1pdPiYV6ynshz_D6uh5Mk_mkcWD4GaDzEIM1u53sjhTM/edit?usp=sharing). Then I just structured the trailer based off of what I liked from observing other horror game trailers (a lot of inspiration from the Outlast trailer because I really liked that one). I began with a little bit of the narrative (not too detailed though, so there aren’t any story spoilers) so the audience knows what they’re going to be doing in the game. Next the trailer transitions into footage of a whole gameplay loop from spawn -> finding any collectable item(s) -> obtaining the objective item -> attempting to escape -> encountering the monster -> losing. I wanted the audience to see what playing the game might be like. I feel that is one purpose of a trailer-- to inform the viewers of what they will be getting into upon downloading the game. Thus, I made sure to show most aspects of the game (map exploration, item collection, etc.) but not all (cursed notes, easter eggs, nuanced mechanics, etc.) so that players can be ~~pleasantly~~ surprised. I also only showed a small portion of the map so that players have places to explore.  
As for the screenshots, I made sure to include many of the things I listed in the trailer. To reiterate, I chose them based on what I would imagine a prospective player would want to see before downloading the game-- the menu, several screenshots of various locations throughout the map, several collectible items, some lore pieces, the inventory, and a partially visible still of the monster in action (only partially visible with its face covered so the player is in for a surprise when they get attacked!).  


## Game Feel (Everyone)

- We added a start menu then a bit of lore at the beginning of the game to get the player excited (or scared) to start. When the player reads the lore and hits "go" the game starts.
- We also added a stopwatch that starts counting when the player hits "go", the player can see the stopwatch on the top left of the screen.
- When the player comes across a lore object, the screen displays "E to interact", when the player hits E, he can pick up the lore item, when the player is finished reading about the item, they can close it and continue playing. The stopwatch is paused when the player is in any menu.
- The player can also pause the game at any time by hitting ESC.
- There are lore items scattered around the map so the player can attempt to understand the story while playing the game.
- Attempted to add a cameraLerp to have the camera face the monster before the jumpscare is played but due to many errors, we decided not to add it to the final build.
- A looped animated screen was added to the start menu to set the tone and mood for the rest of the game. This was done via switching to [`MainMenuCamera`](https://github.com/Panlord/game-power-down/blob/48e054be9381f1dbe74f3e914687beda097e2e53/Spooked/Assets/Scripts/MainMenuController.cs#L52) and slowly moving it forward in a direction.
