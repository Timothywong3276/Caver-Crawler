# Cavern Crawler: Text-Based Dungeon Combat Simulator

**Cavern Crawler** is a text-based roguelike game built in C# that immerses players in turn-based combat against monsters in a dungeon setting. The game challenges players to strategically manage their health, energy, and attacks while defeating enemies.

## Features

- **Turn-Based Combat**: Engage in tactical battles with various options like attacking, charging, casting spells, or using items.
- **Player Stats**: Keep track of your health, energy, damage, and dice rolls as you progress.
- **Dynamic Enemy Encounters**: Face randomly generated enemies with unique health and attack stats.
- **Spell System**: Utilize powerful spells with varying effects to gain the upper hand in combat.
- **GUI Representation**: A simple text-based user interface displaying player stats, enemy health, and combat options.
- **Victory Celebration**: Successfully defeating the enemy leads to a satisfying end screen congratulating your efforts.

## How to Play

1. **Start the Game**: Launch the game and press any key to begin.
2. **Combat Options**:
   - **Attack**: Roll dice to deal damage to the enemy.
   - **Charge**: Increase the dice rolls for your next attack.
   - **Spell**: Cast a spell to deal damage, heal, or enhance your abilities.
   - **Item**: Use items (to be implemented).
3. **Enemy Turn**: The enemy attacks back based on its stats.
4. **Win Condition**: Reduce the enemy's health to zero to win.
5. **Lose Condition**: If your health drops to zero, the game ends.

## Controls

- Input numbers `[1-4]` to choose your actions during combat:
  - `1`: Attack
  - `2`: Charge
  - `3`: Cast Spell
  - `4`: Use Item
- Follow on-screen instructions to progress through the game.

## Code Overview

### Key Components

1. **Player Stats**:
   - Health (`php`, `phpmax`)
   - Energy (`penergy`, `penergymax`)
   - Damage, dice rolls, and resistance stats.
   
2. **Enemy Stats**:
   - Dynamically generated with health, damage, and dice attributes.

3. **Spell System**:
   - Allows players to choose and execute spells with unique effects.
   - Example: Healing, increased damage, or resistance boosts.

4. **Game Loop**:
   - Runs while the player and enemy are alive.
   - Updates stats, executes combat actions, and displays the game GUI.

5. **GUI Function**:
   - Displays player stats and combat information.

### Classes

- **Program**: Main class controlling the game loop and combat mechanics.
- **Enemy**: Handles enemy generation and attacks.
- **Spell**: Manages spells, including their effects and execution.

## Future Improvements

- Implement the **Item System** for additional player strategies.
- Add more enemy types and unique combat mechanics.
- Introduce a leveling system and multiple encounters.
- Improve text-based visuals with ASCII art or animations.
- Expand gameplay with a dungeon-crawling feature.

## How to Run

1. Install [.NET SDK](https://dotnet.microsoft.com/download) if not already installed.
2. Clone this repository and navigate to the project directory:
   ```bash
   git clone https://github.com/your-username/cavern-crawler.git
   cd cavern-crawler
