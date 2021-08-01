using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BallMovement))]

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject _playerDeathEffect;

    private BallMovement _ballMovement;
    private Game _game;

    public float Coins { get; private set; }

    public event Action CoinCollected;

    private void Start()
    {
        _ballMovement = GetComponent<BallMovement>();
        _game = FindObjectOfType<Game>();
    }

    private void Die()
    {
        _playerDeathEffect.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _ballMovement.enabled = false;
        StartCoroutine(_game.RestartGame());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
            Coins++;
            CoinCollected?.Invoke();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Obstacle>(out _))
            Die();
    }
}
