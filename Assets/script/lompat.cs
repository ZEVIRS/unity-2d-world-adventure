using UnityEngine;

public class lompat : MonoBehaviour
{
    public float jump;
    public bool Floor;
    public Transform Detection;
    public LayerMask Layer_Sellection;
    public float Radius;

    void Update()
    {
        if (Time.timeScale == 0f) return;
        Floor = Physics2D.OverlapCircle(Detection.position, Radius, Layer_Sellection);
        bool keyboardJump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
        bool touchJump = KontrolAndroid.MintaLompat;
        KontrolAndroid.MintaLompat = false;

        if ((keyboardJump || touchJump) && Floor)
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        }
    }
}
