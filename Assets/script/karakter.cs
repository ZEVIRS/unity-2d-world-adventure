using UnityEngine;

public class karakter : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D aff;

    // TAMBAHAN
    private Animator anim;

    void Start()
    {
        aff = GetComponent<Rigidbody2D>();

        // TAMBAHAN
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0f) return;

        float keyboard = Input.GetAxisRaw("Horizontal");
        float tombolAndroid = KontrolAndroid.Arah;

        float gerak = keyboard;

        if (Mathf.Abs(tombolAndroid) > 0.01f)
        {
            gerak = tombolAndroid;
        }

        aff.linearVelocity = new Vector2(
            speed * gerak,
            aff.linearVelocity.y
        );

// TAMBAHAN ANIMASI
if (anim != null)
{
    anim.SetBool("IsRunning", Mathf.Abs(gerak) > 0.001f);

    anim.SetBool("IsJumping",
        Mathf.Abs(aff.linearVelocity.y) > 0.001f);
}
    }
}