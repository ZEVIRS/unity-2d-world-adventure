using UnityEngine;

public class MenuHowToPlay : MonoBehaviour
{
    public GameObject panelHowToPlay;

    public void BukaPetunjuk()
    {
        panelHowToPlay.SetActive(true);
    }

    public void TutupPetunjuk()
    {
        panelHowToPlay.SetActive(false);
    }
}