using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : mover
{
    //ex
    public int xpValue = 1;

    //logic
    public float triggerlength = 1;
    public float chaselength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playertransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playertransform = Gamemanger.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // is player in range 
        if(Vector3.Distance(playertransform.position,startingPosition)< chaselength)
        {
            if (Vector3.Distance(playertransform.position, startingPosition) < triggerlength)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    Updatemotor((playertransform.position - transform.position).normalized);
                }
            }
            else
            {
                Updatemotor(startingPosition - transform.position);
            }
        }
        else
        {
            Updatemotor(startingPosition - transform.position);
            chasing = false;
        }

        //check for overlap
        collidingWithPlayer = false;

        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "fighter" && hits[i].name == "player")
            {
                collidingWithPlayer = true;
            }

            //the array  is not cleaned up, so we do it ourself
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        Gamemanger.instance.experience += xpValue;
        Gamemanger.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
