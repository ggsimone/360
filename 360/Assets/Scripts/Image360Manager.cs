using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image360Manager : MonoBehaviour
{
    Material[][] tableauDeMateriaux = new Material[3][];
    public Material[] Randonnee;
    public Material[] Mer;
    public Material[] Monde;
    private int index = 0;
    private int idxType;

    private AudioSource source;
    public AudioClip[] RandonneeAudio;
    public AudioClip[] MerAudio;
    public AudioClip[] MondeAudio;

    AudioClip[][] tableauAudios = new AudioClip[3][];


    void Start()
    {
        source = GetComponent<AudioSource>();
        tableauDeMateriaux[0] = Randonnee;
        tableauDeMateriaux[1] = Mer;
        tableauDeMateriaux[2] = Monde;
        tableauAudios[0] = RandonneeAudio;
        tableauAudios[1] = MerAudio;
        tableauAudios[2] = MondeAudio;


        //idxType = PlayerPrefs.GetInt("Type");       //0 = Rando, 1 = Mer, 2 = Monde
        idxType = 0; //debug
        
        //print(tableauDeMateriaux[0][0].name);

        if (PlayerPrefs.GetString("GuideLibre") == "Libre")
        {
            ChangeSkyboxIndex(0);
        }
        else if (PlayerPrefs.GetString("GuideLibre") == "Guide")
        {
            VisiteAuto();
        }
        VisiteAuto();
    }

    void Update()
    {
        
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
        RenderSettings.skybox = tableauDeMateriaux[idxType][idx];
    }

    public void IndexPlus()
    {
        index++;
    }

    public void IndexMoins()
    {
        index--;
    }

    IEnumerator CoroutineWait()
    {
        print("Wait for seconds");
        print(index);
        yield return new WaitForSeconds(5f);       //Attente de X secondes
        if (index < tableauDeMateriaux[idxType].Length-1)
        {
            index++;
            ChangeSkyboxAuto();
        }
    }

    private void JouerAudioAleatoire()
    {

        // S�lectionnez un AudioClip al�atoire dans le tableau s�lectionn�
        AudioClip[] tableauSelectionne = tableauAudios[idxType];
        AudioClip nouveauClip = tableauSelectionne[Random.Range(0, tableauSelectionne.Length)];

        // V�rifiez si le nouveau clip est diff�rent du clip en cours de lecture
        if(source.clip != null)
        {
            while (nouveauClip.name == source.clip.name)
            {
                nouveauClip = tableauSelectionne[Random.Range(0, tableauSelectionne.Length)];
            }
        }
        print(nouveauClip.name);

        // Mettez � jour le clip en cours de lecture
        source.clip = nouveauClip;
        source.Play();
    }
}
