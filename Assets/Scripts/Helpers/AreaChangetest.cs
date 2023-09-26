using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangetest : MonoBehaviour
{
    public SphereController sphere;

#if UNITY_EDITOR
    // OnGUI is called for rendering and handling GUI events.
    void OnGUI()
    {

        if(GUILayout.Button("Reload Area"))
        {
            sphere.StartSceneChange(-1);
        }
        for(int i = 0; i < sphere.clips.Length; i++)
        {
            if(GUILayout.Button("Load Area " + sphere.clips[i].name))
            {
                sphere.StartSceneChange(i);
            }
        }
        
    }
#endif

}
