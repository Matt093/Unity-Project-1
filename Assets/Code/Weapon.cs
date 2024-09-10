using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : collidable
{
    // damge struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // upgrade 
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // swing 
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastswing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Time.time - lastswing > cooldown)
            {
                lastswing = Time.time;
                swing();
            }
        }
    }

    protected override void OnCollde(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "player")
                return;
            // damge object send it to emeny we hit 
            damage dmg = new damage
            {
                damageamount = damagePoint,
                origin = transform.position,
                pushforce = pushForce,
            };


            coll.SendMessage("ReceiveDamage", dmg);
            
        }
    }

    private void swing()
    {
        anim.SetTrigger("Swing");
    }

}
