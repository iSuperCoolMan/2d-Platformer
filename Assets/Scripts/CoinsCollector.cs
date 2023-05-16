using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Text _textObject;
    [SerializeField] private AudioSource _collectSound;
    [SerializeField] private UnityEvent _pointsAdded;

    private string _basicText;
    private int _points;

    public int Points
    {
        get
        {
            return _points;
        }
    }

    public event UnityAction PointsAdded
    {
        add => _pointsAdded.AddListener(value);
        remove => _pointsAdded.RemoveListener(value);
    }

    private void Start()
    {
        _basicText = _textObject.text;
        _textObject.text = _basicText + _points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            _pointsAdded.Invoke();
    }

    public void AddPointsFromCoin(Coin coin)
    {
        _points += coin.Points;
        _textObject.text = _basicText + _points;
        _collectSound.Play();
    }
}
