using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;

    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(_scrollSpeed, 0f);
    }

    private void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
