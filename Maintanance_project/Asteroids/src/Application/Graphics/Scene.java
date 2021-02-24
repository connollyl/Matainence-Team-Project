package Application.Graphics;

import Application.GameObject;
import Application.Main;
import com.jogamp.opengl.GLEventListener;

import java.util.ArrayList;
import java.util.List;

/**
 * This holds actors within a scene. It also manages starting and ending
 * the scene.
 */
public class Scene implements Scenes
{
    private List<GLEventListener> actors = new ArrayList<>();
    private boolean isActive = false;
    private List<GameObject> gameObjects = new ArrayList<>();

    @Override
    public void addToScene(GLEventListener actor) {
        if(isActive)
        {
            GameDrawer.getInstance().startDrawing(actor);
        }
        actors.add(actor);
    }

    @Override
    public void addToScene(GameObject gameObject) {
        if(isActive)
        {
            GameDrawer.getInstance().startDrawing(gameObject);
        }
        gameObjects.add(gameObject);
    }

    @Override
    public void removeFromScene(GLEventListener actor)
    {
        if(isActive)
        {
            GameDrawer.getInstance().stopDrawing(actor);
        }
        actors.remove(actor);
    }

    @Override
    public void removeFromScene(GameObject gameObject) {
        if(isActive)
        {
            GameDrawer.getInstance().stopDrawing(gameObject);
        }
        gameObjects.remove(gameObject);
    }

    @Override
    public void startScene()
    {
        if(!isActive)
        {
            isActive = true;
            for (int i = 0; i < actors.size(); i++)
            {
                GameDrawer.getInstance().startDrawing(actors.get(i));
            }
            for (int i = 0; i < gameObjects.size(); i++)
            {
                GameDrawer.getInstance().startDrawing(gameObjects.get(i));
            }
        }
    }

    @Override
    public void endScene()
    {
        if(isActive)
        {
            isActive = false;
            for (int i = 0; i < actors.size(); i++)
            {
                GameDrawer.getInstance().stopDrawing(actors.get(i));
            }
            for (int i = 0; i < gameObjects.size(); i++)
            {
                GameDrawer.getInstance().stopDrawing(gameObjects.get(i));
            }
        }
    }

    @Override
    public List<GameObject> getGameObjects()
    {
        return  gameObjects;
    }
}
