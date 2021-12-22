using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Sprite _gear;
    [SerializeField] private Sprite _exit;
    

    public void OnSettingsCLick()
    {
        if (Panel.activeSelf == false)
        {
            Panel.SetActive(true);
            _buttonImage.sprite = _exit;
        }
        else if (Panel.activeSelf == true)
        {
            Panel.SetActive(false);
            _buttonImage.sprite = _gear;
        }
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }
}
