using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DisplayCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] GameObject pickupParent;
    public int numberofPickup;
   
    int count;

 
    private void Start()
    {
        count = 0;
        numberofPickup = pickupParent.transform.childCount;
    }
    

    // Update is called once per frame
    void Update()
    {
        DisplayCountText(); 
    }

    public int GetCount()
    {
        return count;
    }

   
    public void IncreaseCount()
    {
        count++;
    }

    void DisplayCountText()
    {
        countText.text = "Left Pickup: " + (numberofPickup - count).ToString();
    }



}
