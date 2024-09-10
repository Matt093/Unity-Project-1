using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : collectable
{
    public Sprite emptychest;
    public int moneyAmount = 10;

    protected override void OnCollect()
    {
        
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptychest;
            // +10 money 
            Gamemanger.instance.ShowText("+" + moneyAmount + " money", 25,Color.yellow,transform.position,Vector3.up * 20, 1.0f);
        }

    }
}
