using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public string newLevel = "MainMenu";

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene (newLevel);
        }
    }
}
