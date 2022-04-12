using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TableList : MonoBehaviour
{
    protected static List<GameObject> _tables = new List<GameObject>();
    private int _index;
    private Vector3 _tablePos;

    private void Awake()
    {
        AddTables();
    }

    protected Vector3 GetTable(bool isPlayer)
    {
        _index = Random.Range(0, _tables.Count);
        _tablePos = _tables[_index].gameObject.transform.position;
        
        if (isPlayer)
        {
            _tables[_index].gameObject.tag = "Delivering";
        }
        return _tablePos;
    }

    private void AddTables()
    {
        var tables = GameObject.FindGameObjectsWithTag("Table");
        for (int i = 0; i < tables.Length; i++)
        {
            _tables.Add(tables[i]);
        }

        Debug.Log(_tables.Count);
    }
}
