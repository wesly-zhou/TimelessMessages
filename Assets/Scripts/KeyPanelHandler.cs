using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPanelHandler : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public TMPro.TextMeshProUGUI NoticeText;
    public Button YellowKeyHole;
    public Button RedKeyHole;
    public Button BlueKeyHole;
    public Button GreenKeyHole;
    public Button GrayKeyHole;

    private static bool yellowKey = false;
    private static bool redKey = false;
    private static bool blueKey = false;
    private static bool greenKey = false;
    private static bool grayKey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
        PlayerMovement.moveable = false;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerMovement.moveable = true;
        NoticeText.enabled = false;
    }

    public void CheckYellowKey()
    {
        StopAllCoroutines();
        if (InventoryManager.CheckItem("YellowKey"))
        {
            // Temp operation
            YellowKeyHole.enabled = false;
            YellowKeyHole.gameObject.SetActive(false);
            yellowKey = true;
        }
        else
        {
            NoticeText.text = "You don't have this key!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }

    public void CheckRedKey()
    {
        StopAllCoroutines();
        if (InventoryManager.CheckItem("RedKey"))
        {
            // Temp operation
            RedKeyHole.enabled = false;
            RedKeyHole.gameObject.SetActive(false);
            redKey = true;
        }
        else
        {
            NoticeText.text = "You don't have this key!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }

    public void CheckBlueKey()
    {
        StopAllCoroutines();
        if (InventoryManager.CheckItem("BlueKey"))
        {
            // Temp operation
            BlueKeyHole.enabled = false;
            BlueKeyHole.gameObject.SetActive(false);
            blueKey = true;
        }
        else
        {
            NoticeText.text = "You don't have this key!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }

    public void CheckGreenKey()
    {
        StopAllCoroutines();
        if (InventoryManager.CheckItem("GreenKey"))
        {
            // Temp operation
            GreenKeyHole.enabled = false;
            GreenKeyHole.gameObject.SetActive(false);
            greenKey = true;
        }
        else
        {
            NoticeText.text = "You don't have this key!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }

    public void CheckGrayKey()
    {
        StopAllCoroutines();
        if (InventoryManager.CheckItem("GrayKey"))
        {
            // Temp operation
            GrayKeyHole.enabled = false;
            GrayKeyHole.gameObject.SetActive(false);
            grayKey = true;
        }
        else
        {
            NoticeText.text = "You don't have this key!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }

    public void CheckAndOpenDoor(){
        StopAllCoroutines();
        if (yellowKey && redKey && blueKey && greenKey && grayKey)
        {
            // Open the door
            Debug.Log("Open the Final door!");
            GetComponentInParent<Animator>().SetBool("isOpen", true);
            FinalDoorController.isOpen = true;
            ClosePanel();
        }
        else
        {
            Debug.Log(yellowKey + " " + redKey + " " + blueKey + " " + greenKey + " " + grayKey);
            NoticeText.text = "You can't open the door now!";
            NoticeText.enabled = true;
            StartCoroutine(HideNoticeText());
        }
    }
    IEnumerator HideNoticeText()
    {   
        
        yield return new WaitForSeconds(2f);
        NoticeText.enabled = false;
    }
}
