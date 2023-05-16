using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private CoinsCollector _coinsCollector;
    [SerializeField] private int _enoughPointsAmount;
    [SerializeField] private Text _endGameText;

    private bool _isOpen;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void OnEnable()
    {
        _coinsCollector.PointsAdded += EnoughPointsCollected;
    }

    private void OnDisable()
    {
        _coinsCollector.PointsAdded -= EnoughPointsCollected;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoinsCollector>() == _coinsCollector && _isOpen)
        {
            Destroy(collision.gameObject);
            Instantiate(_endGameText, FindObjectOfType<Canvas>().transform);
        }
    }

    private void EnoughPointsCollected()
    {
        if (_coinsCollector.Points >= _enoughPointsAmount)
            Open();
    }

    private void Open()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        _isOpen = true;
    }
}
