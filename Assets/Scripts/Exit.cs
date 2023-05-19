using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private int _enoughPointsAmount;
    [SerializeField] private Text _endGameText;

    private SpriteRenderer _spriteRenderer;
    private bool _isOpen;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.black;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinsCollector _) && _isOpen)
        {
            Destroy(collision.gameObject);
            Instantiate(_endGameText, FindObjectOfType<Canvas>().transform);
        }
    }

    public void EnoughPointsCollected(PointsCounter _pointsCounter)
    {
        if (_pointsCounter.Points >= _enoughPointsAmount)
            Open();
    }

    private void Open()
    {
        _spriteRenderer.color = Color.white;
        _isOpen = true;
    }
}
