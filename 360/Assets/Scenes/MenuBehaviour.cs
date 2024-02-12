using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviourScript : MonoBehaviour
{
    public Button _btnQuit;
    public Button _btnStartGuided;
    public Button _btnStartFree;

    // Start is called before the first frame update
    void Start()
    {
        _btnQuit.onClick.AddListener(quitBtn);
        _btnStartGuided.onClick.AddListener(startGuidedBtn);
        _btnStartFree.onClick.AddListener(startFreeBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void quitBtn()
    {
        Debug.Log("App quit called");
        Application.Quit();
    }

    void startGuidedBtn()
    {
        Debug.Log("Starting guided playthrough");
    }

    void startFreeBtn()
    {
        Debug.Log("Starting free playthrough");
    }

    public void SelectVisite(string visite)
    {
        PlayerPrefs.SetString("GuideLibre", visite);
    }

    public void SelectType(int type)
    {
        PlayerPrefs.SetInt("Type", type);
    }
}
