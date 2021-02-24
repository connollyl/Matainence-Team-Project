package Application;

import java.awt.event.KeyEvent;
import java.util.TimerTask;

public class FixedLoop extends TimerTask {
    GameController gameController = GameController.getInstance();

    @Override
    public void run() {
        GameObject.checkCollisions();
        gameController.SpawnNewAsteroids();
        if(gameController.isFirstKeyPressed() && gameController.isKeyPressed(KeyEvent.VK_S))
        {
            gameController.spawnPlayer();
        }
    }
}
