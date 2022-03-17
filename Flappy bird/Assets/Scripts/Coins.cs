using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins_UI;

    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.OnScoreChanged += SetCoinUI;
    }

    private void OnDisable()
    {
        _bird.OnScoreChanged -= SetCoinUI;
    }

    public void SetCoinUI(int coins)
    {
        _coins_UI.text = coins.ToString();
    }

}
