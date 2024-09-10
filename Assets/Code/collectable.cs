using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : collidable
{
    //logic
    protected bool collected;

    protected override void OnCollde(Collider2D coll)
    {
        if (coll.name == "player")
            OnCollect();
    }


    protected virtual void OnCollect()
    {
        collected = true;
    }

}


