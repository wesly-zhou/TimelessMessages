using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public GameObject pastMap;
    public GameObject presentMap;
    public static bool isPresent = true;
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
    private static bool setupTime = true;
    public GameObject Enemy;
    public TextMeshProUGUI timerText;
    public static float remainingTime = 1220;
    public Volume volume;

    public Image timerIcon;
    public Text cooldownText;
    public static float timerCooldown = 5f;
    private static bool onCooldown = false;
    private static float currentCooldown;

    //add
    public GameObject instruction;

    void Start()
    {
        timerIcon.fillAmount = 0;
        cooldownText.text = "";
        transitionTime = 0;
        material = TimeLeapVFX.GetComponent<SpriteRenderer>().material;
        spriteRenderer = TimeLeapVFX.GetComponent<SpriteRenderer>();

        
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (isPresent) {
            presentMap.SetActive(true);
            pastMap.SetActive(false);
            volume.enabled = false;

        }
        else {
            pastMap.SetActive(true);
            presentMap.SetActive(false);
            volume.enabled = true;
        }
    }

    public IEnumerator TimeTravel() 
    {
        yield return new WaitForSeconds(duration);
        isPresent = !isPresent;
        if (isPresent) {
            presentMap.SetActive(true);
            pastMap.SetActive(false);
            volume.enabled = false;

        }
        else {
            pastMap.SetActive(true);
            presentMap.SetActive(false);
            volume.enabled = true;
        }
        startTransition2 = true;
    }

    void Update() {
        if (isPresent && remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else if (isPresent && remainingTime < 0)
            remainingTime = 0;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        AbilityCooldown(ref currentCooldown, timerCooldown, ref onCooldown, timerIcon, cooldownText);

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
                transitionTime = 0;
            }
        }
        // When timeleap to a new scene 
        if (startTransition2 && usedTimeLeap){
            PlayerMovement.moveable = false;
            Debug.Log("Issue 3");
            // Set Enemy state
            if(Enemy != null){
                // Enemy.GetComponent<AIPath>().canMove = false;
                // Debug.Log("Enemy cannot move: " + Enemy.GetComponent<AIPath>().canMove);
                Enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            }
            
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
                Debug.Log("Issue get solved 3");
            //     if(Enemy != null){
            //     Enemy.GetComponent<AIPath>().canMove = true;
            // }
                if(Enemy != null) Enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                transitionTime = 0;
                print("now you can move");
            }
        }
    }


    private IEnumerator Waiting(){
        yield return new WaitForSeconds(duration);
        
    }

    public void OnbuttonClick() {
        

        if (setupTime && !onCooldown)
        {   
            print("Start1: " + startTransition1);
            print("Start2: " + startTransition2);
            onCooldown = true;
            currentCooldown = timerCooldown;
            setupTime = false;
            transitionTime = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetInteger("direction", 3);
            PlayerMovement.moveable = false;
            Debug.Log("Issue 4");
            print("player moveable: " + PlayerMovement.moveable);
            if(Enemy != null){
                Enemy.GetComponent<AIPath>().canMove = false;
                Enemy.GetComponentInChildren<Animator>().speed = 0;
            }
            usedTimeLeap = true;
            startTransition1 = true;
            Vector3 position = Maincamera.transform.position;
            MainCameraPosition = position;
            position.z = 0;
            TimeLeapVFX.transform.position = position;
            TimeLeapVFX.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(TimeTravel());
            // transitionTime = 0;
            if (instruction != null) {
                instruction.SetActive(false);
            } else {
                Debug.LogWarning("Instruction object not assigned in this scene.");
            }
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool onCooldown, Image skillImage, Text skillText) {
        if (onCooldown) {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0) {
                onCooldown = false;
                currentCooldown = 0f;
                if (skillImage != null) 
                    skillImage.fillAmount = 0f;
                if (skillText != null)
                    skillText.text = "";
            }
            else {
                if (skillImage != null)
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                if (skillText != null)
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
            }
        }
    }

    public void reduceCooldown() {
        currentCooldown -= 5;
    }
}
