using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    public VideoClip[] clips = new VideoClip[4];
    public int currentIndex = 0;
    public float fadeTime = 1.0f;
    
    public GameObject sphere;
    public GameObject screenFade;

    private Renderer Myrenderer;

    public void Start()
    {
        if (sphere == null)
            sphere = gameObject;
        Myrenderer = sphere.GetComponent<Renderer>();
    }

    public void LoadArea(int index)
    {
        throw new NotImplementedException();
    }

    private IEnumerator FadeInOut(int index)
    {
        Image fade = screenFade.GetComponent<Image>();
        fade.enabled = true;
        Color color = Color.black;
        color.a = 0;
        //while not faded out yet...
        while(color.a < 1)
        {
            color.a += (Time.deltaTime / fadeTime);
            fade.color = color;
            yield return null;
        }
        //Once fadedout wait on extra frame.
        yield return null;
        //change video clips...
        Debug.Log("LoadArea(index);");
        //wait one extra frame.
        yield return null;
        //fade in
        while(color.a > 0)
        {
            
            color.a -= (Time.deltaTime / fadeTime);
            fade.color = color;
            yield return null;
        }
        fade.enabled = false;
        Debug.Log("END");
    }

    public void StartSceneChange(int index)
    {
        Debug.Log("StartSceneChange(index);");
        StartCoroutine(FadeInOut(index));
    }

}
