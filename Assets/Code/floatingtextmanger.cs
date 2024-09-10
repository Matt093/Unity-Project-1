using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class floatingtextmanger : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<floatingtext> floatingtexts = new List<floatingtext>();

    private void Update()
    {
        foreach (floatingtext txt in floatingtexts)
            txt.UpdateFloatingText();
    }

    public void show(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingtext ftxt = GetFloatingtext();

        ftxt.txt.text = msg;
        ftxt.txt.fontSize = fontsize;
        ftxt.txt.color = color;

        ftxt.go.transform.position = Camera.main.WorldToScreenPoint(position); //world to screen space
        ftxt.motion = motion;
        ftxt.duration = duration;

        ftxt.show();
    }

    private floatingtext GetFloatingtext()
    {
        floatingtext txt = floatingtexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new floatingtext();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TMP_Text>();

            floatingtexts.Add(txt);
        }

        return txt;

    }
}
