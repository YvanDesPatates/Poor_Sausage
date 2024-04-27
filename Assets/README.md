# Poor Sausage
3D Arcade game.

Collect as many sausages as possible! But beware of traps, the longer you wait, the more there are! Will you master the challenge of Poor Sausage ?

## To-do list
- [x] player basic movements
- [x] collectible and score progressing on ATH
- [X] super collectible that spawn from time to time and give more score
- [x] first trap -> a bomb that spawn on top of the player and fall after X time. A light on the ground prevent that a bomb will fall.
- [x] second trap -> laser that active and deactive itself, moving for side to side
- [x] third trap -> rotating blade that block the player path
- [x] trapManager -> traps are randomly created each X time (depends on the trap) Game always start with bomb trap
- [x] game over -> display game over and block everything else (movements, score, collectible spawn, traps...). Possibility to restart the game.
- [x] player movements -> stop infinite jumps
- [x] player movements -> improve movements (don't glide on the ground)
- [x] player movements -> mouse cursor should not be blocked in the window


- [ ] fourth trap -> ?
- [ ] welcome screen -> display the game title and a start button.
- [ ] think about a cool map (how many layers/levels, types of platforms...)
- [ ] basics assets for all
- [ ] basic sound effects -> collect, die, explosion, laser
- [ ] basic visual effects -> collect, explosion, laser (not die unless model already has an animation for)


## Ideas of features
**Poop** : The daschund can poop a special sausage with more value than the classic one, but poop the sausage take time so it's dangerous. You can poop a sausage each X time, or wait and your special sausage will raise in value each X time. This feature encourage players to bet on how many time they cans wait to maximize the value of the poop, but without waiting that there is too much traps to take a pause and...poop.
**gamepad** : Refactoring player movements with an input manager and add gamepad support.

