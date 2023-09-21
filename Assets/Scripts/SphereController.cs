using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SphereController : MonoBehaviour
{
    public VideoClip[] clips = new VideoClip[4];
    public int currentIndex = 0;
    public float fadeInTime = 1.0f, fadeOutTime = 2.0f;
    
    public GameObject sphere;
    public GameObject screenFade;

    private VideoPlayer sphereCR;

    public void Start()
    {
        if (sphere == null)
            sphere = gameObject;
        sphereCR = sphere.GetComponent<VideoPlayer>();
    }

    public void LoadArea(int index)
    {
        if (index < 0 || index >= clips.Length)
            return;
        sphereCR.clip = clips[index];
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
            color.a += Time.deltaTime / fadeInTime;
            fade.color = color;
            yield return null;
        }
        //change video clips...
        LoadArea(index);
        while(!sphereCR.isPrepared)
            yield return null;
        //fade in
        while(color.a > 0)
        {
            
            color.a -= Time.deltaTime / fadeOutTime;
            fade.color = color;
            yield return null;
        }
        fade.enabled = false;
    }

    public void StartSceneChange(int index)
    {
        Debug.Log("StartSceneChange(index);");
        StartCoroutine(FadeInOut(index));
    }

}
