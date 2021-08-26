using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Delivering").transform == enabled)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Delivering").transform);
        }
        else if (GameObject.FindGameObjectWithTag("Delivering").transform != enabled)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("PlayerShop").transform);
            Debug.Log("NiggA");
        }
    }
}
