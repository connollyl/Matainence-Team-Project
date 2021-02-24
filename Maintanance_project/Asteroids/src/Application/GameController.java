package Application;

import Application.Graphics.*;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.List;
import java.util.Timer;

/**
 * Controls the flow of the game. It will be in charge of changing
 * scenes when the player goes from the main menu to the main game.
 */
public class GameController implements KeyListener
{


    public static final int STARTING_LIVES = 3;
    private static final int SPAWN_MIN = -1;
    private static final int SPAWN_MAX = 1;
    private static final int DEGREES = 360;
    private static final int SPAWN_INTERVAL =  8000;
    private Scenes mainMenu = new Scene();
    private Scenes mainGame = new Scene();
    private Scenes activeScene = null;
    private static GameController gameController = null;
    private long startTime;
    private long updateTime = 0;
    private Timer timer = null;
    private int score = 0;
    private static final int FIXED_LOOP_PERIOD = 10;
    private boolean isGameOver = false;


    private int numLives = STARTING_LIVES;
    private boolean isPlayerAlive = false;



    private boolean firstKeyPressed = false;


    private boolean keys[] = new boolean[1028];

    /**
     * Doesn't do any setup, but is required to enforce the
     * singleton pattern.
     */
    private GameController()
    {
        startTime = System.currentTimeMillis();
        java.util.Arrays.fill(keys, false);
    }

    public boolean isFirstKeyPressed() {
        return firstKeyPressed;
    }
    /**
     * Default implementation for a singleton.
     * @return A singleton of the GameController class
     */
    public static GameController getInstance()
    {
        if(gameController == null) {
            gameController = new GameController();
            return gameController;
        }
        return gameController;
    }

    /**
     * Listens for any keyevent while in the menu to start the game.
     * @param keyEvent
     */
    @Override
    public void keyTyped(KeyEvent keyEvent) {
        if(!gameStarted()){
            toMainGame();
        }
    }

    @Override
    public void keyPressed(KeyEvent keyEvent) {
        keys[keyEvent.getKeyCode()] = true;
        EndScreen.getInstance().keyPressed(keyEvent);
    }

    @Override
    public void keyReleased(KeyEvent keyEvent) {
        keys[keyEvent.getKeyCode()] = false;
        firstKeyPressed = true;
    }

    /**
     * Starts up our game.
     */
    public void start()
    {
        mainMenu.startScene();
        activeScene = mainMenu;
        timer = new Timer();
        timer.schedule(new FixedLoop(), 0, FIXED_LOOP_PERIOD);
    }



    /**
     * Gets the scene associated with the main menu
     * @return The main menu scene
     */
    public Scenes getMainMenu() {
        return mainMenu;
    }

    /**
     * Gets the scene associated with the main game
     * @return The game scene
     */
    public Scenes getMainGame() {
        return mainGame;
    }

    /**
     * Checks if the game is started.
     * @return
     */
    public boolean gameStarted(){
        return mainGame == activeScene;
    }

    /**
     * Gets the amount of milliseconds since the game started.
     * @return Amount of milliseconds since the game started.
     */
    public long getGameTimeMillis()
    {
        return (System.currentTimeMillis() - startTime);
    }

    /**
     * Checks whether a key has been pressed, but not released yet.
     * @param keyCode keyCode of the desired key.
     * @return Whether the key is pressed.
     */
    public boolean isKeyPressed(int keyCode) {
        return keys[keyCode];
    }

    /**
     * Gets a list of physics based GameObjects currently active in the scene.
     * @return A list of physics based GameObjects currently active in the scene.
     */
    public List<GameObject> getCurrentSceneGameObjects()
    {
        return activeScene.getGameObjects();
    }

    /**
     * Function for spawning asteroids every {SPAWN_INTERVAL} milliseconds.
     * Checks if game is currently in progress and it is time to spawn a new asteroid.
     */
    public void SpawnNewAsteroids(){
        if(gameStarted() && getGameTimeMillis() > updateTime){
            GameObject newAsteroid = new LargeAsteroid(generateRandomCoordinate(), generateRandomCoordinate(), generateRandomRotation());
            getMainGame().addToScene(newAsteroid);
            updateTime += SPAWN_INTERVAL;
        }
    }

    /**
     * Handles destroying asteroids on impact. decides what to do depending on the size of the asteroid getting destroyed.
     * @param asteroid The asteroid getting destroyed.
     * @param score The score value of the asteroid.
     */
    public void DestroyAsteroid(BaseAsteroid asteroid, int score){
        Scenes game = getMainGame();
        GameObject newAsteroid1 = null, newAsteroid2 = null;
        float newXPos = (float)(asteroid.position.x + (Math.cos(Math.toRadians(asteroid.rotation)) * .1));
        float newYPos = (float)(asteroid.position.y + (Math.sin(Math.toRadians(asteroid.rotation)) * .1));
        if(asteroid instanceof LargeAsteroid){
            newAsteroid1 = new MediumAsteroid(newXPos, newYPos, generateRandomRotation());
            newAsteroid2 = new MediumAsteroid(newXPos, newYPos, generateRandomRotation());
        }
        else if(asteroid instanceof MediumAsteroid){
            newAsteroid1 = new SmallAsteroid(newXPos, newYPos, generateRandomRotation());
            newAsteroid2 = new SmallAsteroid(newXPos, newYPos, generateRandomRotation());
        }
        else if(asteroid instanceof SmallAsteroid){
            addScore(score);
            game.removeFromScene(asteroid);
            return;
        }
        else{
        }
        game.removeFromScene(asteroid);
        game.addToScene(newAsteroid1);
        game.addToScene(newAsteroid2);
        addScore(score);
    }

    /**
     * Adds value to the current score.
     * @param value The value to add to the score.
     */
    public void addScore(int value){
        score += value;
    }

    public int getScore(){
        return score;
    }



    /**
     * Subtracts a life from the player when it dies.
     */
    public void onDeath()
    {
        isPlayerAlive = false;
        if(numLives <= 0)
        {
            onGameEnd();
        }
    }

    /**
     * Adds a life to the player when they earn it.
     */
    public void addLife()
    {
        numLives++;
    }

    /**
     * Ran when the game is finished.
     */
    private void onGameEnd()
    {
        GameDrawer.getInstance().startEndScreen();
    }

    /**
     * Spawns the player into the scene and reduces the number of lives they have.
     */
    public void spawnPlayer()
    {

        if(!isPlayerAlive && numLives > 0)
        {
            numLives--;
            isPlayerAlive = true;
            gameController.getMainGame().addToScene(new Player());
        }
    }

    public int getNumLives() {
        return numLives;
    }

    private static float generateRandomCoordinate(){
        return (float)Math.random() * (SPAWN_MAX - SPAWN_MIN) + SPAWN_MIN;
    }

    private static float generateRandomRotation(){
        return (float)Math.random() * DEGREES;
    }

    /**
     * Transitions from the main menu to the main game.
     */
    private void toMainGame()
    {
        mainMenu.endScene();
        mainGame.startScene();
        activeScene = mainGame;
        updateTime = getGameTimeMillis() + SPAWN_INTERVAL;
    }

}


