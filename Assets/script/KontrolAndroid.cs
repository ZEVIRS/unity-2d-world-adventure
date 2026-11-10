
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KontrolAndroid : MonoBehaviour
{
    public static float Arah = 0f;
    public static bool MintaLompat = false;

    private static Canvas canvasKontrol;

    [Header("Gambar Tombol")]
    public Sprite gambarTombolKiri;
    public Sprite gambarTombolKanan;
    public Sprite gambarTombolLompat;

    private void Awake()
    {
        Arah = 0f;
        MintaLompat = false;
        canvasKontrol = null;
    }

    private void Start()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventObject = new GameObject("EventSystem");
            eventObject.AddComponent<EventSystem>();
            eventObject.AddComponent<StandaloneInputModule>();
        }

        GameObject canvasObject = new GameObject(
            "Kontrol Android",
            typeof(Canvas),
            typeof(CanvasScaler),
            typeof(GraphicRaycaster)
        );

        Canvas canvas = canvasObject.GetComponent<Canvas>();
        canvasKontrol = canvas;

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;

        CanvasScaler scaler = canvasObject.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.matchWidthOrHeight = 0.5f;

        BuatTombol(canvas.transform, "Kiri",
            new Vector2(0.08f, 0.13f),
            new Vector2(0.09f, 0.14f),
            JenisTombol.Kiri, gambarTombolKiri);

        BuatTombol(canvas.transform, "Kanan",
            new Vector2(0.20f, 0.13f),
            new Vector2(0.09f, 0.14f),
            JenisTombol.Kanan, gambarTombolKanan);

        BuatTombol(canvas.transform, "Lompat",
            new Vector2(0.88f, 0.15f),
            new Vector2(0.14f, 0.17f),
            JenisTombol.Lompat, gambarTombolLompat);

        // Sembunyikan kontrol saat menu utama muncul
        canvas.enabled = Time.timeScale > 0f;
    }

    public static void SetKontrolAktif(bool aktif)
    {
        if (canvasKontrol != null)
        {
            canvasKontrol.enabled = aktif;
        }
    }

    private enum JenisTombol
    {
        Kiri,
        Kanan,
        Lompat
    }

    private void BuatTombol(
        Transform induk,
        string nama,
        Vector2 posisi,
        Vector2 ukuran,
        JenisTombol jenis,
        Sprite gambar)
    {
        GameObject obj = new GameObject(
            "Tombol " + nama,
            typeof(RectTransform),
            typeof(Image),
            typeof(KontrolSentuh)
        );

        obj.transform.SetParent(induk, false);

        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchorMin = posisi;
        rect.anchorMax = posisi;
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.sizeDelta = new Vector2(
            ukuran.x * 1920f,
            ukuran.y * 1080f
        );
        rect.anchoredPosition = Vector2.zero;

        Image image = obj.GetComponent<Image>();
        image.sprite = gambar;
        image.color = Color.white;
        image.preserveAspect = true;
        image.raycastTarget = true;

        KontrolSentuh sentuh = obj.GetComponent<KontrolSentuh>();
        sentuh.jenis = (int)jenis;
    }
}

public class KontrolSentuh : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerExitHandler
{
    public int jenis;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 0f) return;

        if (jenis == 0)
            KontrolAndroid.Arah = -1f;
        else if (jenis == 1)
            KontrolAndroid.Arah = 1f;
        else
            KontrolAndroid.MintaLompat = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Lepas();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Lepas();
    }

    private void Lepas()
    {
        if (jenis == 0 && KontrolAndroid.Arah < 0f)
            KontrolAndroid.Arah = 0f;

        if (jenis == 1 && KontrolAndroid.Arah > 0f)
            KontrolAndroid.Arah = 0f;
    }
}
