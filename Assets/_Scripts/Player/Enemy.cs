using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : StickmanCore
{
    [SerializeField] private Vector3 Position;
    [SerializeField] private float TableDistance = 1.9f;
    
    private NavMeshAgent _myAgent;
    private bool DiliveryCheck;

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _myAnimator = GetComponent<Animator>();
        _randomNumber = Random.Range(0, _emptyTables.Count);
        Position = _emptyTables[_randomNumber].gameObject.transform.position;
        _myAgent.SetDestination(Position);
        StartCoroutine(EnemyLoop());
        _myAnimator.SetBool("Delivery", true);
        MoveAnimationSpeed(0.2f);
    }

    private IEnumerator EnemyLoop()
    {
        WaitForSeconds c = new WaitForSeconds(0.5f);
        while (true)
        {
            if (Vector3.Distance(transform.position, Position) <= TableDistance)
            {
                Debug.Log("ssss");
                _randomNumber = Random.Range(0, _emptyTables.Count);
                Position = _emptyTables[_randomNumber].gameObject.transform.position;
                _myAgent.SetDestination(Position);
            }
           /* else if (Vector3.Distance(transform.position, Position) >= TableDistance)
            {
                MoveAnimationSpeed(0.2f);
            }*/
            yield return c;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.CompareTag("PlayerShop") && LifeStatus != Status.DeliveringOrder)
        {
            _randomNumber = Random.Range(0, _emptyTables.Count);
            _enteredTable = _emptyTables[_randomNumber];
            _enteredTable.tag = "Delivering";
            //_enteredTable.GetComponent<Transform>();
            //_enteredTable.transform.position = Table;
            LifeStatus = Status.DeliveringOrder;
            _myAnimator.SetBool("Delivery", true);
        }
        else if (other.CompareTag("Delivering") && LifeStatus == Status.DeliveringOrder)
        {
            other.tag = "Untagged";
            LifeStatus = Status.Live;
            _myAnimator.SetBool("Delivery", false);
        }
        else if (other.CompareTag("SpeedCoin") && _playerSpeed == 10f)
        {
            _playerSpeed = _playerSpeed * _speedBonus;
            //StartCoroutine(_timeSpeedBonus());
            Destroy(GameObject.FindGameObjectWithTag("SpeedCoin"));
        }*/
    }

    private void Update()
    {

        /*if (Input.GetMouseButtonDown(0))
        {

        }*/
    }
    
    /*private IEnumerator _timeSpeedBonus()
    {
        
        yield return new WaitForSeconds(3f);
        _playerSpeed = 10f;
    }*/
}
