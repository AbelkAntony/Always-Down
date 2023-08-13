using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startbutton;
    [SerializeField] GameObject gameName;

    private void Start()
    {
        DontDestroyOnLoad(startbutton);
        DontDestroyOnLoad(gameName);
        StartWindow();
    }

    private void StartWindow()
    {
        startbutton.SetActive(true);
        gameName.SetActive(true);
    }
}
