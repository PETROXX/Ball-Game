using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Vector2 _startSpawnPosition;
    [SerializeField] private float yPosition;

    private Vector2 _bottomLeftCorner;
    private Vector2 _bottomRightCorner;
    private float _threshlold = 1f;
    private float _obstacleSpawnProbability = 0.07f;
    private float _coinSpawnProbability = 0.3f;
    private List<GroundPart> _groundParts = new List<GroundPart>();
    private GroundPart _lastSpawnedGroundPart;

    private void Start()
    {
        GameObject groundPart = Instantiate(_groundPrefab, _startSpawnPosition, Quaternion.identity);
        _lastSpawnedGroundPart = groundPart.GetComponent<GroundPart>();
        _groundParts.Add(_lastSpawnedGroundPart);
    }

    private void LocationElement()
    {
        Vector2 groundPartPosition = new Vector2(_lastSpawnedGroundPart.EndXPosition, yPosition);
        GameObject groundPart = Instantiate(_groundPrefab, groundPartPosition, Quaternion.identity);
        groundPart.transform.SetParent(transform);
        _lastSpawnedGroundPart = groundPart.GetComponent<GroundPart>();
        _groundParts.Add(_lastSpawnedGroundPart);

        if (Random.value <= _obstacleSpawnProbability)
        {
            SpawnObstacle();
            return;
        }

        if(Random.value <= _coinSpawnProbability)
        {
            SpawnCoin();
        }
    }

    private void SpawnObstacle()
    {
        Vector2 obstaclePosition = new Vector2(_lastSpawnedGroundPart.transform.position.x, _lastSpawnedGroundPart.ObstacleYPosition);
        GameObject obstacle = Instantiate(_obstaclePrefab, obstaclePosition, Quaternion.identity);
        obstacle.transform.SetParent(_lastSpawnedGroundPart.transform);
        return;
    }

    private void SpawnCoin()
    {
        Vector2 coinPosition = new Vector2(_lastSpawnedGroundPart.transform.position.x, _lastSpawnedGroundPart.CoinYPosition);
        GameObject coin = Instantiate(_coinPrefab, coinPosition, Quaternion.identity);
        coin.transform.SetParent(_lastSpawnedGroundPart.transform);
    }


    private void Update()
    {
        _bottomLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        _bottomRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane));

        foreach (GroundPart groundPart in _groundParts)
        {
            if (groundPart.transform.position.x + _threshlold < _bottomLeftCorner.x)
            {
                _groundParts.Remove(groundPart);
                Destroy(groundPart.gameObject);
                break;
            }
        }

        if (_bottomRightCorner.x > _groundParts[_groundParts.Count - 1].transform.position.x)
            LocationElement();
    }
}
