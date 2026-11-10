using UnityEngine;

public class ObstacleShake : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            NyawaManager pengaturNyawa = FindObjectOfType<NyawaManager>();

            if (pengaturNyawa != null)
            {
                // Getar hanya jika nyawa masih lebih dari 1
                if (pengaturNyawa.nyawa > 1)
                {
                    CameraFollow kamera = Camera.main.GetComponent<CameraFollow>();

                    if (kamera != null)
                    {
                        kamera.ShakeCamera();
                    }
                }

                pengaturNyawa.KurangiNyawa();
            }
        }
    }
}