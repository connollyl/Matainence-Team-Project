package Application.Graphics;

import Application.GameController;
import Application._Utilities;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;
import com.jogamp.opengl.util.awt.TextRenderer;

import java.awt.*;

public class Score implements GLEventListener {
    TextRenderer renderer;
    TextRenderer CtrlRenderer;
    GameController game;

    /**
     * GL Init fuction.
     * @param glAutoDrawable
     */
    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        renderer = new TextRenderer(new Font("SansSerif", Font.PLAIN, 18));
        game = GameController.getInstance();
    }

    /**
     * GL Dispose function. Unused.
     * @param glAutoDrawable
     */
    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    /**
     * GL Display function. Displays score on the top left corner of the screen. Gets score from GameController.
     * @param glAutoDrawable
     */
    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        renderer.beginRendering(glAutoDrawable.getSurfaceWidth(), glAutoDrawable.getSurfaceHeight());
        //  set the color
        renderer.setColor(Color.white);
        renderer.draw(String.format("Score: %07d", game.getScore()), _Utilities.textStartPosX(-0.5f), _Utilities.textStartPosY(0.45f));
        renderer.endRendering();
    }

    /**
     * GL Reshape function. Unused.
     */
    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {

    }
}
