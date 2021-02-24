package Application.Graphics;

import Application.GameController;
import Application.GameObject;
import Application._Utilities;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;

import java.awt.geom.Point2D;

/**
 * Creates a medium asteroid.
 */
public class MediumAsteroid extends BaseAsteroid{
    private final int POINT_VALUE = 1000;
    /**
     * default ctor. sets default position to 0,0
     */
    public MediumAsteroid(){
        this(0,0, 0);
    }

    /**
     * ctor for normal spawning circumstances.
     */
    public MediumAsteroid(float posx, float posy, float rotation){
        super(posx, posy, rotation, MEDIUM_ASTEROID_SIZE);
    }

    /**
     * This function is called whenever the graphics loop detects this object collided with a valid object.
     */
    @Override
    protected void onImpact() {
        gameController.DestroyAsteroid(this, POINT_VALUE);
    }
}
