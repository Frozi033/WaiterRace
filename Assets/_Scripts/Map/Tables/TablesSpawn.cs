using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TablesSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private List<GameObject> _tables = new List<GameObject>();
    private int _tablesCount;
    private int _randomIndex;
    
    private void Start()
    {
        _tablesCount = _tables.Count;
        for (int i = 0; i <= _tablesCount; i++)
        {
            //_tables[i] = GetComponent<Transform>();
            _randomIndex = Random.Range(0, _tablesCount);
            _tables[i].transform.position = _spawnPoints[_randomIndex].transform.position;
            _spawnPoints.RemoveAt(_randomIndex);
            //_spawnPoints.Sort();
            Debug.Log("ss");
            
        }
    }
}
