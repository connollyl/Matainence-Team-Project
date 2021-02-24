package Application.Graphics;
import Application._Utilities;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;
import com.jogamp.opengl.util.awt.TextRenderer;
import java.awt.*;

/**
 * This class is for the Landing page of the game. The player will be taken to this screen on start up.
 */
public class StartScreen implements GLEventListener {
    TextRenderer renderer;
    TextRenderer CtrlRenderer;
    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
         renderer = new TextRenderer(new Font("SansSerif", Font.BOLD, 36));
         CtrlRenderer = new TextRenderer(new Font("SansSerif", Font.ITALIC, 20));
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {

        renderer.beginRendering(glAutoDrawable.getSurfaceWidth(), glAutoDrawable.getSurfaceHeight());
        //  set the color
        renderer.setColor(Color.white);
        renderer.draw("Asteroids", _Utilities.textStartPosX(-0.2f), _Utilities.textStartPosY(0.0f));
        renderer.draw("Press Any Key to Start!", _Utilities.textStartPosX(-0.3f), _Utilities.textStartPosY(-0.1f));
        renderer.endRendering();

        CtrlRenderer.beginRendering(glAutoDrawable.getSurfaceWidth(), glAutoDrawable.getSurfaceHeight());
        CtrlRenderer.setColor(Color.GREEN);
        CtrlRenderer.draw("Controls: ", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.2f));
        CtrlRenderer.draw("W thrust. A turn left. D turn right", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.25f));
        CtrlRenderer.draw("Space fire. S spawn", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.3f));
        CtrlRenderer.endRendering();
    }

    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {


    }
}
