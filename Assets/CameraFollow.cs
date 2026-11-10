
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset;

    public float batasKiri = -10f;
    public float batasKanan = 55f;
    public float batasBawah = 0f;
    public float batasAtas = 0f;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;

    private float shakeTime = 0f;

    public void ShakeCamera()
    {
        shakeTime = shakeDuration;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 posisiTujuan = target.position + offset;

        posisiTujuan.x = Mathf.Clamp(
            posisiTujuan.x,
            batasKiri,
            batasKanan
        );

        posisiTujuan.y = Mathf.Clamp(
            posisiTujuan.y,
            batasBawah,
            batasAtas
        );

        Vector3 posisiKamera = Vector3.Lerp(
            transform.position,
            posisiTujuan,
            smoothSpeed * Time.deltaTime
        );

        if (shakeTime > 0)
        {
            Vector2 getaran = Random.insideUnitCircle * shakeMagnitude;
            posisiKamera.x += getaran.x;
            posisiKamera.y += getaran.y;

            shakeTime -= Time.deltaTime;
        }

        transform.position = posisiKamera;
    }
}
