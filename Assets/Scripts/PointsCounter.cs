using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    private string _basicText;
    private int _points;
    private Text _text;

    public int Points
    {
        get
        {
            return _points;
        }
    }

    private void Start()
    {
        _text = GetComponent<Text>();
        _basicText = _text.text;
        AddPoints(0);
    }

    public void AddPoints(int points)
    {
        _points += points;
        _text.text = _basicText + _points;
    }
}
