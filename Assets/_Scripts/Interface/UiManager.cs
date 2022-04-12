using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _deliveryOver;
    [SerializeField] private Text _text;
    
    private float _score;
    private void Awake()
    {
        Table.DileveryIsOver += DileveryIsOver;
        _text.text = "PlayerTeam: " + _score;
    }

    private void DileveryIsOver()
    {
        StartCoroutine(_timeToText());
        _score++;
        _text.text = "PlayerTeam: " + _score;
    }
    private IEnumerator _timeToText()
    {
        _deliveryOver.SetActive(true);
        yield return new WaitForSeconds(1f);
        _deliveryOver.SetActive(false);
    }
}
