using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;
    [SerializeField] private GameObject objectToActivate;

    public void TransitionToNextPanel()
    {
        objectToDeactivate.SetActive(false);
        objectToActivate.SetActive(true);
    }
}
