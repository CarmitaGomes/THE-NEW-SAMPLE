using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class StoriesController : MonoBehaviour
{
    public List<GameObject> stories;
    public GameObject panelToDismiss;

    private void Start()
    {
        if (stories == null)
        {
            Debug.LogError("CARMEN YOU NEED TO PUT GAMEOBJECTS IN THIS LIST.");
            return;
        }

    }

    public bool TryTransitionToNextStory()
    {
        if (!HasMoreStories())
        {
            Debug.LogError("CARMEN, YOU DONT HAVE ANY MORE STORIES TO CHANGE TO.");
            //stories[0].SetActive(false);
            return false;

        }

        stories[0].SetActive(false);
        stories.RemoveAt(0);

        if(stories.Count > 0)
            stories[0].SetActive(true);

        return true;
    }

    public bool HasMoreStories()
    {
        return stories.Count > 0;
    }

    public void OnTapGesture()
    {
        stories[0].SetActive(false);
        stories.RemoveAt(0);
        stories[0].SetActive(true);
    }
}
