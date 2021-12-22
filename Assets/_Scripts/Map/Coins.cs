using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coins : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private List<GameObject> _coins = new List<GameObject>();
    private GameObject _enteredSpawnPoint;

    private int _randomNumber;
    void Start()
    {
        for (int i = 0; i <= _coins.Count; i++)
        {
            _randomNumber = Random.Range(0, _spawnPoints.Count);
            _coins[i].transform.position = _spawnPoints[_randomNumber].gameObject.transform.position;
            _spawnPoints.RemoveAt(_randomNumber);
        }
    }
}
