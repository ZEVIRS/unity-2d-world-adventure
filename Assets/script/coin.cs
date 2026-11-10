
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioSource suaraKoin;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Karakter"))
        {
            print("coin diambil");

            AudioSource.PlayClipAtPoint(
                suaraKoin.clip,
                Camera.main.transform.position
            );

            coinscore.hitungCoin += 50;

            Destroy(gameObject);
        }
    }
}
