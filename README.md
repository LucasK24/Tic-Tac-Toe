# Tic-Tac-Toe
Author: Lucas Katsenevas

Last Modified: 8/17/2021

Currently, this tic-tac-toe application supports local multiplayer and single player modes. It keeps track of each player's total wins
and switches between who goes first each round. There is a new game button that can be pressed during or after each game.

For single-player mode, The AI has 3 difficulty levels - easy, hard, and impossible. On easy, the AI plays random moves,
each each with equal probability. On hard, the AI always makes winning moves (completes 3 in a row if there are already
2 of the 3 moves made) and blocks losses (the opponent getting 3 in a row on the subsequent move). On impossible difficulty,
the AI will always play a perfect game - it is guaranteed to win or tie. However, the player can't play the same pattern each
time to ensure ties, since the AI will make different moves and try different forking strategies from game to game.

All sound effects come from: https://mixkit.co/
