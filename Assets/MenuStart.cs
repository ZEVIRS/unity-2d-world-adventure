
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public GameObject tombolStart;
    public GameObject panelMenuUtama;
    public GameObject teksNyawa;

    void Awake()
    {
        Time.timeScale = 0f;

        if (teksNyawa != null)
            teksNyawa.SetActive(false);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("RestartLangsung", 0) == 1)
        {
            PlayerPrefs.SetInt("RestartLangsung", 0);
            MulaiGame();
        }
    }

    public void MulaiGame()
    {
        Time.timeScale = 1f;

        if (panelMenuUtama != null)
            panelMenuUtama.SetActive(false);

        if (teksNyawa != null)
            teksNyawa.SetActive(true);

        KontrolAndroid.SetKontrolAktif(true);
    }

    public void KeluarGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void KembaliKeMenu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("RestartLangsung", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
