using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class HoverButton : MonoBehaviour
{

    public float selectTime = 1f;
    public float deselectTime = 0.1f;
    float hoverTime = 0f;
    bool selected = false;
    public UnityEvent OnClick, OnDeSelect;
    [SerializeField] Image fillImage;
    float deselect, select;

    public bool HoldButton = false; 

    // Start is called before the first frame update
    void Start()
    {
        deselect = 1f / deselectTime;
        select = 1f / selectTime;

    }

    void Update()
    {
        if(selected)
        {
            hoverTime += Time.deltaTime * select;
            if(hoverTime >= 1f)
            {
                OnClick.Invoke();
                if(!HoldButton)
                    hoverTime = 0f;
            }
        } else {
            hoverTime -= Time.deltaTime * deselect;
        }
        hoverTime = Mathf.Clamp01(hoverTime);
        if(fillImage != null)
        {
            fillImage.fillAmount = hoverTime;
        }
    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
        OnDeSelect.Invoke();
    }
}
