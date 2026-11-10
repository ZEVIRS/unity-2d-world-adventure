using UnityEngine;

public class Berbalik_Badan : MonoBehaviour
{
    private GameObject karakter;
    private bool menghadapKanan = true;

    void Start()
    {
        karakter = GameObject.Find("Karakter");
        if (karakter != null) menghadapKanan = Mathf.Abs(karakter.transform.eulerAngles.y) < 90f;
    }

    void Update()
    {
        if (Time.timeScale == 0f || karakter == null) return;
        float keyboard = Input.GetAxisRaw("Horizontal");
        float arah = Mathf.Abs(KontrolAndroid.Arah) > 0.01f ? KontrolAndroid.Arah : keyboard;
        if (arah < -0.01f && menghadapKanan)
        {
            transform.Rotate(0, 180, 0);
            menghadapKanan = false;
        }
        else if (arah > 0.01f && !menghadapKanan)
        {
            transform.Rotate(0, -180, 0);
            menghadapKanan = true;
        }
    }
}
