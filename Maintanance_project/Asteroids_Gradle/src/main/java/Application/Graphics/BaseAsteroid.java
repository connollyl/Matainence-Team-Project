package Application.Graphics;

import Application.GameController;
import Application.GameObject;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;

import java.awt.geom.Point2D;

/**
 * Base Class for asteroids. Handles common functionality between asteroids.
 */
public abstract class BaseAsteroid extends GameObject {
    protected final static int SMALL_ASTEROID_SIZE = 40;
    protected final static int MEDIUM_ASTEROID_SIZE = 22;
    protected final static int LARGE_ASTEROID_SIZE = 9;
    protected static int asteroid_multiplier = 10;
    protected GameController gameController;
    private float VEL = 0.00025f;
    private float xVel, yVel;

    /**
     * BaseAsteroid itself should not be instantiated.
     */
    private BaseAsteroid() {
        this(0,0, 0, 10);
    }

    /**
     * ctor to allow for normal spawning circumstances.
     * This ctor is used by child classes.
     */
    protected BaseAsteroid(float posx, float posy, float rot, int size) {
        super(initArray(size));
        gameController = GameController.getInstance();
        asteroid_multiplier = size;
        position.x = posx;
        position.y = posy;
        rotation = rot;
        VEL *= size;
        xVel = (float)(VEL * Math.cos(Math.toRadians(rot)));
        yVel = (float)(VEL * Math.sin(Math.toRadians(rot)));
        super.collisionLayerMask = PLAYER_LAYER + BULLET_LAYER + ALIEN_BULLET_LAYER + ALIEN_SPACESHIP_LAYER;
        super.currentLayer = ASTEROID_LAYER;
    }

    /**
     * Creates the graphics of the asteroids.
     * @param size determines the size of the asteroid being created.
     * @return the point array that defines the asteroid shape.
     */
    public static Point2D.Float[] initArray(int size){
        return new Point2D.Float[] {
                new Point2D.Float(0.0f/size, 0.0f/size - 1.5f/size),
                new Point2D.Float(1.0f/size, 1.0f/size - 1.5f/size),
                new Point2D.Float(1.0f/size, 2.0f/size - 1.5f/size),
                new Point2D.Float(0.5f/size, 3.0f/size - 1.5f/size),
                new Point2D.Float(0.25f/size,2.5f/size  - 1.5f/size),
                new Point2D.Float(-0.25f/size, 3.0f/size - 1.5f/size),
                new Point2D.Float(-1.0f/size, 2.0f/size - 1.5f/size),
                new Point2D.Float(-1.0f/size, 1.0f/size - 1.5f/size),
                new Point2D.Float(-0.5f/size, 0.75f/size - 1.5f/size),
                new Point2D.Float(0.0f/size, 0.0f/size - 1.5f/size)
        };
    }

    /**
     * All asteroids move the same way after velocity is calculated.
     */
    @Override
    protected void move() {
        rotation += 0.2f;
        position.x += xVel;
        position.y += yVel;
    }

    /*
     Abstracted because onImpact depends on the size of the asteroid.
    */
    @Override
    protected abstract void onImpact();
}
