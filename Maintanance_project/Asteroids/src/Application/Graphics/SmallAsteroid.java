package Application.Graphics;

import Application.GameObject;
import Application._Utilities;
import Application.GameController;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;

import java.awt.geom.Point2D;

/**
 * Creates a small size asteroid.
 */
public class SmallAsteroid extends BaseAsteroid {
    private final int POINT_VALUE = 1500;
    /**
     * default ctor. sets default position to 0,0
     */
    public SmallAsteroid() {
        this(0, 0, 0);
    }

    /**
     * ctor for normal spawning circumstances.
     */

    public SmallAsteroid(float posx, float posy, float rotation) {
        super(posx, posy, rotation, SMALL_ASTEROID_SIZE);
    }

    /**
     * This function is called whenever the graphics loop detects this object collided with a valid object.
     */
    @Override
    protected void onImpact(){
        gameController.DestroyAsteroid(this, POINT_VALUE);
    }
}