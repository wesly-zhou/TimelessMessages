using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonitorController : MonoBehaviour
{
    public GameObject MoniorPanel;
    public Canvas UI;
    private bool isNearMonitor = false;
    private bool isMonitorOpen = false;
    
    // Start is called before the first frame update

    // void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     RemoveDuplicateObjects(scene);
    // }

    // void RemoveDuplicateObjects(Scene newScene)
    // {
    //     Scene activeScene = SceneManager.GetActiveScene();
    //     GameObject[] newSceneRootObjects = newScene.GetRootGameObjects();
    //     foreach (GameObject obj in newSceneRootObjects)
    //     {
    //         if (GameObject.Find(obj.name))
    //         {
    //             Destroy(obj);
    //         }
    //     }
    // }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isMonitorOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Player pressed Escape key to close the monitor");
            SceneManager.UnloadSceneAsync("BioLab");
            SceneManager.UnloadSceneAsync("ChemLab");
            SceneManager.UnloadSceneAsync("MeetingRoom");
            SceneManager.UnloadSceneAsync("LoungeRoom");
            MoniorPanel.SetActive(false);
            isMonitorOpen = false;
            PlayerMovement.moveable = true;
            // UI.enabled = true;
            UI.gameObject.SetActive(true);
        }
        if(isNearMonitor && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player pressed E key near the monitor");
            StartCoroutine(LoadAsyncScene());
            // SceneManager.LoadSceneAsync("BioLab", LoadSceneMode.Additive);
            MoniorPanel.SetActive(true);
            isMonitorOpen = true;
            PlayerMovement.moveable = false;
            GameObject.FindGameObjectWithTag("UI").SetActive(false);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the monitor trigger zone");
            isNearMonitor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the monitor trigger zone");
            isNearMonitor = false;
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BioLab", LoadSceneMode.Additive);
        AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync("ChemLab", LoadSceneMode.Additive);
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("MeetingRoom", LoadSceneMode.Additive);
        AsyncOperation asyncLoad3 = SceneManager.LoadSceneAsync("LoungeRoom", LoadSceneMode.Additive);

        while (!asyncLoad.isDone || !asyncLoad1.isDone || !asyncLoad2.isDone || !asyncLoad3.isDone)
        {
            yield return null;
        }
        OnSceneLoaded(scene: SceneManager.GetSceneByName("SecurityRoom"), mode: LoadSceneMode.Additive);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] UICanvas = GameObject.FindGameObjectsWithTag("UI");
        Debug.Log("UI Canvas: " + UICanvas.Length);
        foreach (GameObject obj in UICanvas)
        {
            obj.SetActive(false);
        }
        // RemoveDuplicateObjects(scene);
    }

    void RemoveDuplicateObjects(Scene newScene)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        GameObject[] newSceneRootObjects = newScene.GetRootGameObjects();

        foreach (GameObject obj in newSceneRootObjects)
        {
            if (GameObject.Find(obj.name))
            {
                Destroy(obj);
            }
        }
    }
}
