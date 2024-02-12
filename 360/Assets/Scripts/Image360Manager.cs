using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Image360Manager : MonoBehaviour
{
    Material[][] tableauDeMateriaux = new Material[4][];
    public Material[] Randonnee;
    public Material[] Mer;
    public Material[] Monde;
    public Material[] Urbain;
    private int index = 0;
    private int idxType = 0;

    private AudioSource source;
    public AudioClip[] RandonneeAudio;
    public AudioClip[] MerAudio;
    public AudioClip[] MondeAudio;
    public AudioClip[] UrbainAudio;

    AudioClip[][] tableauAudios = new AudioClip[4][];

    public float threshold = 0.5f;


    void Start()
    {
        source = GetComponent<AudioSource>();
        tableauDeMateriaux[0] = Randonnee;
        tableauDeMateriaux[1] = Mer;
        tableauDeMateriaux[2] = Monde;
        tableauDeMateriaux[3] = Urbain;
        tableauAudios[0] = RandonneeAudio;
        tableauAudios[1] = MerAudio;
        tableauAudios[2] = MondeAudio;
        tableauAudios[2] = UrbainAudio;


        //idxType = PlayerPrefs.GetInt("Type");       //0 = Rando, 1 = Mer, 2 = Monde, 3 = Urbain
        idxType = 1; //debug
        
        //print(tableauDeMateriaux[0][0].name);

        if (PlayerPrefs.GetString("GuideLibre") == "Libre")
        {
            ChangeSkyboxIndex(0);
        }
        else if (PlayerPrefs.GetString("GuideLibre") == "Guide")
        {
            VisiteAuto();
        }
        
    }

    void Update()
    {
        /*float horizontalInput = Input.GetAxis("Horizontal");
        print(horizontalInput);
        if (horizontalInput < -threshold)
        {
            print("goleft");
            IndexMoins();
            ChangeSkyboxIndex(index);
        }
        else if (horizontalInput > threshold)
        {
            IndexPlus();
            ChangeSkyboxIndex(index);
        }*/
    }

    public void VisiteAuto()
    {
        print("Start");
        ChangeSkyboxAuto();
    }

    private void ChangeSkyboxAuto()
    {
        JouerAudioAleatoire();
        RenderSettings.skybox = tableauDeMateriaux[idxType][index];
        StartCoroutine(CoroutineWait());
    }

    public void ChangeSkyboxIndex(int idx)
    {
        JouerAudioAleatoire();
        RenderSettings.skybox = tableauDeMateriaux[idxType][idx];
    }

    public void IndexPlus()
    {
        if(index< tableauDeMateriaux[idxType].Length - 1)
        {
            index++;
        }
        
    }

    public void IndexMoins()
    {
        if (index > 0)
        {
            index--;
        }
      
    }

    IEnumerator CoroutineWait()
    {
        yield return new WaitForSeconds(20f);       //Attente de X secondes
        if (index < tableauDeMateriaux[idxType].Length-1)
        {
            index++;
            ChangeSkyboxAuto();
        }
    }

    private void JouerAudioAleatoire()
    {

        AudioClip[] tableauSelectionne = tableauAudios[idxType];
        AudioClip nouveauClip = tableauSelectionne[Random.Range(0, tableauSelectionne.Length)];

        if(source.clip != null)
        {
            while (nouveauClip.name == source.clip.name)
            {
                nouveauClip = tableauSelectionne[Random.Range(0, tableauSelectionne.Length)];
            }
        }

        source.clip = nouveauClip;
        source.Play();
    }
}
