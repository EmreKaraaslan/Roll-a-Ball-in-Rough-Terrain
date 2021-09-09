using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CollectPickup : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI countText;
    //int count;
    DisplayCount countIncrease;
    void Start()
    {
        countIncrease = FindObjectOfType<DisplayCount>();
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        countIncrease.IncreaseCount();
        Destroy(gameObject);
      
    }









}
