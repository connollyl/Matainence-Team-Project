package Application.Graphics;

import Application.Main;
import com.jogamp.opengl.GL;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;
import com.jogamp.opengl.GL2;

/**
 * Used in development to help us determine where the center of the screen is
 * as well as object placement.
 */
public class CoordinateHelper implements GLEventListener
{
    private int glListIndex = -1;
    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();

        glListIndex = gl.glGenLists(1);
        if(glListIndex > 0)
        {
            gl.glNewList(glListIndex, GL2.GL_COMPILE_AND_EXECUTE);
            gl.glColor3d(1.0f, 1.0f, 1.0f);
            //Vertical line
            gl.glBegin(GL2.GL_LINES);
            gl.glVertex2f(0.0f, 1.0f);
            gl.glVertex2f(0.0f, -1.0f);
            gl.glEnd();

            //Horizontal line
            gl.glBegin(GL2.GL_LINES);
            gl.glVertex2f(-1.0f, 0.0f);
            gl.glVertex2f(1.0f, 0.0f);
            gl.glEnd();
            gl.glEndList();
        }
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        GL2 gl = glAutoDrawable.getGL().getGL2();
        gl.glCallList(glListIndex);

    }

    /**
     * Creates a crosshair for placing objects on.
     * @param gl The GL2 object to render with.
     * @param xPos X Position to render crosshairs at.
     * @param yPos Y position to render crosshairs at.
     */
    private void crossHairs(GL2 gl, float xPos, float yPos)
    {
        gl.glBegin(GL.GL_LINES);
        gl.glVertex2f(xPos + -0.1f, yPos + 0.0f);
        gl.glVertex2f(xPos + 0.1f, yPos + 0.0f);
        gl.glEnd();
        gl.glBegin(GL.GL_LINES);
        gl.glVertex2f(xPos + 0.0f, yPos + -0.1f);
        gl.glVertex2f(xPos + 0.0f, yPos + 0.1f);
        gl.glRotatef(1.1f, 1.1f, 1.1f, 1.1f);
        gl.glEnd();
    }

    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {

    }
}
