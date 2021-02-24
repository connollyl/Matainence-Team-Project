package Application.Graphics;

import com.jogamp.opengl.GL;
import com.jogamp.opengl.GLAutoDrawable;
import com.jogamp.opengl.GLEventListener;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Semaphore;

public class GameDrawer implements GLEventListener {

    private static GameDrawer gameDrawer = null;
    private List<GLEventListener> drawList = new ArrayList<>();
    private List<GLEventListener> toAdd = new ArrayList<>();
    private List<GLEventListener> toRemove = new ArrayList<>();
    private boolean isGameOver = false;
    private Semaphore drawListSemaphore = new Semaphore(1);
    private EndScreen endScreen = EndScreen.getInstance();

    private GameDrawer()
    {

    }

    /**
     * Default implementation for a singleton.
     * @return A singleton of the GameDrawer class
     */
    public static GameDrawer getInstance()
    {
        if(gameDrawer == null) {
            gameDrawer = new GameDrawer();
            return gameDrawer;
        }
        return gameDrawer;
    }

    public void startDrawing(GLEventListener gameObject)
    {
        try {

            drawListSemaphore.acquire();
            toAdd.add(gameObject);
            drawListSemaphore.release();
        }
        catch(Exception e)
        {
            System.out.println("Failed to load object: " + gameObject.toString());
        }
    }


    public void stopDrawing(GLEventListener gameObject)
    {
        try {
            drawListSemaphore.acquire();
            toRemove.add(gameObject);
            drawListSemaphore.release();
        }
        catch(Exception e)
        {
            System.out.println("Failed to unload object: " + gameObject.toString());
        }
    }

    private void preDraw(GLAutoDrawable glAutoDrawable)
    {
        try {
            drawListSemaphore.acquire();
            for (int i = 0; i < toAdd.size(); i++) {
                toAdd.get(i).init(glAutoDrawable);
                drawList.add(toAdd.get(i));
            }
            toAdd.clear();
            for (int i = 0; i < toRemove.size(); i++) {
                drawList.remove(toRemove.get(i));
                toRemove.get(i).dispose(glAutoDrawable);
            }
            toRemove.clear();
            drawListSemaphore.release();
        }
        catch(Exception e)
        {
            System.out.println("An error occurred in the preDraw");
        }
    }




    @Override
    public void init(GLAutoDrawable glAutoDrawable) {
        endScreen.init(glAutoDrawable);
    }

    @Override
    public void dispose(GLAutoDrawable glAutoDrawable) {

    }

    @Override
    public void display(GLAutoDrawable glAutoDrawable) {
        preDraw(glAutoDrawable);
        glAutoDrawable.getGL().getGL2().glClear(GL.GL_COLOR_BUFFER_BIT);
        for (int i = 0; i < drawList.size(); i++) {
            drawList.get(i).display(glAutoDrawable);
        }
        if(isGameOver)
        {

            endScreen.display(glAutoDrawable);
        }
    }

    @Override
    public void reshape(GLAutoDrawable glAutoDrawable, int i, int i1, int i2, int i3) {

    }

    public void startEndScreen()
    {
        isGameOver = true;
    }

}
