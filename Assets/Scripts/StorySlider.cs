using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySlider : MonoBehaviour
{

    private Slider slider;

    public float FillSpeed = 0.5f;

    private float targetProgress = 0;
    public StoriesController storiesController;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
        

        if (slider.value == targetProgress)
        {
            if(storiesController.TryTransitionToNextStory())
            { 
                slider.value = 0;
            }
        }

    }

    // Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }


}
