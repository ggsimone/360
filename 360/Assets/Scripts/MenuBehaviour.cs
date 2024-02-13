using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviourScript : MonoBehaviour
{
    public Button _btnQuit;
    public Button _btnStartGuided;
    public Button _btnStartFree;

    // Start is called before the first frame update
    void Start()
    {
        /*_btnQuit.onClick.AddListener(quitBtn);
        _btnStartGuided.onClick.AddListener(startGuidedBtn);
        _btnStartFree.onClick.AddListener(startFreeBtn);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitBtn()
    {
        Debug.Log("App quit called");
        Application.Quit();
    }

    public void startGuidedBtn()
    {
        Debug.Log("Starting guided playthrough");
    }

    public void startFreeBtn()
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

    public void Hide(GameObject tohide)
    {
        tohide.SetActive(false);
    }
    public void Show(GameObject toshow)
    {
        toshow.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("360Scene");
    }

    public async void ChangeSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("360Scene");
    }
}
