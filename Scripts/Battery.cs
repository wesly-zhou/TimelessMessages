using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private TimeController timeController;

    private void Start() {
        timeController = GameObject.Find("GameHandler").GetComponent<TimeController>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            timeController.reduceCooldown();
            Destroy(gameObject);
        }
    }
}
