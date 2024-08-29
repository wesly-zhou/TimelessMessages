using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("Lab", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestLab"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
