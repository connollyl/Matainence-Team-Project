package Application;

import Application.Graphics.*;

import com.jogamp.opengl.*;
import com.jogamp.opengl.awt.GLCanvas;
import com.jogamp.opengl.util.FPSAnimator;

import java.awt.*;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

/**
 * Gets the entire game set up to run.
 */
public class Main {

    private static int screenHeight = 600, screenWidth = 600;
    private static final int HEIGHT_OFFSET = 39, WIDTH_OFFSET = 16;
    private static final int FPS_UPDATE_FREQUENCY = 1;
    private static final int FRAMES_PER_SECOND = 60;
    private static float unitsTall = 2, unitsWide = 2;
    private static GLCanvas canvas = null;
    private static Frame frame = null;
    private static FPSAnimator fpsAnimator = null;
    private static GameDrawer gameDrawer = null;
    private static final int SPAWN_MIN = -1;
    private static final int SPAWN_MAX = 1;
    private static final int DEGREES = 360;

    /**
     * Sets up the scenes for our game and starts it up.
     * @param args
     */
    public static void main(String[] args)
    {
        startWindow();

        GameController gameController = GameController.getInstance();
        Scenes mainGame = gameController.getMainGame();
        GameObject medium = new MediumAsteroid(generateRandomCoordinate(),generateRandomCoordinate(), generateRandomRotation());
        GameObject small = new SmallAsteroid(generateRandomCoordinate(),generateRandomCoordinate(), generateRandomRotation());
        GameObject large = new LargeAsteroid(generateRandomCoordinate(), generateRandomCoordinate(), generateRandomRotation());
        GameObject large2 = new LargeAsteroid(generateRandomCoordinate(), generateRandomCoordinate(), generateRandomRotation());
        mainGame.addToScene(new CoordinateHelper());
        mainGame.addToScene(new LivesDisplay());
        mainGame.addToScene(large2);
        mainGame.addToScene(medium);
        mainGame.addToScene(small);
        mainGame.addToScene(large);
        mainGame.addToScene(new Score());

        Scenes mainMenu = gameController.getMainMenu();
        mainMenu.addToScene(new StartScreen());

        gameController.start();
    }

    /**
     * Does the initial setup for our OpenGL window.
     */
    private static void startWindow()
    {
        GLProfile glp = GLProfile.getDefault();
        GLCapabilities caps = new GLCapabilities(glp);
        canvas = new GLCanvas(caps);

        frame = new Frame("Asteroids");
        frame.setSize(screenWidth + WIDTH_OFFSET, screenHeight + HEIGHT_OFFSET);
        frame.add(canvas);
        frame.setVisible(true);
        frame.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });
        frame.setResizable(false);

        fpsAnimator = new FPSAnimator(canvas, FRAMES_PER_SECOND);
        canvas.display();
        fpsAnimator.start();
        fpsAnimator.setUpdateFPSFrames(FPS_UPDATE_FREQUENCY, null);
        canvas.requestFocus();
        canvas.addKeyListener(GameController.getInstance());
        gameDrawer = GameDrawer.getInstance();
        canvas.addGLEventListener(gameDrawer);
    }


    public static int getScreenHeight() {return screenHeight;}

    public static int getScreenWidth() {return screenWidth;}

    /**
     * Gets the time since the last frame was drawn.
     * @return Time since the last frame was drawn.
     */
    public static long getDeltaTimeMillis()
    {
        return fpsAnimator.getLastFPSPeriod() / FPS_UPDATE_FREQUENCY;
    }



    private static float generateRandomCoordinate(){
        return (float)Math.random() * (SPAWN_MAX - SPAWN_MIN) + SPAWN_MIN;
    }

    private static float generateRandomRotation(){
        return (float)Math.random() * DEGREES;
    }

}
