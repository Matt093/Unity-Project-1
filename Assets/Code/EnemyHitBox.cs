using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : collidable
{
    // Damage
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollde(Collider2D coll)
    {
      if(coll.tag == "Fighter" && coll.name == "player")
        {
            // damg object 
            damage dmg = new damage
            {
                damageamount = damage,
                origin = transform.position,
                pushforce = pushForce,
            };


            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
