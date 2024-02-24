using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private TextMeshProUGUI _winText;

    private void Awake() 
    {
        AltarController.OnAltarWin += ProvideWinWindow;
    }

    private void ProvideWinWindow(List<string> list)
    {
        _winWindow.SetActive(true);
        _winText.text = $"Ты {list[0]}, {list[1]}, {list[2]}.";
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy() 
    {
        AltarController.OnAltarWin -= ProvideWinWindow;
    }
}
