using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(_leftKey))
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

        if (Input.GetKey(_rightKey))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
