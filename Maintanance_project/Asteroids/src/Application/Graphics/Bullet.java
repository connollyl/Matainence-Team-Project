package Application.Graphics;

import Application.GameController;
import Application.GameObject;
import Application.Main;

import java.awt.geom.Point2D;

public class Bullet extends GameObject {

    private static final float VEL = 0.001f;
    private static final float ROTATION_OFFSET = 90f;
    private static final float LENGTH = 0.00725f;
    private static GameController gameController;
    private float xVel, yVel;
    private long spawnTime;
    private long bulletLifeSpan = 1500;


    public Bullet(float x, float y, float playerRotation, float playerXVelocity, float playerYVelocity){
        super(initBullet(x,y,playerRotation));
        super.currentLayer = BULLET_LAYER;
        super.collisionLayerMask = ASTEROID_LAYER + ALIEN_SPACESHIP_LAYER;
        gameController = GameController.getInstance();
        spawnTime = System.currentTimeMillis();
        position.x = x;
        position.y = y;
        xVel = (float)(VEL * Math.cos(Math.toRadians(playerRotation + ROTATION_OFFSET)) + playerXVelocity);
        yVel = (float)(VEL * Math.sin(Math.toRadians(playerRotation + ROTATION_OFFSET)) + playerYVelocity);
    }

    private static Point2D.Float[] initBullet(float x, float y, float playerRotation) {
        return new Point2D.Float[] {
                new Point2D.Float(0,0),
                new Point2D.Float((float)(LENGTH * Math.cos(Math.toRadians(playerRotation + ROTATION_OFFSET))) * 1.1f, (float)(LENGTH * Math.sin(Math.toRadians(playerRotation + ROTATION_OFFSET))) * 1.1f),
                new Point2D.Float(0,0)
        };
    }

    @Override
    protected void move() {
        if(System.currentTimeMillis() - spawnTime >= bulletLifeSpan){
            gameController.getMainGame().removeFromScene(this);
        }
        else{
            position.x += xVel * Main.getDeltaTimeMillis();
            position.y += yVel * Main.getDeltaTimeMillis();
        }
    }

    @Override
    protected void onImpact() {
        gameController.getMainGame().removeFromScene(this);
    }
}
