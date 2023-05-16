using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _translateSpeed;
    [SerializeField] private float _translateHeight;

    [SerializeField] private AudioSource _jumpAudio;

    private float _startPositionY;
    private float _endPositionY;

    private Coroutine _jump;

    private void Start()
    {
        _startPositionY = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Movement movement))
        {
            movement.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            Jump();
            _jumpAudio.Play();
        }
    }

    private void Jump()
    {
        if (_jump == null)
        {
            _jump = StartCoroutine(JumpCoroutine());
        }
        else
        {
            StopCoroutine(_jump);
            _jump = StartCoroutine(JumpCoroutine());
        }
    }

    private IEnumerator JumpCoroutine()
    {
        _endPositionY = transform.position.y + _translateHeight;

        while (transform.position.y < _endPositionY)
        {
            transform.Translate(0, _translateSpeed * Time.deltaTime, 0);
            yield return null;
        }

        while (transform.position.y > _startPositionY)
        {
            transform.Translate(0, _translateSpeed * Time.deltaTime * -1, 0);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, _startPositionY, transform.position.z);

        StopCoroutine(_jump);
        _jump = null;
    }
}
