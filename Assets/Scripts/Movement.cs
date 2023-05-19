using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string _movingCondition = "IsMoving";
    
    [SerializeField] private float _speed;

    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private Animator _animator;

    private void Start()
    {
        _leftKey = KeyCode.A;
        _rightKey = KeyCode.D;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move(_leftKey);
        Move(_rightKey);
    }

    private void Move(KeyCode key)
    {
        bool isAnyKeyPressed = Input.GetKey(_leftKey) || Input.GetKey(_rightKey);

        if (Input.GetKey(key))
        {
            if (Input.GetKeyDown(key))
                _animator.SetBool(_movingCondition, true);

            transform.Translate(GetCurrentX(key), 0, 0);
        }
        else if (Input.GetKeyUp(key) && isAnyKeyPressed == false)
        {
            _animator.SetBool(_movingCondition, false);
        }
    }

    private float GetCurrentX(KeyCode key)
    {
        if (key == _leftKey)
            return _speed * Time.deltaTime * -1;
        else if (key == _rightKey)
            return _speed * Time.deltaTime;

        return 0;
    }
}
