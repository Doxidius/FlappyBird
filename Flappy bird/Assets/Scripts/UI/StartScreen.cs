using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MenuScreen
{
    [SerializeField] private  Game _game;


    protected override void Close()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
    }

    private void OnEnable()
    {
        _game.OnGameStartScreen += Open;
    }

    private void OnDisable()
    {
        _game.OnGameStartScreen -= Open;
    }
    
    public void OnButtonClick()
    {
        Debug.Log("Click");
        _game.StartGame();
        Close();
    }

    protected override void Open()
    {
        _canvasGroup.alpha = 1;
        _button.interactable = true;
        Debug.Log("Open");
    }
}
