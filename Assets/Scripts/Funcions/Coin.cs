using DefaultNamespace;
using UnityEngine;

public class Coin : MonoBehaviour , IInteracteable
{
    public int CoinScroe { get; private set; } = 1;

    public void Interact(ref int points)
    {
        points += CoinScroe;
        UiManager.Instance.ScoreText.text = "Score: " + points;
        Destroy(this.gameObject);
    }
}
