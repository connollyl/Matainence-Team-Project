package Application.Graphics;

import Application.GameController;
import Application._Utilities;
import com.jogamp.newt.event.KeyListener;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;
import com.jogamp.opengl.util.awt.TextRenderer;

import java.awt.*;
import java.awt.event.KeyEvent;

public class EndScreen implements GLEventListener {
    private TextRenderer renderer;
    private TextRenderer CtrlRenderer;
    private GameController gameController;
    private String score, playName;
    private static EndScreen endScreen;
    private boolean isActive = false;
    private static final int MAX_SCORE_NAME = 3;

    private EndScreen(){ }

    public static EndScreen getInstance()
    {
        if(endScreen == null) {
            endScreen = new EndScreen();
            return endScreen;
        }
        return endScreen;
    }

    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        renderer = new TextRenderer(new Font("SansSerif", Font.BOLD, 36));
        CtrlRenderer = new TextRenderer(new Font("SansSerif", Font.ITALIC, 26));
        playName="";
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        isActive = true;
        score = String.format("%d",gameController.getInstance().getScore());
        renderer.beginRendering(glAutoDrawable.getSurfaceWidth(), glAutoDrawable.getSurfaceHeight());
        //  set the color
        renderer.setColor(Color.white);
        renderer.draw("THANKS FOR PLAYING", _Utilities.textStartPosX(-0.3f), _Utilities.textStartPosY(0.2f));
        renderer.draw("PLEASE ENTER YOUR INITIALS", _Utilities.textStartPosX(-0.4f), _Utilities.textStartPosY(0.1f));
        renderer.endRendering();
        CtrlRenderer.beginRendering(glAutoDrawable.getSurfaceWidth(), glAutoDrawable.getSurfaceHeight());
        CtrlRenderer.setColor(Color.GREEN);
        CtrlRenderer.draw(playName + "  " + score, _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(0.0f));

        //High scores
        CtrlRenderer.draw("HIGH SCORES", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.1f));
        CtrlRenderer.draw("DUG  900000000000", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.2f));
        CtrlRenderer.draw("RLZ  800000000000", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.3f));
        CtrlRenderer.draw("ALL  700000000000", _Utilities.textStartPosX(-0.25f), _Utilities.textStartPosY(-0.4f));
        CtrlRenderer.endRendering();
    }

    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {


    }

    public void keyPressed(KeyEvent keyEvent) {
        if(isActive)
        {
            int someCode = keyEvent.getKeyCode();
            Object someKeyCodeObject = new Integer(someCode);
            if (playName.length() < MAX_SCORE_NAME)
            {
                playName += KeyEvent.getKeyText((Integer) someKeyCodeObject);
            }
            else if (keyEvent.getKeyCode() == KeyEvent.VK_ENTER)
            {
                System.exit(0);
            }
        }
    }
}
