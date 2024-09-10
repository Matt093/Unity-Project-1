using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : collidable
{
    public string[] sceneNames;
    protected override void OnCollde(Collider2D coll)
    {
        
        if(coll.name == "player")
        {
            //teleport player 
            Gamemanger.instance.savestate();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
