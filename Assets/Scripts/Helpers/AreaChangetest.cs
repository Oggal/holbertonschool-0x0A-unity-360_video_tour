using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangetest : MonoBehaviour
{
    public SphereController sphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

#if UNITY_EDITOR
    // OnGUI is called for rendering and handling GUI events.
    void OnGUI()
    {

        if(GUILayout.Button("Reload Area"))
        {
            sphere.StartSceneChange(sphere.currentIndex);
        }
        if(GUILayout.Button("Cube"))
        {
            Debug.Log("Cube");
        }
        if(GUILayout.Button("Living Room"))
        {
            Debug.Log("Living Room");
        }
        if(GUILayout.Button("Mezinene"))
        {
            Debug.Log("Mezinene");
        }
        if(GUILayout.Button("Cantiena"))
        {
            Debug.Log("Cantiena");
        }
    }
#endif

    // Update is called once per frame
    void Update()
    {
        
    }
}
