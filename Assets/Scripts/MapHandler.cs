using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapHandler : MonoBehaviour
{
    public GameObject MonitorView;
    private Scene LoadedScene;
    // Start is called before the first frame update
    void Start()
    {
        // MonitorView = GameObject.Find("MonitorView");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMap(){
        gameObject.SetActive(true);
        MonitorView.SetActive(false);
        PlayerMovement.moveable = false;
        
    }

    public void CloseMap(){
        gameObject.SetActive(false);
        PlayerMovement.moveable = true;
        SceneManager.UnloadSceneAsync(LoadedScene);
    }

    public void CloseMonitor(){
        MonitorView.SetActive(false);
        SceneManager.UnloadSceneAsync(LoadedScene);
    }
    public void OpenChemLab(){
        MonitorView.SetActive(true);
        StartCoroutine(LoadYourAsyncScene("ChemLab"));        
    }

    public void OpenBioLab(){
        MonitorView.SetActive(true);
        StartCoroutine(LoadYourAsyncScene("BioLab"));   
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        LoadedScene = SceneManager.GetSceneByName(sceneName);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        LoadedScene = SceneManager.GetSceneByName(sceneName);
        
        MonitorView.GetComponentInChildren<RawImage>().texture = Resources.Load<RenderTexture>("Textures/" + sceneName + "Scene");
        yield return asyncLoad;
    }
}
