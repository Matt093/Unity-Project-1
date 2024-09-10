using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanger : MonoBehaviour
{
    public static Gamemanger instance;
    private void Awake()
    {
        if(Gamemanger.instance != null)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }


    //ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;


    //References
    public Player player;

    // public weapon
    public floatingtextmanger floatingtextmanger;

    //logic 
    public int money;
    public int experience;

    // floating text
    public void ShowText(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingtextmanger.show(msg, fontsize, color, position, motion, duration);
    }

    //save state
    public void savestate()
    {
        Debug.Log("savestate");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        Debug.Log("loadstate");
    }
}
