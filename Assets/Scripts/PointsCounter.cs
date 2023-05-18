using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    private string _basicText;
    private int _points;

    public int Points
    {
        get
        {
            return _points;
        }
    }

    private void Start()
    {
        _basicText = GetComponent<Text>().text;
        AddPoints(0);
    }

    public void AddPoints(int points)
    {
        _points += points;
        GetComponent<Text>().text = _basicText + _points;
    }
}
