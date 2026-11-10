
using UnityEngine;
using UnityEngine.UI;

public class coinscore : MonoBehaviour
{
    public static int hitungCoin;

    private Text hitungCoinText;

    void Start()
    {
        
        hitungCoin = 0;

        hitungCoinText = GetComponent<Text>();
    }

    void Update()
    {
        if (hitungCoinText != null)
        {
            hitungCoinText.text = hitungCoin.ToString();
        }
    }
}
