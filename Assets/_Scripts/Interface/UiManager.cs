using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    private void Awake()
    {
        Table.DileveryIsOver += DileveryIsOver;
    }

    private void DileveryIsOver()
    {
        StartCoroutine(_timeToText());
    }
    private IEnumerator _timeToText()
    {
        _text.SetActive(true);
        yield return new WaitForSeconds(1f);
        _text.SetActive(false);
    }
}
