using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Delivering").transform == null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("PlayerShop").transform);
            //Debug.Log(GameObject.FindGameObjectWithTag("Delivering").transform);
        }
        else
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Delivering").transform);
        }
    }
}
