using UnityEngine;

public class CameraAspectController : MonoBehaviour
{
    public float targetAspectWidth = 16.0f;
    public float targetAspectHeight = 9.0f;

    void Start()
    {
        AdjustCamera();
    }

    void Update()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        // Berechne das gew�nschte Seitenverh�ltnis
        float targetAspect = targetAspectWidth / targetAspectHeight;

        // Aktuelles Fenster-Seitenverh�ltnis
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Berechne das Skalierungsverh�ltnis der H�he
        float scaleHeight = windowAspect / targetAspect;

        // Greife auf die Kamera-Komponente zu
        Camera camera = GetComponent<Camera>();

        // Wenn das aktuelle Fenster-Seitenverh�ltnis gr��er als das gew�nschte ist
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // Wenn das aktuelle Fenster-Seitenverh�ltnis kleiner oder gleich dem gew�nschten ist
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}