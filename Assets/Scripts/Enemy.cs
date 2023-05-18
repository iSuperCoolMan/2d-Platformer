using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _spinSpeed;
    [SerializeField] private AudioSource _damageAudio;

    private List<Vector3> _patroolPoints;
    private int _index;

    private void Start()
    {
        _patroolPoints = new List<Vector3>() { transform.position };
        _index = 0;

        PatroolPoint[] patroolPointsObjects = GetComponentsInChildren<PatroolPoint>();

        foreach (PatroolPoint patroolPointObject in patroolPointsObjects.OrderBy(patroolPoint => patroolPoint.name))
            _patroolPoints.Add(patroolPointObject.GetComponent<Transform>().position);
    }

    private void Update()
    {
        transform.Rotate(0, 0, _spinSpeed * Time.deltaTime * -1);

        transform.position = Vector3.MoveTowards
            (
            transform.position, 
            _patroolPoints[_index], 
            _moveSpeed * Time.deltaTime
            );

        if (transform.position == _patroolPoints[_index])
        {
            _index++;

            if (_index == _patroolPoints.Count)
                _index = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CoinsCollector coinsCollector))
        {
            _damageAudio.Play();
            Destroy(coinsCollector.gameObject);
        }
    }
}
