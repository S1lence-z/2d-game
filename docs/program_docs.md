# Code Documentation

This part of the game documentation provides information about the scripts and classes the game uses to operate.

The game has **30 scripts** which can be divided into **5 groups**:

- **Player Scripts**: these scripts can only be found on player prefabs, they take care of the player's behaviour
- **Game Score Scripts**: these scripts take care of score counting
- **UI Scripts**: these scripts provide functionality for buttons and UI elements on various game screens
- **Item Scripts**: these scripts are unique to certain items, they care of individual item's functionality
- **General Use Scripts**: these scripts provide general functionality which can be used in any other script or class

---

# Player Scripts

1. **PlayerMovement**: this class takes care of the player's movement behaviour for the levels game mode and animations
2. **PlayerLife**: this class takes care fo the player's interaction with traps and provides information about the HP of the player
3. **InfinitePlayerMovement**: this calss takes of the player's movement behaviour for the infinite game mode and animations
4. **InfinitePlayerLife**: this class takes care fo the player's interaction with traps and provides information about the HP of the player
5. **PlayerSpriteRenderer**: this class is only present on the Player Dynamic prefab as it takes care of sprite renderer switching (small player and big player) and animations related to it

---

# Game Score Scripts

1. **GameScore**: this class keeps track of the score while the player is playing and it also updates the score count in the levels game mode
2. **InfiniteGameScore**: this class keeps track of the score while the player is playing and it also updates the score count in the infinite game mode
3. **FinalScore**: this class updates the current run's score which is displayed when the player runs out of hp or wins the game
4. **AllTimeHighScore**: this class keeps track of the current game session's all time high score

---

# UI Scripts

1. **GameSettings**: this class provides game mode settings, for example which game mode was chosen by the player
2. **StartGame**: this class provides functionality for the start screen buttons where the player can choose which mode he wants to play
3. **EndGame**: this class provides functionality for the end game screens' buttons which show up when the player either wins or loses
4. **PowerUpStatus**: this class updates the UI and shows if a power up is active or inactive (currentyl it only makes sense for double jumping)

---

# Item Scripts

## Camera

1. **CameraController**: this class provides basic camera control features, it makes the camera follow the player anywhere he goes
2. **SideScrolling**: this class enables side scrolling for the camera meaning that the player can only move to the right (the left side becomes inaccessible to the player)

## Enemies

1. **EnemyMovement**: this class takes care of the enemy movement, both horizontal and vertical values can be set

## Objects (mainly prefabs)

1. **FanController**: this class is only used the the fan prefab and it provides the fan's functionality
2. **FinishLevel**: this class is only used the finish line prefab and it progresses the player to the next level
3. **PowerUp**: this class is only used by power up prefabs and it contains all in game power ups' settings
4. **PortalController**: this class is only used the portal prefab and it provides the portal's functionality
5. **Sticky Platform**: this class is only used by the sticky platform prefab and it proved its functionality
6. **SurpriseBox**: this class is only used by the surprise box prefab, the surprise item can be set
7. **TrampolineJump**: this calss is only used by the trampoline prefab, trampoline jump force can be set

---

# General Use Scripts

1. **IMovement**: an interface that provides general functionlity for both player movement scripts
2. **WaypointFollower**: a class that makes an object follow the desired number of waypoints
3. **Rotate**: a class which makes the sprite of any object rotate at the user's desired speed
4. **PopUpEffect**: a class which makes an object pop up opon impact with the player from below
5. **AnimatedSprite**: a class which takes several sprites and animates them at the desired speed
6. **LevelGenerator**: a class which takes a list of platform prefabs and generates when the player gets near the next platform
7. **Extensions**: a class which provides fuctions which can be used by any other class, they usually provide delay before doing something (loading a scene or calling a method)

---

# Assets

There are **2 types** of assets in this game:

1. **Custom Assets** - These are custom made assets which I made myself, they can be found in the **Custom Assets folder**.
2. **Imported Assets** - These are assets that were made by somebody else, I downloaded them from the Unity Asset Store where they are published. These assets can be found in the **Imported Assets folder**.