using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollDismiss : MonoBehaviour
{
    public ScrollRect scrollRect; // reference to the scroll rect
    public GameObject panelToDismiss; // reference to the panel to dismiss

    private RectTransform cachedTransform;

    public float ThresholdToMove = 5.0f;
    private float initialPoint = 0.0f;

    private bool canTransition = false;

    private Vector3 cachedVelocity = Vector3.zero;

    private float stopLocation = -2400;

    private void Start()
    {
        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
        
        cachedTransform = panelToDismiss.GetComponent<RectTransform>();
        initialPoint = cachedTransform.position.y;
    }

    private void Update()
    {
        if(CanTransitionDown())
        {
            //Do Movement Code Downwards At The CachedVelocityRate
            
            //useless: scrollRect.velocity = cachedVelocity;

            if (cachedTransform.position.y < stopLocation )
            {
                scrollRect.velocity = Vector2.zero;
                panelToDismiss.SetActive(false);
            }
        }
    }

    private bool CanTransitionDown()
    {
        return canTransition;
    }

    private void OnScrollValueChanged(Vector2 value)
    {
        if (value.y <= 0.0f) // check if the scroll view is at the bottom
        {
            //panelToDismiss.SetActive(false); // hide the panel
        }

        float deltaFromStart = Mathf.Abs(initialPoint - panelToDismiss.GetComponent<RectTransform>().position.y);
        if (deltaFromStart > ThresholdToMove)
        {
            canTransition = true;
            cachedVelocity = scrollRect.velocity * Vector2.up;
        }


        Debug.Log($"Vector2Input: {value}, myPositionalDeltaFromStart: {deltaFromStart}  ");
    }

}
