package Application.Graphics;

import Application.GameController;
import Application.GameObject;
import Application._Utilities;
import com.jogamp.opengl.GL2;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;

import java.awt.geom.Point2D;

/**
 * Handles displaying how many lives the player currently has. Should be extendable to include more than
 * just 3 lives. Currently maxes out at displaying 16 lives.
 */
public class LivesDisplay implements GLEventListener {
    private static final Point2D.Float STARTING_POS = new Point2D.Float(-0.94f, -0.94f);
    private static final Point2D.Float SPACING = new Point2D.Float(.06f, 0.0f);
    private GameController gameController = GameController.getInstance();
    private static final int MAX_LIVES = 16;
    private int glList = -1;
    private static final float SIZE = 0.28f;
    private static Point2D.Float [] points = {
            new Point2D.Float(0f * SIZE, 0.10f * SIZE),
            new Point2D.Float(-0.08f * SIZE, -0.08f * SIZE),
            new Point2D.Float(0f * SIZE, -.05f * SIZE),
            new Point2D.Float(0.08f * SIZE, -0.08f * SIZE)
    };


    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();
        int startingIndex = gl.glGenLists(1);
        glList = startingIndex;
        if(glList > 0) {
            gl.glNewList(glList, GL2.GL_COMPILE_AND_EXECUTE);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            for (int j = 0; j < points.length; j++) {
                gl.glBegin(gl.GL_LINES);
                gl.glVertex2f(points[j].x, points[j].y);
                gl.glVertex2f(points[(j + 1) % points.length].x, points[(j + 1) % points.length].y);
                gl.glEnd();
            }
            gl.glEndList();
        }
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();
        for (int i = 0; i < Math.min(gameController.getNumLives(), MAX_LIVES); i++) {
            Point2D.Float displayPos = new Point2D.Float(STARTING_POS.x + (SPACING.x * i),
                    STARTING_POS.y + (SPACING.y * i));
            _Utilities.preTransforms(gl, displayPos, 0.0f);
            gl.glCallList(glList);
            _Utilities.postTransforms(gl, displayPos, 0.0f);
        }
    }

    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {

    }

    /**
     * Handles transformations before rendering.
     * @param gl current openGL context.
     * @param rotation What rotation to draw at.
     * @param position Where to draw.
     */
    private void preTransforms(GL2 gl, float rotation, Point2D.Float position)
    {
        gl.glTranslatef(position.x, position.y, 0);
        gl.glRotatef(rotation, 0, 0, 1);
    }

    /**
     * Handles transformations after rendering.
     * @param gl current openGL context.
     * @param rotation What rotation to draw at.
     * @param position Where to draw.
     */
    private void postTransforms(GL2 gl, float rotation, Point2D.Float position)
    {
        gl.glRotatef(-rotation, 0, 0, 1);
        gl.glTranslatef(-position.x, -position.y, 0);
    }


}
