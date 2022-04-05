using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private StickmanCore.Status _dilivery;
    private StickmanCore.Status _live;

    public static Action DileveryIsOver;

    private void Awake()
    {
        _dilivery = StickmanCore.Status.DeliveringOrder;
        _live = StickmanCore.Status.Live;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Delivering"))
        {
            DileveryIsOver.Invoke();
            gameObject.tag = "Untagged";
            StickmanCore.LifeStatus = _live;
        }
    }
}
