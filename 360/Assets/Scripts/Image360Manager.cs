using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image360Manager : MonoBehaviour
{

    public Material[] Randonnee;
    public Material[] Mer;
    public Material[] Monde;
    private int index = 0;

    void Start()
    {
        ChangeSkyboxAuto();
    }

    void Update()
    {
        
    }

    private void ChangeSkyboxAuto()
    {
        RenderSettings.skybox = Randonnee[index];
    }

    private void ChangeSkyboxIndex(int idx)
    {
        RenderSettings.skybox = Randonnee[idx];
    }
}
