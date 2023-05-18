using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinsCollector _))
        {
            GetComponentInParent<CoinSpawner>().AddCoinSpawnPoint(transform.position);
            Destroy(gameObject);
        }
    }
}
