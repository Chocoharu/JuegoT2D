using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider volumeSlider; // Arrastra el slider desde el Inspector

    private void Start()
    {
        // Suscribe la funci�n al evento OnValueChanged del slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // Puedes usar el valor del volumen directamente o hacer alguna transformaci�n
        // Por ejemplo, para controlar el volumen de AudioListener, puedes usar:
        AudioListener.volume = volume;
    }
}
