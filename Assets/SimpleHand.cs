using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHand : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lineRenderer !=null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 2);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
                lineRenderer.SetPosition(1, hit.point);
        }   
    }
}
