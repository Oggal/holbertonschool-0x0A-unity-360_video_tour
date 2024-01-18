using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangeController : MonoBehaviour
{
    //list of empty objects to hold area transition buttons
    public GameObject[] areas;
    int currentIndex = 0;

    public void Start()
    {
        ClearSelection();
    }

    public void LoadArea(int index)
    {
        if (index < 0 || index >= areas.Length)
            return;
        ClearSelection();
        areas[index].SetActive(true);
        currentIndex = index;
    }

    public void ClearSelection()
    {
        foreach(GameObject area in areas)
        {
            area.SetActive(false);
        }
    }
}
