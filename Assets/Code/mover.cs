using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mover : fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit2D;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;


    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Updatemotor(Vector3 input)
    {
        //rest moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);


        //spawn sprite dir
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // add push 
        moveDelta += pushDirection;

        // reduce push force every frame by recovry speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushrecoveryspeed);


        //can we move null means yes
        hit2D = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));
        if (hit2D.collider == null)
        {
            //movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //can we move null means yes
        hit2D = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));
        if (hit2D.collider == null)
        {
            //movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
