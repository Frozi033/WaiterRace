using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : StickmanCore
{
    private Vector3 _position;
    private float _speed;
    [SerializeField] private float _tableDistance = 1.9f;

    private NavMeshAgent _myAgent;
    private bool DiliveryCheck;

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _myAnimator = GetComponent<Animator>();
        MoveToTable();
        StartCoroutine(EnemyLoop());
        _myAnimator.SetBool("Delivery", true);
    }

    private void Update()
    {
        MoveAnimationSpeed(_myAgent.velocity.magnitude);
    }

    private IEnumerator EnemyLoop()
    {
        WaitForSeconds c = new WaitForSeconds(0.5f);
        while (true)
        {
            if (Vector3.Distance(transform.position, _position) <= _tableDistance)
            {
                MoveToTable();
            }
            yield return c;
        } 
    }

    private void MoveToTable()
    {
        _position = GetTable(false);
        _myAgent.SetDestination(_position);
    }
    
}
