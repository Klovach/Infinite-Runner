using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject Panel;

    public void Start()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    public void Toggle()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
    