using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxhitpoint = 10;
    public float pushrecoveryspeed = 0.2f;


    // immunity
    protected float immuntime = 1.0f;
    protected float lastimmune;

    //push
    protected Vector3 pushDirection;

    // all fights receviedmg and DIE
    protected virtual void ReceiveDamage(damage dmg)
    {
        if(Time.time - lastimmune > immuntime)
        {
            lastimmune = Time.time;
            hitpoint -= dmg.damageamount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushforce;

            Gamemanger.instance.ShowText(dmg.damageamount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
