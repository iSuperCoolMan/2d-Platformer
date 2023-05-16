using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _points;

    public int Points
    {
        get
        {
            return _points;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinsCollector coinsCollector))
            Destroy(gameObject);
    }
}
