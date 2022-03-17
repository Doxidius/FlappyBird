using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MenuScreen
{
    [SerializeField] private Game _game;


    protected override void Close()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
    }

    private void OnEnable()
    {
        _game.OnRestartTheGame += Close;
        _game.OnGameOver += Open;
    }

    private void OnDisable()
    {
        _game.OnRestartTheGame -= Close;
        _game.OnGameOver -= Open;
    }

    public void OnButtonClick()
    {
        _game.RestartGame();
        Close();
    }

    protected override void Open()
    {
        _canvasGroup.alpha = 1;
        _button.interactable = true;
    }
}
