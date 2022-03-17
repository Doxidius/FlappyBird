using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvasGroup;
    [SerializeField] protected Button _button;


    protected abstract void Open();

    protected abstract void Close();



}
