using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Void") {
            return;
        }
        else{
            GameManager.DeathNum[UnityEngine.SceneManagement.SceneManager.GetActiveScene().name]++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
