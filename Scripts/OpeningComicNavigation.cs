using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningComicNavigation : MonoBehaviour {
//this script goes onto the MainCamera in a scene with a series of comic panels

        public string nextScene = "ChemLab";
        public GameObject[] panels;
        private int panelsLength;
        public int currentPanel = 0;
        private Vector3 newPos;
        private float camSpeed = 4f;

        void Start(){
                panelsLength = panels.Length;
                Vector3 initialPos = panels[0].transform.position;
                transform.position = new Vector3 (initialPos.x, initialPos.y, transform.position.z);
        }

        void FixedUpdate () {
                Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)newPos, camSpeed * Time.fixedDeltaTime);
                transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
        }

        public void PanelNext(){
                if (currentPanel < (panelsLength - 1)){
                        currentPanel ++;
                        newPos = panels[currentPanel].transform.position;
                }
                else {
                        SceneManager.LoadScene(nextScene);
                }
        }

}