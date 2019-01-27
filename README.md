# RollingCircle

## Simple 2D side-scrolling infinite "roller" Unity game

1. Start screen

    When entering game at first, start screen is showed. User can select "`Start`" to start playing game, or "`Quit`" to exit game.

2. Game scene

    When entering game, rolling circle will continuously scroll. User need to jump the circle ( by pressing <`Space`> ) to pass over square obstacle. For each obstacle passed, user will earn 10 points. The collected scores will be display at the top.

    If circle is collided with square obstacle, game is over. Game over scene appeared.
    There is no restart option in this situation, just close the game window.

    When playing game, user can pause/resume the game by pressing <`ESC`>. The pause menu will be displayed where user could select "`Resume`" to continue playing game or "`Quit`" to exit the game.

    Note that in this case, user's score will not be submmitted to leader board service

3. Gameover

    When game over, a text is displayed indicating the end of game. The final score will be displayed also.

    Note that the game will try to summit the final score to leader board service with follwing format:

    - Request

    "`POST /leaderboard`"

    Body:

    ```json
    {
        "userName": "some-user-name",
        "score": 120
    }
    ```

    - Response also will be logged when running with Unity Editor
        - 404 - Username not found (user has not registered with the leaderboard service)
        - 405 - Invalid Username supplied
        - 200 - Ok

    Currently there is no real leader board service (url is set to "192.168.1.1") used.