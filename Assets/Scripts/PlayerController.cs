using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject TimeLeapVFX;
    public Material material;
    private SpriteRenderer spriteRenderer;
    public Camera Maincamera;
    private static Vector3 MainCameraPosition;
    private bool startTransition1 = false; 
    private bool startTransition2 = false; 
    private static bool usedTimeLeap = false;
    private float transitionTime;
    public float duration = 1f; 
    public static bool operatable = true;
    // private float t;
    // public float t1;
    // public float t2;
    // public float t3;
    // public float speed1;
    // public float speed2;
    private static bool setupTime = true;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        // transitionTime = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // PlayerMovement.moveable = true;
        // setupTime = true;
        TimeLeapVFX = GameObject.FindGameObjectWithTag("TimeLeapVFX");
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transitionTime = 0;
        material = TimeLeapVFX.GetComponent<SpriteRenderer>().material;
        spriteRenderer = TimeLeapVFX.GetComponent<SpriteRenderer>();
        if (usedTimeLeap)
        {
           // Start Distortion when jump to the new scene
        startTransition2 = true;
        Vector3 position = MainCameraPosition;
        // print(position);
        position.z = 0;
        TimeLeapVFX.transform.position = position;
        // TimeLeapVFX.GetComponent<SpriteRenderer>().color = Color.black;
        TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = true; 
        }
        
    }
    void Start()
    {
        // TimeLeapVFX = GameObject.FindGameObjectWithTag("TimeLeapVFX");
        // Maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transitionTime = 0;
        material = TimeLeapVFX.GetComponent<SpriteRenderer>().material;
        spriteRenderer = TimeLeapVFX.GetComponent<SpriteRenderer>();
    }
    public void OnbuttonClick(){
        if (setupTime)
        {   
            print("Start1: " + startTransition1);
            print("Start2: " + startTransition2);
        
            setupTime = false;
            transitionTime = 0;
            GetComponent<Animator>().SetInteger("direction", 3);
            PlayerMovement.moveable = false;
            print("player moveable: " + PlayerMovement.moveable);
            usedTimeLeap = true;
            startTransition1 = true;
            Vector3 position = Maincamera.transform.position;
            MainCameraPosition = position;
            position.z = 0;
            TimeLeapVFX.transform.position = position;
            TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(SwitchScene());
            // transitionTime = 0;
        }
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && setupTime)
        {   
            print("Start1: " + startTransition1);
            print("Start2: " + startTransition2);
        
            setupTime = false;
            transitionTime = 0;
            GetComponent<Animator>().SetInteger("direction", 3);
            PlayerMovement.moveable = false;
            print("player moveable: " + PlayerMovement.moveable);
            usedTimeLeap = true;
            startTransition1 = true;
            Vector3 position = Maincamera.transform.position;
            MainCameraPosition = position;
            position.z = 0;
            TimeLeapVFX.transform.position = position;
            TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(SwitchScene());
            // transitionTime = 0;
        }

        if (startTransition1){
            transitionTime += Time.deltaTime;
            float lerpFactor = transitionTime / duration;
            float nonlinearFactor = lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor;
            // print(lerpFactor);
            Color newColor = Color.Lerp(Color.white, Color.black, lerpFactor * lerpFactor);
            // float a = 1;
            float a = Mathf.Lerp(1, 20, nonlinearFactor);
            material.SetFloat("_a", a);
            TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
            if (lerpFactor >= 1.0f)
            {
                startTransition1 = false;
                material.SetFloat("_a", 1);
            }
        }

        if (startTransition2 && usedTimeLeap){
            PlayerMovement.moveable = false;
            StartCoroutine(Waiting());
            transitionTime += Time.deltaTime;
            float lerpFactor = transitionTime / duration;
            float nonlinearFactor = lerpFactor * lerpFactor  ;
            float a = Mathf.Lerp(-20, 1, nonlinearFactor);
            material.SetFloat("_a", a);
            Color newColor = Color.Lerp(Color.black, Color.white, lerpFactor * lerpFactor * lerpFactor);
            // float a = 1;
            
            TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
            if (lerpFactor >= 1.0f)
            {
                startTransition2 = false;
                TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = false;
                setupTime = true;
                PlayerMovement.moveable = true;
                print("now you can move");
            }
        }
    }

    private void TimeTravel()
    {
        if (setupTime)
        {   
            print("Start1: " + startTransition1);
            print("Start2: " + startTransition2);
        
            setupTime = false;
            transitionTime = 0;
            GetComponent<Animator>().SetInteger("direction", 3);
            PlayerMovement.moveable = false;
            print("player moveable: " + PlayerMovement.moveable);
            usedTimeLeap = true;
            startTransition1 = true;
            Vector3 position = Maincamera.transform.position;
            MainCameraPosition = position;
            position.z = 0;
            TimeLeapVFX.transform.position = position;
            TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(SwitchScene());
            // transitionTime = 0;
        }

        if (startTransition1){
            transitionTime += Time.deltaTime;
            float lerpFactor = transitionTime / duration;
            float nonlinearFactor = lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor * lerpFactor;
            // print(lerpFactor);
            Color newColor = Color.Lerp(Color.white, Color.black, lerpFactor * lerpFactor);
            // float a = 1;
            float a = Mathf.Lerp(1, 20, nonlinearFactor);
            material.SetFloat("_a", a);
            TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
            if (lerpFactor >= 1.0f)
            {
                startTransition1 = false;
                material.SetFloat("_a", 1);
            }
        }

        if (startTransition2 && usedTimeLeap){
            PlayerMovement.moveable = false;
            StartCoroutine(Waiting());
            transitionTime += Time.deltaTime;
            float lerpFactor = transitionTime / duration;
            float nonlinearFactor = lerpFactor * lerpFactor  ;
            float a = Mathf.Lerp(-20, 1, nonlinearFactor);
            material.SetFloat("_a", a);
            Color newColor = Color.Lerp(Color.black, Color.white, lerpFactor * lerpFactor * lerpFactor);
            // float a = 1;
            
            TimeLeapVFX.GetComponent<SpriteRenderer>().color = newColor;

        
            if (lerpFactor >= 1.0f)
            {
                startTransition2 = false;
                TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = false;
                setupTime = true;
                PlayerMovement.moveable = true;
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

    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2);

        if(SceneManager.GetActiveScene().name == "Lab")
        {
            SceneManager.LoadScene("TestLab");
            // setupTime = true;
        }
        else if(SceneManager.GetActiveScene().name == "TestLab")
        {
            SceneManager.LoadScene("Lab");
            // setupTime = true;
        }
        // yield return null;
    }

    private IEnumerator Waiting(){
        yield return new WaitForSeconds(2);
        
    }
}
