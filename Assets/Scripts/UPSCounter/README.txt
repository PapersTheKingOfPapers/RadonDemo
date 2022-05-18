This script requires the Unity Source Movement package available here,
https://github.com/Olezen/UnitySourceMovement

Follow the following instructions for a functional UPS Counter.

You just need a UI Text element, edit abit of the SurfController.cs, Player object requires SurfCharacter.cs and have the player object be tagged "Player".

1.
In SurfController.cs change on line 10

private ISurfControllable _surfer;

to

[HideInInspector] public ISurfControllable _surfer;

2.
Add the UPSCounter to the canvas object and reference the Text element to it

3. Enjoy