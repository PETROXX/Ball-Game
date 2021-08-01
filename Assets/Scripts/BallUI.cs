using UnityEngine;
using TMPro;

[RequireComponent(typeof(Ball))]

public class BallUI : MonoBehaviour
{
   [SerializeField] private TMP_Text _coinsAmount;

    private Ball _ball;

    private void Start()
    {
        _ball = GetComponent<Ball>();
        _ball.CoinCollected += UpdateUI;
        _coinsAmount.text = "0";
    }

    private void UpdateUI()
    {
        _coinsAmount.text = _ball.Coins.ToString();
    }

}
