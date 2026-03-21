using System;
using DefaultNamespace;
using UnityEngine;

public class Coin : MonoBehaviour , IInteracteable
{
    public int CoinScroe { get; private set; } = 1;
    [SerializeField] private AudioClip clip;

    public void Interact(ref int points)
    {
        points += CoinScroe;
        Audio_Music.Instance.PlaySfx(clip);
        UiManager.Instance.ScoreText.text = "Score: " + points;
        Destroy(this.gameObject);
    }
}
