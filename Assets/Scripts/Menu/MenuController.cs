using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool IsPause => _isPause;

    [Header("References")]
    [Space]
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _loseWindow;
    [SerializeField] private GameObject _infoWindow;
    [SerializeField] private TextMeshProUGUI _winText;

    private bool _isPause;

    private void Awake() 
    {
        _isPause = false;

        AltarController.OnAltarWin += ProvideWinWindow;
        AltarController.OnPlayerLose += ProvideLoseWindow;
    }

    private void ProvideWinWindow(List<string> list)
    {
        PauseState(true);
        _winWindow.SetActive(true);
        _winText.text = $"Ты {list[0]}, {list[1]}, {list[2]}.";
    }
    
    private void ProvideLoseWindow()
    {
        PauseState(true);
        _loseWindow.SetActive(true);
    }

    public void ProvideInfoWindow()
    {
        _infoWindow.SetActive(!_infoWindow.activeSelf);
        PauseState(_infoWindow.activeSelf);
    }

    public void PauseState(bool state)
    {
        if(_loseWindow.activeSelf) return;
        _isPause = state;
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
