# MyProject-NetworkedGame
 My First Networked Game

Overview of the Game Design:
The project is a basic platformer that incorporates a networked multiplayer functionality. The core mechanics include player movement, jumping, and collecting strawberries for points. The game supports multiplayer interaction, allowing multiple players to join the game and see each other’s actions in real-time.
The main features of the game include:
 -Synchronized Player Movement: Player movement is smoothly synchronized across the network, ensuring that each player sees consistent movement of other players.
 -Collectibles: Players can collect strawberries to increase their score. The collectibles are synchronized across the network so that once collected, they disappear for all players.
 -Server Authority: The game uses server authority for managing critical aspects of gameplay.
 -In-game Communication: Players should be able to communicate with each other through an in-game chat system, adding a social element to the game.
The Network Features of this game:
 -The game uses a client-server architecture. The server handles most of the game logic and authoritative actions like player movement synchronization, collecting items, and scoring. 
 -Player Movement Synchronization:The movement of players is synchronized across the network using Unity’s Netcode for GameObjects (NGO).
 -Collectibles, such as strawberries, are also synchronized. Once a player collects a strawberry, the server verifies the action and informs all clients, ensuring the strawberry disappears 
 from all players’ screens. This ensures that no collectible can be collected by multiple players simultaneously.
 -Animation on objects is synchronised across the network.
 Challenges faced during this project:
I have faced a lots of challenges during this project, I was struggling with even the basic Network replication at first, but after extensive reasearch I managed to get the project working, I am proud with how far I have come with the project so far. I have leaned a lot and I expect to continue learning as I work towards completing this game.
Unfortunately, the game is not yet polished or close to being finished. For example, while I managed to synchronize the text scoring for the strawberries for the host, I still face issues from the client’s side. Additionally, the chat implementation function should work, but it doesn't at the moment, and I need to figure out how to fix it.

Reflection:
This project has greatly strengthened my understanding of Unity’s networking stack and deepened my knowledge of multiplayer game architecture. Moving forward, I plan to improve the communication system and add more complex networked interactions, such as competitive leaderboards or cooperative gameplay mechanics.
