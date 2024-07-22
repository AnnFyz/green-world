using UnityEngine;
using UnityEngine.UI;

public class CanvasAspectController : MonoBehaviour
{
    public Canvas canvas;
    public float targetAspectWidth = 16.0f;
    public float targetAspectHeight = 9.0f;

    void Start()
    {
        AdjustCanvas();
    }

    void Update()
    {
        AdjustCanvas();
    }

    void AdjustCanvas()
    {
        // Berechne das gew�nschte Seitenverh�ltnis
        float targetAspect = targetAspectWidth / targetAspectHeight;

        // Aktuelles Fenster-Seitenverh�ltnis
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Berechne das Skalierungsverh�ltnis der H�he
        float scaleHeight = windowAspect / targetAspect;

        CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();

        // Wenn das aktuelle Fenster-Seitenverh�ltnis gr��er als das gew�nschte ist
        if (scaleHeight < 1.0f)
        {
            canvasScaler.matchWidthOrHeight = 0; // Passe die Breite an
        }
        else // Wenn das aktuelle Fenster-Seitenverh�ltnis kleiner oder gleich dem gew�nschten ist
        {
            canvasScaler.matchWidthOrHeight = 1; // Passe die H�he an
        }
    }
}
