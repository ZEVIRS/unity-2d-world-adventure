
using UnityEngine;

public class BackgroundLooper2D : MonoBehaviour
{
    [Header("Pengaturan Background")]
    public int jumlahSalinan = 2;

    private void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite == null)
        {
            Debug.LogError("Sprite Renderer tidak ditemukan!");
            return;
        }

        float lebar = sprite.bounds.size.x;

        for (int i = 1; i <= jumlahSalinan; i++)
        {
            Vector3 posisi = transform.position;
            posisi.x += lebar * i;

            GameObject salinan = Instantiate(
                gameObject,
                posisi,
                transform.rotation
            );

            salinan.name = "Background_" + (i + 1);

            Destroy(salinan.GetComponent<BackgroundLooper2D>());
        }
    }
}
