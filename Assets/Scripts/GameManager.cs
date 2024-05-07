using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
// ------------------------------- Death Number -------------------------------- 
    // The Death nubmer of all the scene
    // public static int TestLab = 0;
    // public static int ChemLab = 0;
    // public static int SecurityRoom = 0;
    // public static int BioLab = 0;
    public static Dictionary<string, int> DeathNum = new Dictionary<string, int>(){
        {"TestLab", 0},
        {"TestChemLab", 0},
        {"ChemLab", 0},
        {"Corridor", 0},
        {"SecurityRoom", 0},
        {"BioLab", 0},
        {"PuzzleOne", 0},
        {"TestLaserLevel1", 0},
        {"TestLaserLevel2", 0},
        {"TestInvisibleRoad", 0},
        {"TestMap", 0},
        {"PuzzleTwo", 0},
        {"PuzzleThree", 0},
        {"PuzzleFour", 0},
        {"PuzzleFive", 0},
        {"TestFinalDoor", 0},
        {"TestFinalRoom", 0}
    };

// ------------------------------- Last Room --------------------------------
    // Store the information of last room
    public static string LastRoom = "ChemLab";
    
// ------------------------------- Scene Animation --------------------------------
    // Store the labe that if the scene have played the director
    // public static bool TestLab_anim = false;
    // public static bool ChemLab_anim = false;
    // public static bool TestChemLab_anim = false;

    // public static bool SecurityRoom_anim = false;
    // public static bool BioLab_anim = false;
    public static Dictionary<string, bool> SceneAnim = new Dictionary<string, bool>(){
        {"TestLab", false},
        {"TestChemLab", false},
        {"ChemLab", false},
        {"SecurityRoom", false},
        {"BioLab", false},
        {"PuzzleOne", false},
        {"TestMap", false},
        {"TestLaserLevel1", false},
        {"TestLaserLevel2", false},
        {"TestInvisibleRoad", false},
        {"PuzzleTwo", false},
        {"PuzzleThree", false},
        {"PuzzleFour", false},
        {"PuzzleFive", false},
        {"TestFinalDoor", false},
        {"TestFinalRoom", false}

    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
