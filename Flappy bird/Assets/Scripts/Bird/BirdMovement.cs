using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationPower;
    [SerializeField] private float _rotationPowerLerp;
    [SerializeField] private AudioClip _swingSFX;
    

    private Rigidbody2D _rb;
    private Animator _animator;

    private float _animetionTime = 0.2f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
 
    
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.up * _jumpForce;
            StartCoroutine(AnimationSwing());
            AudioSource.PlayClipAtPoint(_swingSFX, Camera.main.transform.position);
        }
        //Debug.Log(_rb.velocity.y);

    }
    private void FixedUpdate()
    {
        var prev = transform.rotation;

        Quaternion current = new Quaternion();

        current.eulerAngles = new Vector3(0,0, _rb.velocity.y * _rotationPower); 
        transform.rotation = Quaternion.Lerp(prev, current, _rotationPowerLerp);
        
    }

    public void ResetMovement()
    {
        transform.position = _startPosition.position;
        _rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private IEnumerator AnimationSwing()
    {
        _animator.Play("BirdSwinging", -1, 0f);

        yield return new WaitForSeconds(_animetionTime);

    }

}
