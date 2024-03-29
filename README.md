# Custom Chess

### Objective
* Practice the features of C#, get creative, have fun.

### New Snowman Chess Piece

I made a Snowman piece that replaces the queen. It can move and capture pieces one space up, down, left, and right. Unlike other pieces however, when Snowman captures a piece, it turns into an Explode piece which explodes in a one by one explosion radius after one move. When it explodes, all pieces in the explosion radius, including the friendly pieces, are removed.

### New "smart" chess player

I also made a new type of “smart” chess player called SmartPlayer. It reliably beats the BasePlayer when playing as either black or white. Currently, I have to manually change the player type in ConsoleChess.cs. The default player1 is BasePlayer who plays white pieces, and default player 2 is SmartPlayer who plays black pieces.

The idea with SmartPlayer is that it checks every board option and chooses the one with more nulls on the board because they indicate a capture. Generally, when a piece is captured, it results in an extra space/null on the board. To make it more interesting and random, when there are no capture options on the board, it chooses a random move using a random number generator similar to BasePlayer.

Balance Criteria: 
* Piece is not over-powered or useless or like any other piece
* Piece uses a unique snowman symbol (https://unicode-table.com/en) when displayed on the board

![SnowmanPiece on Board](Screenshots/SnowmanPiece.png)

### Demo

Below we see the white Snowman capture a black Knight and then turn into the Explode piece (red warning sign). The Explode piece explodes everything near its 1x1 radius after one move.

![Snowman1](Screenshots/Snowman1.png)
![Snowman2](Screenshots/Snowman2.png) </br>
![Snowman3](Screenshots/Snowman3.png)
![Snowman4](Screenshots/Snowman4.png)
