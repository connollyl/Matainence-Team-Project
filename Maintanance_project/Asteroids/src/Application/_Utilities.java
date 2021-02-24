package Application;

import com.jogamp.opengl.GL2;

import java.awt.geom.Point2D;

/**
 * Holds any functions that can be helpful.
 */
public class _Utilities
{
    /**
     * Takes the position and translates that to a pixel position for text on screen.
     * @param x The X position you'd like the text to start at.
     * @return The pixel position of the X coordinate of the text.
     */
    public static int textStartPosX(float x)
    {
        return (int)((Main.getScreenWidth() * x) + (Main.getScreenWidth() / 2));
    }

    /**
     * Takes the position and translates that to a pixel position for text on screen.
     * @param y The y position you'd like the text to start at.
     * @return The pixel position of the y coordinate of the text.
     */
    public static int textStartPosY(float y)
    {
        return (int)((Main.getScreenHeight() * y) + (Main.getScreenHeight() / 2));
    }


    /**
     * Handles transformations before rendering.
     * @param gl current openGL context.
     * @param rotation What rotation to draw at.
     * @param position Where to draw.
     */
    public static void preTransforms(GL2 gl, Point2D.Float position, float rotation)
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
    public static void postTransforms(GL2 gl, Point2D.Float position, float rotation)
    {
        gl.glRotatef(-rotation, 0, 0, 1);
        gl.glTranslatef(-position.x, -position.y, 0);
    }
}

