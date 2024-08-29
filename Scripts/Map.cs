using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject[] markers;
    private InventoryManager inventoryManager;
    public GameObject map;
    private Scene scene;
    // Start is called before the first frame update
    private void Start()
    {
        map.SetActive(false);
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        for (int i = 0; i < markers.Length; i++) {
            markers[i].SetActive(false);
        }
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++) {
            if (!inventoryManager.CheckItem(markers[i].name))
                markers[i].SetActive(true);
        }
        for (int i = 5; i < markers.Length; i++) {
            if (scene.name == markers[i].name)
                markers[i].SetActive(true);
        }
    }

    public void openMap() {
        map.SetActive(true);
    }

    public void closeMap() {
        map.SetActive(false);
    }
}
