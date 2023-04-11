using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    [Header("Components")]
    public Image backGround;
    [Header("Colors")] 
    public Color newBackgroundColor;
    public Color oldBackgroundColor;
    private bool transitioning = false;
    private float colorTimer;
    [Range(0.001f, 0.01f)]
    public float step;


    // Start is called before the first frame update
    void Start()
    {
        oldBackgroundColor = backGround.color;
        changeBackground();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transitioning)
        {
             if (colorTimer <= 1)
            {
                fadeBackground();
            }
        }
    }

    public void changeBackground()
    {
        // backGround.color = newBackgroundColor;
        transitioning = true;
    }

    public void fadeBackground()
    {
        backGround.color = Color.Lerp(oldBackgroundColor, newBackgroundColor, colorTimer);
        colorTimer += step;
    }
}
