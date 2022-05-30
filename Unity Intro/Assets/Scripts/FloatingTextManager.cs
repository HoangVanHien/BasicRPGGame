using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();//Get a new one
        
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);//Transfer world space to screen space so we can use the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);//search for the not active FloatingText and set for txt

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);//Make new with a prefab
            txt.go.transform.SetParent(textContainer.transform);//SetParent is just make it the parent of this
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);//Add new
        }

        return txt;
    }
}