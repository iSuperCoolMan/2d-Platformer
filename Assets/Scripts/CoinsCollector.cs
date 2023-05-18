using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private AudioSource _collectSound;
    [SerializeField] private UnityEvent _coinCollected;

    public event UnityAction PointsAdded
    {
        add => _coinCollected.AddListener(value);
        remove => _coinCollected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _collectSound.Play();
            _coinCollected.Invoke();
        }
    }
}
