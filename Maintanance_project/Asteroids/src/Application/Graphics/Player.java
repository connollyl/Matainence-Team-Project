package Application.Graphics;

import Application.GameController;
import Application.GameObject;
import Application.Main;

import java.awt.event.KeyEvent;
import java.awt.geom.Point2D;

/**
 * This class is for the players spaceship.
 */
public class Player extends GameObject {
    private boolean hasShot = false;
    private float xVelocity, yVelocity;
    private static final float ROTATION_OFFSET = 90f;
    private static final float SIZE = 0.28f;
    private static final float ACCELERATION = 0.0000005f;
    private static final float ROTATION_SPEED = 0.175f;
    private static final float TERM_VEL_DRAG = 0.98f;
    private static final float TERMINAL_VELOCITY = 0.0004f;

    private static GameController gameController;
    private static Point2D.Float [] points = {
            new Point2D.Float(0f * SIZE, 0.10f * SIZE),
            new Point2D.Float(-0.08f * SIZE, -0.08f * SIZE),
            new Point2D.Float(0f * SIZE, -.05f * SIZE),
            new Point2D.Float(0.08f * SIZE, -0.08f * SIZE)
    };



    public Player()
    {
        super(points);
        gameController = GameController.getInstance();
        position.x = position.y = rotation = xVelocity = yVelocity = 0;
        super.collisionLayerMask = ASTEROID_LAYER + ALIEN_SPACESHIP_LAYER + ALIEN_BULLET_LAYER;
        super.currentLayer = PLAYER_LAYER;
    }

    @Override
    protected void move()
    {
        if(gameController.isKeyPressed(KeyEvent.VK_W))
        {
            xVelocity += ACCELERATION * Main.getDeltaTimeMillis() * Math.cos(Math.toRadians(rotation + ROTATION_OFFSET));
            yVelocity += ACCELERATION * Main.getDeltaTimeMillis() * Math.sin(Math.toRadians(rotation + ROTATION_OFFSET));
        }
        if(gameController.isKeyPressed(KeyEvent.VK_D))
        {
            rotation += -ROTATION_SPEED * Main.getDeltaTimeMillis();
        }
        if(gameController.isKeyPressed(KeyEvent.VK_A))
        {
            rotation += ROTATION_SPEED * Main.getDeltaTimeMillis();
        }
        if(Math.sqrt((xVelocity * xVelocity) + (yVelocity * yVelocity)) > TERMINAL_VELOCITY)
        {
            xVelocity *= TERM_VEL_DRAG;
            yVelocity *= TERM_VEL_DRAG;
        }
        if(gameController.isKeyPressed(KeyEvent.VK_SPACE))
        {
            if(!hasShot)
            {
                GameObject bullet = new Bullet(position.x, position.y, rotation, xVelocity, yVelocity);
                gameController.getMainGame().addToScene(bullet);
                hasShot = true;
            }
        }
        else
            hasShot = false;

        position.x += xVelocity * Main.getDeltaTimeMillis();
        position.y += yVelocity * Main.getDeltaTimeMillis();
    }

    @Override
    protected void onImpact() {
        gameController.onDeath();
        gameController.getMainGame().removeFromScene(this);
    }

}
