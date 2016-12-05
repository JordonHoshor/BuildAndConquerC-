# 3D Real Time Strategy Built with Unity and C#
- Currently 1 Human Player and 3 Ai Players

# Map/HUD
- Player can control the Camera with Up, Down, Left, Right arrows
- Minimap is active and tracks your current units
- Enemy units wont appear until they are within range
- Credits are tracked in the upper Right of the HUD
- Shows current selected unit information and actions
- HP is updated live for the currently selected unit

# Drone Unit
- Drones are controller with mouse, left and right click
- When a drone is selected, a rotating image appears to indicate that unit is currently selected
- Each player starts with 1 drone
- Drones can build a base or attack
- When build is clicked there is a Ghost of the structure that follows the mouse

# Command base
- Base can create more drones

# Simple Ai
- Weighted/sorted list for making decisions
- Can decide to Build, or Attack based on current units and credits
