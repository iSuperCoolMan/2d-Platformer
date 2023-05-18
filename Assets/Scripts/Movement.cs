using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private KeyCode _leftKey;
    private KeyCode _rightKey;

    private void Start()
    {
        _leftKey = KeyCode.A;
        _rightKey = KeyCode.D;
    }

    private void Update()
    {
        Move(_leftKey);
        Move(_rightKey);
    }

    private void Move(KeyCode key)
    {
        if (Input.GetKey(key))
        {
            if (Input.GetKeyDown(key))
                GetComponent<Animator>().SetBool("IsMoving", true);

            transform.Translate(GetCurrentX(key), 0, 0);
        }
        else if (Input.GetKeyUp(key))
        {
            GetComponent<Animator>().SetBool("IsMoving", false);
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
