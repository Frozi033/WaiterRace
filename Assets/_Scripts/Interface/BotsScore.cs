using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BotsScore : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private string _teamName;
    
    private float _score;
    private Text _textProgress;
    void Start()
    {
        _textProgress = GetComponent<Text>();
        _score = 0;
        _textProgress.text = _teamName + ": " + _score;
        StartCoroutine(GetRandomScore());
    }

    private void UpdateScore()
    {
        _score += Random.Range(0, 6);
        _textProgress.text = _teamName + ": " + _score;
    }

    private IEnumerator GetRandomScore()
    {
        yield return new WaitForSeconds(_time);
        UpdateScore();
        StartCoroutine(GetRandomScore());
    }
}
