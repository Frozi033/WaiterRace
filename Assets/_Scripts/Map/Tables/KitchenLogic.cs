using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KitchenLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tables = new List<GameObject>();

    private int _index;
    private StickmanCore.Status _delivery;
    private StickmanCore.Status _live;

    public static Action<GameObject> DileveryAction;

    private void Awake()
    {
        _delivery = StickmanCore.Status.DeliveringOrder;
        _live = StickmanCore.Status.Live;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && StickmanCore.LifeStatus == _live)
        {
            _index = Random.Range(0, _tables.Count);
            _tables[_index].gameObject.tag = "Delivering";
            DileveryAction.Invoke(_tables[_index].gameObject);
            StickmanCore.LifeStatus = _delivery;
            //_myAnimator.SetBool("Delivery", true);
            //_tray.SetActive(true);
        }
        /*else if (other.CompareTag("Delivering") && StickmanCore.LifeStatus == _dilivery)
        {
            other.tag = "Untagged";
            StickmanCore.LifeStatus = _live;
            // _text.SetActive(true);
            // _tray.SetActive(false);
            // StartCoroutine(_timeToDelivering());
            // _myAnimator.SetBool("Delivery", false);
        }*/
    }
}
