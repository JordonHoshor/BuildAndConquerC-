# 3D Real Time Strategy Built with Unity and C#

- Live Demo https://jordonhoshor.github.io/BuildAndConquer/

- Game logic [scripts](https://github.com/JordonHoshor/BuildAndConquerC-/tree/master/Assets/Scripts)

- Currently 1 Human Player and 3 Ai Players

# Map/HUD
- Player can control the Camera with Up, Down, Left, Right arrows
- Minimap is active and tracks your current units
- Enemy units wont appear until they are within range - CURRENTLY DISABLED
- Credits are tracked in the upper Right of the HUD
- Shows current selected unit information and actions
- HP is updated live for the currently selected unit

# Drone Unit
- Drones are controlled with mouse, left and right click
- When a drone is selected, a rotating image appears to indicate that unit is currently selected
- Each player starts with 1 drone
- Drones can build a base or attack

# Command base
- When build is clicked there is a Ghost of the structure that follows the mouse
- Base can create more drones

# Simple Ai
- Weighted/sorted list for making decisions
- Can decide to Build, or Attack based on current units and credits
