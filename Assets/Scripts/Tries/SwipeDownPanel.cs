using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDownPanel : MonoBehaviour
{
    public float dismissYPosition = -200f;
    public float swipeVelocityThreshold = 0.2f;
    public float swipeDistanceThreshold = 50f;
    public float swipeDeceleration = 0.2f;

    private RectTransform panelRect;
    private Vector2 panelPosition;
    private Vector2 panelVelocity;
    private Vector2 panelBoundaries;
    private bool isSwiping = false;
    private float swipeStartTime;

    void Start()
    {
        panelRect = GetComponent<RectTransform>();
        panelPosition = panelRect.anchoredPosition;
        panelVelocity = Vector2.zero;
        panelBoundaries = new Vector2(panelPosition.x, dismissYPosition);
    }

    void Update()
    {
        if (isSwiping)
        {
            Vector2 touchPosition = Input.mousePosition;
            Vector2 deltaPosition = touchPosition - panelPosition;
            Vector2 swipeDirection = deltaPosition.normalized;
            float swipeDistance = deltaPosition.magnitude;

            float timeElapsed = Time.time - swipeStartTime;
            float swipeVelocity = Mathf.Abs(deltaPosition.y) / timeElapsed;
            swipeVelocity = Mathf.SmoothStep(panelVelocity.y, swipeVelocity, swipeDeceleration);

            if (swipeDirection.y < 0f || swipeVelocity > swipeVelocityThreshold)
            {
                panelVelocity.y = swipeVelocity * swipeDirection.y;
                panelPosition.y += panelVelocity.y * Time.deltaTime;
                panelRect.anchoredPosition = panelPosition;

                if (panelPosition.y <= panelBoundaries.y)
                {
                    StartCoroutine(DismissPanel()); // animate the dismissal here
                    isSwiping = false;
                    return;
                }
            }
        }
        else
        {
            panelPosition = panelRect.anchoredPosition;
            panelVelocity = Vector2.zero;
        }
    }

    IEnumerator DismissPanel()
    {
        yield return new WaitForSeconds(0.5f); // add your preferred delay/framerate here
        Destroy(gameObject);
        // or setActive(false) to reuse the panel later
    }

    public void OnSwipeStart()
    {
        isSwiping = true;
        swipeStartTime = Time.time;
    }

    public void OnSwipeEnd()
    {
        isSwiping = false;
        panelVelocity = Vector2.zero;
    }

}
