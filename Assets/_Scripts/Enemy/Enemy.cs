using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : StickmanCore
{
    private Vector3 Position;
    [SerializeField] private float TableDistance = 1.9f;
    [SerializeField] private List<GameObject> _tables = new List<GameObject>();
    
    private NavMeshAgent _myAgent;
    private bool DiliveryCheck;

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _myAnimator = GetComponent<Animator>(); 
        SetRandomTable();
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
                SetRandomTable();
            }
            yield return c;
        } 
    }

    private void SetRandomTable()
    {
        _randomNumber = Random.Range(0, _tables.Count);
        Position = _tables[_randomNumber].gameObject.transform.position;
        _myAgent.SetDestination(Position);
    }
    
}
