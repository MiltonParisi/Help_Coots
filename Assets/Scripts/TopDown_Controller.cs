using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Controller : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

    [Header("Animation")]
    public List<Sprite> nSprites;
    public List<Sprite> eSprites;
    public List<Sprite> sSprites;
    public List<Sprite> sidleSprites;
    public List<Sprite> nidleSprites;
    public List<Sprite> eidleSprites;

    float idleTime;

    [Header("Speed")]
    public float walkSpeed;
    public float frameRate;

    [Header("Input")]
    public Vector2 direction;

    public Vector2 lastMoveDirection;

    private void Start()
    {
        lastMoveDirection = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        //get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //set walkspeed based on direction
        body.velocity = direction * walkSpeed;

        //handle direction
        HandleSpriteFlip();

        SetSprite();

    }

    void SetSprite()
    {
        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {//holding a direction
            int frameIndex = (int)(Time.time * frameRate) % directionSprites.Count;
            spriteRenderer.sprite = directionSprites[frameIndex];
            //lastMoveDirection = direction; // update last move direction
        }
        else
        {//holding nothing
            idleTime = Time.time;
        }
    }



    void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;
        //up
        if (direction.y > 0)
        {
            lastMoveDirection = Vector2.up;
            if (Mathf.Abs(direction.x) > 0)//right or left
            {
                selectedSprites = eSprites;
                boxCollider.size = new Vector2(0.1126366f, 0.05460986f);
                //boxCollider.offset = new Vector2(-0.01043533f, -0.01989487f);
            }
            else //neutral up
            {
                selectedSprites = nSprites;
                boxCollider.size = new Vector2(0.0508128f, 0.07847166f);
                //boxCollider.offset = new Vector2(-0.005602304f, -0.01457144f);

            }
        }
        else if (direction.y < 0) //down
        {
            lastMoveDirection = Vector2.down;
            if (Mathf.Abs(direction.x) > 0)//right or left
            {
                selectedSprites = eSprites;
                boxCollider.size = new Vector2(0.1126366f, 0.05460986f);
                //boxCollider.offset = new Vector2(-0.01043533f, -0.01989487f);
            }
            else //neutral down
            {
                selectedSprites = sSprites;
                boxCollider.size = new Vector2(0.0508128f, 0.07847166f);
                //boxCollider.offset = new Vector2(0.004701667f, -0.01457144f);
            }
        }
        else if (Mathf.Abs(direction.x) > 0)//right or left
        {
            lastMoveDirection = Vector2.right;

            selectedSprites = eSprites;
            boxCollider.size = new Vector2(0.1126366f, 0.05460986f);
            //boxCollider.offset = new Vector2(-0.01043533f, -0.01989487f);
        }
        else if (direction.y == 0 && direction.x == 0)
        {
            if (lastMoveDirection == Vector2.up)
            {
                selectedSprites = nidleSprites;
            }
            else if (lastMoveDirection == Vector2.down)
            {
                selectedSprites = sidleSprites;
            }
            else if (lastMoveDirection == Vector2.right)
            {
                selectedSprites = eidleSprites;
            }
        }

        return selectedSprites;
    }
}
