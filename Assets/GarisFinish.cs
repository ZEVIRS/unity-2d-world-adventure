
using UnityEngine;
using TMPro;

public class GarisFinish : MonoBehaviour
{
    public GameObject winImage;
    public GameObject buttonQuit;
    public GameObject buttonMainMenu;
    public GameObject congratulationsText;
    public TMP_Text totalScoreText;
    public AudioSource suaraWin;

    private bool sudahMenang = false;

    void Start()
    {
        if (winImage != null)
            winImage.SetActive(false);

        if (buttonQuit != null)
            buttonQuit.SetActive(false);

        if (buttonMainMenu != null)
            buttonMainMenu.SetActive(false);

        if (congratulationsText != null)
            congratulationsText.SetActive(false);

        if (totalScoreText != null)
            totalScoreText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (sudahMenang) return;

        if (other.CompareTag("Karakter"))
        {
            sudahMenang = true;

            if (winImage != null)
                winImage.SetActive(true);

            if (buttonQuit != null)
                buttonQuit.SetActive(true);

            if (buttonMainMenu != null)
                buttonMainMenu.SetActive(true);

            if (congratulationsText != null)
                congratulationsText.SetActive(true);

            if (totalScoreText != null)
            {
                totalScoreText.text =
                    "TOTAL SCORE: " + coinscore.hitungCoin;

                totalScoreText.gameObject.SetActive(true);
            }

            if (suaraWin != null)
                suaraWin.Play();

            Time.timeScale = 0f;
        }
    }
}
