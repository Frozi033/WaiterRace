using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private StickmanCore.Status _dilivery;

    public static Action DileveryIsOver;

    private void Start()
    {
        _dilivery = StickmanCore.Status.DeliveringOrder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Delivering"))
        {
            DileveryIsOver.Invoke();
            gameObject.tag = "Untagged";
        }
    }
}
