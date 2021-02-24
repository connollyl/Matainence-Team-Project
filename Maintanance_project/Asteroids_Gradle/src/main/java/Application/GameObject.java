package Application;

import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;

import java.awt.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

public abstract class GameObject implements GLEventListener {
    protected final int PLAYER_LAYER = 1, ASTEROID_LAYER = 2, BULLET_LAYER = 4,
            ALIEN_SPACESHIP_LAYER = 8, ALIEN_BULLET_LAYER = 16;
    private static final float PLAYABLE_SIZE = 2.2f;
    private int glListIndex = -1;
    protected Point2D.Float position = new Point2D.Float(0.0f, 0.0f);
    protected float rotation = 0;
    protected Point2D.Float [] polyVerts = null;
    private Point2D.Float [] polyVertsConverted = null;
    protected int collisionLayerMask = ASTEROID_LAYER + ALIEN_SPACESHIP_LAYER + ALIEN_BULLET_LAYER;
    protected int currentLayer = PLAYER_LAYER;
    private boolean isCollided = false;

    protected GameObject(Point2D.Float [] polyVerts)
    {
        this.polyVerts = polyVerts;
        this.polyVertsConverted = new Point2D.Float[polyVerts.length];
        for (int i = 0; i < polyVertsConverted.length; i++) {
            polyVertsConverted[i] = new Point2D.Float();
        }
        convertPolyVerts();
    }

