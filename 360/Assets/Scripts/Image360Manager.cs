using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Purchasing;
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

    [SerializeField] public AudioSource source1;
    
    AudioClip[][] tableauAudios = new AudioClip[4][];
    public AudioClip[] RandonneeAudio;
    public AudioClip[] MerAudio;
    public AudioClip[] MondeAudio;
    public AudioClip[] UrbainAudio;

    [SerializeField] public AudioSource source2;
    AudioClip[][] GuidetableauAudios = new AudioClip[4][];
    public AudioClip[] GuideRandonneeAudio;
    public AudioClip[] GuideMerAudio;
    public AudioClip[] GuideMondeAudio;
    public AudioClip[] GuideUrbainAudio;


    public GameObject CanvaQuit;
    public GameObject CanvaPN;
    public float threshold = 0.5f;


    void Start()
    {
        tableauDeMateriaux[0] = Randonnee;
        tableauDeMateriaux[1] = Mer;
        tableauDeMateriaux[2] = Monde;
        tableauDeMateriaux[3] = Urbain;
        tableauAudios[0] = RandonneeAudio;
        tableauAudios[1] = MerAudio;
        tableauAudios[2] = MondeAudio;
        tableauAudios[3] = UrbainAudio;
        GuidetableauAudios[0] = GuideRandonneeAudio;
        GuidetableauAudios[1] = GuideMerAudio;
        GuidetableauAudios[2] = GuideMondeAudio;
        GuidetableauAudios[3] = GuideUrbainAudio;


        idxType = PlayerPrefs.GetInt("Type");       //0 = Rando, 1 = Mer, 2 = Monde, 3 = Urbain

        if (PlayerPrefs.GetString("GuideLibre") == "Libre")
        {
            ChangeSkyboxIndex(0);
            CanvaPN.SetActive(true);
        }
        else if (PlayerPrefs.GetString("GuideLibre") == "Guide")
        {
            VisiteAuto();
        }
        //ChangeSkyboxIndex(0);
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
        JouerAudioGuide();
        RenderSettings.skybox = tableauDeMateriaux[idxType][index];
        if (index == tableauDeMateriaux[idxType].Length - 1)
        {
            CanvaQuit.SetActive(true);
        }
        StartCoroutine(CoroutineWait());
    }

    public void ChangeSkyboxIndex(int idx)
    {
        JouerAudioAleatoire();
        print(idx);
        RenderSettings.skybox = tableauDeMateriaux[idxType][idx];
        if(idx == tableauDeMateriaux[idxType].Length - 1)
        {
            CanvaQuit.SetActive(true);
        }
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

    public void ChangeSkyboxBTGonext()
    {
        IndexPlus();
        ChangeSkyboxIndex(index);
    }

    public void ChangeSkyboxBTGoprev()
    {
        IndexMoins();
        ChangeSkyboxIndex(index);
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

        if(source1.clip != null)
        {
            while (nouveauClip.name == source1.clip.name)
            {
                nouveauClip = tableauSelectionne[Random.Range(0, tableauSelectionne.Length)];
            }
        }

        if(idxType == 1)
        {
            source1.volume = 0.5f;
        }
        source1.clip = nouveauClip;
        source1.Play();
    }

    private void JouerAudioGuide()
    {
        if (GuidetableauAudios[idxType][index] != null)
        {
            print("heehee");
            source2.clip = GuidetableauAudios[idxType][index];
            source2.Play();
        }
    }
}
