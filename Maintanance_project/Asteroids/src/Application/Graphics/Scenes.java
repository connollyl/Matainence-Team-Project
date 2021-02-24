package Application.Graphics;

import Application.GameObject;
import com.jogamp.opengl.GLEventListener;

import java.util.List;

/**
 * Interface that other classes can use to add and remove things
 * from a scene.
 */
public interface Scenes
{
    /**
     * Adds an actor to a scene. If that scene is active, it should
     * also start drawing that object.
     * @param actor The actor to add to the scene.
     */
    void addToScene(GLEventListener actor);
    /**
     * Adds an gameObject to a scene. If that scene is active, it should
     * also start drawing that object.
     * @param gameObject The actor to remove from the scene.
     */
    void addToScene(GameObject gameObject);

    /**
     * Removes an gameObject from a scene. If that scene is active, it should
     * also stop drawing that object.
     * @param gameObject The actor to remove from the scene.
     */
    void removeFromScene(GameObject gameObject);

    /**
     * Removes an actor from a scene. If that scene is active, it should
     * also stop drawing that object.
     * @param actor The actor to remove from the scene.
     */
    void removeFromScene(GLEventListener actor);

    /**
     * Adds all the actors in the scene to be drawn.
     */
    void startScene();

    /**
     * Removes all the actors in the scene.
     */
    void endScene();


    List<GameObject> getGameObjects();
}
