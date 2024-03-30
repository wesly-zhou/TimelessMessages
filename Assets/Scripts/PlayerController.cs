using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject TimeLeapVFX;
    private Material material;
    private SpriteRenderer spriteRenderer;
    public Camera Maincamera;
    private bool startTransition1 = false; 
    private bool startTransition2 = false; 

    private float transitionTime  = 0;
    public float duration = 1f; 
    private float t;
    public float t1;
    public float t2;
    public float t3;
    public float speed1;
    public float speed2;
    // Start is called before the first frame update
    void Start()
    {
        material = TimeLeapVFX.GetComponent<SpriteRenderer>().material;
        spriteRenderer = TimeLeapVFX.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {   
            
            startTransition1 = true;
            Vector3 position = Maincamera.transform.position;
            position.z = 0;
            TimeLeapVFX.transform.position = position;
            TimeLeapVFX.SetActive(true);
            // StartCoroutine(TimeLeap());
            
        }
        if (startTransition1){
            transitionTime += Time.deltaTime;
            float lerpFactor = transitionTime / duration;
            Color newColor = Color.Lerp(Color.white, Color.black, lerpFactor);
            float a = 1;
            a = Mathf.Lerp(1, 20, lerpFactor);
            material.SetFloat("_a", a);
            TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
            if (lerpFactor >= 1.0f)
            {
                startTransition1 = false;

            }
        }

        // if (Input.GetKeyDown(KeyCode.J))
        // {   
            
        //     startTransition2 = true;
        //     Vector3 position = Maincamera.transform.position;
        //     position.z = 0;
        //     TimeLeapVFX.transform.position = position;
        //     TimeLeapVFX.SetActive(true);
        //     // StartCoroutine(TimeLeap());
            
        // }
        // if (startTransition2){
        //     transitionTime += Time.deltaTime;
        //     float lerpFactor = transitionTime / duration;
        //     Color newColor = Color.Lerp(Color.black, Color.white, lerpFactor);
        //     float a = 20;
        //     a = Mathf.Lerp(20, 1, lerpFactor);
        //     material.SetFloat("_a", a);
        //     TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
        //     if (lerpFactor >= 1.0f)
        //     {
        //         startTransition2 = false;
        //         TimeLeapVFX.SetActive(false);

        //     }
        // }



    }

    private IEnumerator TimeLeap()
    {
        
        float a = 1;
        t = Time.time;
        a = Mathf.Lerp(1, 20, t / 200f);
        material.SetFloat("_a", a);
        yield return null;

        // t = 0;
        // while (t < t1)
        // {
            
        //     material.SetFloat("_a", a);
        //     yield return null;
        // }
    }
}
