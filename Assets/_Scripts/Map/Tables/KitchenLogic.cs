using System;
using UnityEngine;

public class KitchenLogic : TableList
{
    private StickmanCore.Status _delivery;
    private StickmanCore.Status _live;

    public static Action<Vector3> DileveryAction;

    private void Awake()
    {
        _delivery = StickmanCore.Status.DeliveringOrder;
        _live = StickmanCore.Status.Live;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && StickmanCore.LifeStatus == _live)
        {
            DileveryAction.Invoke(GetTable(true));
        }
    }
}
