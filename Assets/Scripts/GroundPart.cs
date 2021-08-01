using UnityEngine;

public class GroundPart : MonoBehaviour
{
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _obstacleSpawnPosition;
    [SerializeField] private Transform _coinSpawnPosition;

    public float EndXPosition => _endPosition.position.x;
    public float ObstacleYPosition => _obstacleSpawnPosition.position.y;
    public float CoinYPosition => _coinSpawnPosition.position.y;

}
