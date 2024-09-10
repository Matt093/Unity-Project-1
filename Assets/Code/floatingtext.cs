using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class floatingtext
{
    public bool active;
    public GameObject go;
    public TMP_Text txt;
    public Vector3 motion;
    public float duration;
    public float lastshown;

    public void show()
    {
        active = true;
        lastshown = Time.time;
        go.SetActive(active);
    }

    public void hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastshown > duration)
            hide();

        go.transform.position += motion * Time.deltaTime;

        
    }
}
