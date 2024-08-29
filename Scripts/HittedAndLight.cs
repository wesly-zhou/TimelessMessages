using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HittedAndLight : MonoBehaviour
{
    private bool isHitted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(isHitted){
            GetComponentInChildren<Light2D>().enabled = true;
        }
        else{
            GetComponentInChildren<Light2D>().enabled = false;
        }
        isHitted = false;
    }

    public void Hitted(){
        
        isHitted = true;
        // Debug.Log("Hitted and the current state is " + isHitted);   
    }

    // public void LightOff(){
    //     GetComponentInChildren<Light2D>().enabled = false;
    //     isHitted = false;
    //     Debug.Log("Light off and the current state is " + isHitted);
    // }
    
}
