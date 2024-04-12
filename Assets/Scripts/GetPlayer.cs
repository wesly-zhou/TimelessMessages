using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player  = GameObject.FindWithTag("Player");
        if(Player != null) print("Player Found");
        else print("Player Not Found");
        gameObject.GetComponent<Button>().onClick.AddListener(() => Player.GetComponent<PlayerControllerDelete>().OnbuttonClick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
