using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _spawnSpeedInSeconds;

    private List<Vector3> _coinSpawnPoints;

    private void Start()
    {
        _coinSpawnPoints = new List<Vector3>();

        CoinSpawnPoint[] coinSpawnPointsObjects = FindObjectsOfType<CoinSpawnPoint>();

        foreach (CoinSpawnPoint patroolPointObject in coinSpawnPointsObjects)
            _coinSpawnPoints.Add(patroolPointObject.transform.position);

        StartCoroutine(SpawnCoins());
    }

    public void AddCoinSpawnPoint(Vector3 vector3)
    {
        _coinSpawnPoints.Add(vector3);
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnSpeedInSeconds);
        int index;

        while(true)
        {
            index = Random.Range(0, _coinSpawnPoints.Count);

            if (index < _coinSpawnPoints.Count)
            {
                Instantiate(_coin.gameObject, _coinSpawnPoints[index], Quaternion.identity, transform);
                _coinSpawnPoints.RemoveAt(index);
            }
            
            yield return waitForSeconds;
        }
    }
}
