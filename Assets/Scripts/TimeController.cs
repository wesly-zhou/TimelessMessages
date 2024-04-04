using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject pastMap;
    public GameObject presentMap;
    public static bool isPresent = true; 

    void Start()
    {
        if (isPresent) {
            presentMap.SetActive(true);
            pastMap.SetActive(false);
        }
        else {
            pastMap.SetActive(true);
            presentMap.SetActive(false);
        }
    }

    public void TimeTravel() {
        isPresent = !isPresent;
        if (isPresent) {
            presentMap.SetActive(true);
            pastMap.SetActive(false);
        }
        else {
            pastMap.SetActive(true);
            presentMap.SetActive(false);
        }
    }
}
