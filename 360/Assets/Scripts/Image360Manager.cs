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

    void Start()
    {
        tableauDeMateriaux[0] = Randonnee;
        tableauDeMateriaux[1] = Mer;
        tableauDeMateriaux[2] = Monde;
        if (PlayerPrefs.GetString("GuideLibre")=="Libre")
        {
            //Do visite libre
        }
        else if (PlayerPrefs.GetString("GuideLibre") == "Guide")
        {
            //Do visite guidee
        }

        idxType = PlayerPrefs.GetInt("Type");       //0 = Rando, 1 = Mer, 2 = Monde
        if(idxType == 0)
        {
            //Lancement Rando
        }
        else if (idxType == 1)
        {
            //Lancement Mer
        }
        else if (idxType == 2)
        {
            //Lancement Monde
        }
        //print(tableauDeMateriaux[0][0].name);

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
}
