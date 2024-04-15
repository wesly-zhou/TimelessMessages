using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMoveBounded : MonoBehaviour {

       public Transform target; // the player
       public float smoothing = 0.6f; // how quickly camera moves to player
       public Vector2 minPosition; // X and Y values for lower left corner of play area
       public Vector2 maxPosition; // X and Y values for upper right corner
       public AnimationCurve curve;

       void Awake(){
              // DontDestroyOnLoad(gameObject);
              GameObject[] objs = GameObject.FindGameObjectsWithTag("MainCamera");
              if (objs.Length > 1)
              {
              Destroy(gameObject);
              }
              // target = GameObject.FindGameObjectWithTag("Player").transform;
       }
       
       void Start () {
             
             
              
       }
       void Update () {
              if(target == null){
                     target = GameObject.FindGameObjectWithTag("Player").transform;
              }
              if (transform.position != target.position){
                     Vector3 targPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                     targPos.x=Mathf.Clamp(targPos.x, minPosition.x, maxPosition.x);
                     targPos.y=Mathf.Clamp(targPos.y, minPosition.y, maxPosition.y);
                     transform.position = Vector3.Lerp(transform.position, targPos, curve.Evaluate(smoothing));
              }
       }
}