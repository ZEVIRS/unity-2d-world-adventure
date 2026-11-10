using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NyawaManager : MonoBehaviour
{
    public int nyawa = 3;

    // Tetap ada kalau masih ingin menampilkan teks
    public Text teksNyawa;

    // Tambahan gambar hati
    public Image[] gambarHati;

    public GameObject panelGameOver;
    public AudioSource suaraGameOver;

    void Start()
    {
        TampilkanNyawa();
        panelGameOver.SetActive(false);
    }

    public void KurangiNyawa()
    {
        if (nyawa <= 0) return;

        nyawa--;
        TampilkanNyawa();

        if (nyawa <= 0)
        {
            panelGameOver.SetActive(true);

            if (suaraGameOver != null)
                suaraGameOver.Play();

            Time.timeScale = 0f;
        }
    }

    void TampilkanNyawa()
    {
        // Teks lama tetap berjalan
        if (teksNyawa != null)
            teksNyawa.text = " " + new string('♥', nyawa);

        // Tampilkan/sembunyikan gambar hati
        if (gambarHati != null)
        {
            for (int i = 0; i < gambarHati.Length; i++)
            {
                gambarHati[i].enabled = i < nyawa;
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("RestartLangsung", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}