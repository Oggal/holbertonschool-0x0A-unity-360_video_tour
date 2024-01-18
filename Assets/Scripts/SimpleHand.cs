using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHand : MonoBehaviour
{
    [SerializeField]
    GameObject indicator;
    HoverButton selectedButon = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(indicator !=null)
        {
            indicator.transform.position = transform.position + transform.forward * 10f;
            RaycastHit hit;
            HoverButton hitButt = null;
        
            if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
                indicator.transform.position = hit.point;
                hitButt = hit.collider.GetComponent<HoverButton>();
            }

            if(hitButt != null && hitButt != selectedButon)
            {
                ClearSelection();
                selectedButon = hitButt;
                selectedButon.Select();
            }
            else
            {   
                if(hitButt == null)
                    ClearSelection();
            }
        }
    }

    void ClearSelection()
    {
        if(selectedButon != null)
        {
            selectedButon.Deselect();
            selectedButon = null;
        }
    }
}
