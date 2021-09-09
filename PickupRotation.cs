using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    [SerializeField] float rotation;

    // Update is called once per frame
    void Update()
    {
        RotatePickup();
    }

    void RotatePickup()
    {
        transform.Rotate(rotation* Time.deltaTime, rotation* Time.deltaTime, rotation* Time.deltaTime);
    }
}
