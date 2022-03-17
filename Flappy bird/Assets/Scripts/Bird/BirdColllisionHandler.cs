using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdColllisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _coinSound;

    [SerializeField] private Coins _coin;

    private Bird _bird;


    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pipe") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            AudioSource.PlayClipAtPoint(_deathSound, Camera.main.transform.position);
            _bird.Die();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("CoinColector"))
        {
            _bird.IncreaseScore();
            AudioSource.PlayClipAtPoint(_coinSound, Camera.main.transform.position);
        }

    }

}
