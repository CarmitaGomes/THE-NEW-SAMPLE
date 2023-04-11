using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private Vector3 panelLocation;
    public float percentTheHold = 0.2f;
    public float easing = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.y - data.position.y;
        transform.position = panelLocation - new Vector3(0, difference, 0);

    }
    public void OnEndDrag(PointerEventData data)
    {
        panelLocation = transform.position;
        float percentage = (data.pressPosition.y - data.position.y) / Screen.height;

        if (Mathf.Abs(percentage) >= percentTheHold)
        {
            Vector3 newLocation = panelLocation;

            if(percentage > 0)
            {
                newLocation += new Vector3(0, -Screen.width, 0);
            } 
            else if (percentage < 0)
            {
                newLocation += new Vector3(0, Screen.height, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        } 
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
        IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
        {
            float t = 0f;
            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
                yield return null;
            }
        }
    }

}
