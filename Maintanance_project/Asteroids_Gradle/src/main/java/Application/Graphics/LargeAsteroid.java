package Application.Graphics;

import Application.GameObject;
import Application._Utilities;
import Application.GameController;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLAutoDrawableDelegate;

import java.util.List;

/**
 * Creates a large asteroid
 */
public class LargeAsteroid extends BaseAsteroid {
    private final int POINT_VALUE = 500;
    /**
     * default ctor. sets default position to 0,0
     */
    public LargeAsteroid(){
        this(0,0, 0);

    }

    /**
     * ctor for normal spawning circumstances.
     */
    public LargeAsteroid(float posx, float posy, float rotation){
        super(posx, posy, rotation, LARGE_ASTEROID_SIZE);
    }

    /**
     * This function is called whenever the graphics loop detects this object collided with a valid object.
     */
    @Override
    protected void onImpact(){
        gameController.DestroyAsteroid(this, POINT_VALUE);
    }
}