    protected abstract void move();
    protected abstract void onImpact();

    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();
        glListIndex = gl.glGenLists(1);
        if(glListIndex > 0) {
            if(polyVerts.length == 1) {
                initPoint(gl);
            }
            else if(polyVerts.length == 2) {
                initLine(gl);
            }
            else if(polyVerts.length > 2) {
                initPolygon(gl);
            }
        }
    }


    private void initPoint(GL2 gl)
    {
        gl.glNewList(glListIndex, GL2.GL_COMPILE_AND_EXECUTE);
        gl.glColor3f(1.0f, 1.0f, 1.0f);
        gl.glBegin(gl.GL_POINT);
        gl.glPointSize(2.0f);
        gl.glVertex2f(polyVerts[0].x, polyVerts[0].y);
        gl.glEnd();
        gl.glEndList();
    }

    private void initLine(GL2 gl)
    {
        gl.glNewList(glListIndex, GL2.GL_COMPILE_AND_EXECUTE);
        gl.glColor3f(1.0f, 1.0f, 1.0f);
        gl.glBegin(gl.GL_LINE);
        gl.glVertex2f(polyVerts[0].x, polyVerts[0].y);
        gl.glVertex2f(polyVerts[1].x, polyVerts[1].y);
        gl.glEnd();
        gl.glEndList();
    }

    private void initPolygon(GL2 gl)
    {
        gl.glNewList(glListIndex, GL2.GL_COMPILE_AND_EXECUTE);
        gl.glColor3f(1.0f, 1.0f, 1.0f);
        for (int i = 0; i < polyVerts.length; i++) {
            gl.glBegin(gl.GL_LINES);
            gl.glVertex2f(polyVerts[i].x, polyVerts[i].y);
            gl.glVertex2f(polyVerts[(i + 1) % polyVerts.length].x, polyVerts[(i + 1) % polyVerts.length].y);
            gl.glEnd();
        }
        gl.glEndList();
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();
        gl.glDeleteLists(glListIndex, 1);
    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        move();
        checkMovement();
        if(isCollided) {
            onImpact();
            isCollided = false;
        }
        GL2 gl = glAutoDrawable.getGL().getGL2();
        _Utilities.preTransforms(gl, position, rotation);
        gl.glCallList(glListIndex);
        _Utilities.postTransforms(gl, position, rotation);
    }


    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {
    }

    public static void checkCollisions()
    {
        GameController gc = GameController.getInstance();
        List<GameObject> gameObjects = gc.getCurrentSceneGameObjects();
        for (int i = 0; i < gameObjects.size(); i++) {
            gameObjects.get(i).convertPolyVerts();
        }
        for (int i = 0; i < gameObjects.size() - 1; i++) {
            for (int j = i + 1; j < gameObjects.size(); j++) {
                GameObject gameObject1 = gameObjects.get(i);
                GameObject gameObject2 = gameObjects.get(j);
                if((gameObject1.currentLayer & gameObject2.collisionLayerMask) > 0
                        || (gameObject2.currentLayer & gameObject1.collisionLayerMask) > 0) {
                    selectCollisionType(gameObject1, gameObject2);
                }
            }
        }
    }

    private static void selectCollisionType(GameObject gameObject1, GameObject gameObject2)
    {
        if(gameObject1.polyVertsConverted == null || gameObject2.polyVertsConverted == null)
            return;
        if(gameObject1.polyVertsConverted.length > 2 && gameObject2.polyVertsConverted.length > 2) {
            if (isPolygonsIntersecting(gameObject1.polyVertsConverted, gameObject2.polyVertsConverted)) {
                gameObject1.isCollided = true;
                gameObject2.isCollided = true;
            }
        }
        else if(gameObject1.polyVerts.length == 1 && gameObject2.polyVerts.length > 2)
        {
            if(isPointInPolygon(gameObject1.polyVerts[0], gameObject2.polyVerts))
            {
                gameObject1.isCollided = true;
                gameObject2.isCollided = true;
            }
        }
        else if(gameObject2.polyVerts.length == 1 && gameObject1.polyVerts.length > 2)
        {
            if(isPointInPolygon(gameObject2.polyVerts[0], gameObject1.polyVerts))
            {
                gameObject1.isCollided = true;
                gameObject2.isCollided = true;
            }
        }

    }

    private void convertPolyVerts()
    {
        if(polyVertsConverted != null && polyVerts != null) {
            float rads = (float) Math.toRadians(rotation);
            for (int i = 0; i < polyVerts.length; i++) {
                float x = polyVerts[i].x;
                float y = polyVerts[i].y;
                polyVertsConverted[i].x = x * (float) Math.cos(rads) - y * (float) Math.sin(rads);
                polyVertsConverted[i].y = y * (float) Math.cos(rads) + x * (float) Math.sin(rads);
                polyVertsConverted[i].x = position.x + polyVertsConverted[i].x;
                polyVertsConverted[i].y = position.y + polyVertsConverted[i].y;
            }
        }
    }


    private static boolean rayIntersectsLine(Point2D.Float rayStart, Point2D.Float [] line)
    {
        //Shoot a ray to the right and see if it intersects
        // if the point is to the left of x and within the min max of height, then it intersects.
        Point2D.Float low, high;
        float m_red, m_blue;
        if(line[0].y > line[1].y)
        {
            high = line[0];
            low = line[1];
        }
        else
        {
            low = line[0];
            high = line[1];
        }
        if(rayStart.y < low.y || rayStart.y > high.y)
            return false;
        float slope = (high.y - low.y) / (high.x - low.x);
        float xPoint = ((rayStart.y - low.y)/slope) + low.x;
        if(rayStart.x <= xPoint) {
            return true;
        }
        return false;
    }

    private static boolean isPolygonsIntersecting(Point2D.Float [] polygon1, Point2D.Float [] polygon2)
    {
        for (int i = 0; i < polygon1.length; i++) {
            if(isPointInPolygon(polygon1[i], polygon2))
                return true;
        }
        for (int i = 0; i < polygon2.length; i++) {
            if(isPointInPolygon(polygon2[i], polygon1))
                return true;
        }
        return false;
    }

    private static boolean isPointInPolygon(Point2D.Float point, Point2D.Float [] polygon)
    {
        if(polygon.length < 3)
            return false;
        int count = 0;
        for (int i = 0; i < polygon.length; i++) {
            Point2D.Float [] line = {polygon[i], polygon[(i + 1) % polygon.length]};
            if(rayIntersectsLine(point, line))
                count++;
        }
        return (count % 2) == 1;
    }

    private void checkMovement() {
        if(position.y > PLAYABLE_SIZE / 2)
            position.y += -PLAYABLE_SIZE;
        else if(position.y < -PLAYABLE_SIZE / 2)
            position.y += PLAYABLE_SIZE;

        if(position.x > PLAYABLE_SIZE / 2)
            position.x += -PLAYABLE_SIZE;
        else if(position.x < -PLAYABLE_SIZE / 2)
            position.x += PLAYABLE_SIZE;
    }

}
