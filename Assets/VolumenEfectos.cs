using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumenEfectos : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public float valorInicial;

    private string volumenSonidosString = "volumenSonidos";

    void Start()
    {
        valorInicial = PlayerPrefs.GetFloat(volumenSonidosString, 0.5f);
        slider.value = valorInicial;
        CambiarVolumen();
    }

    public void CambiarVolumen()
    {
        float volumen = slider.value;
        audioMixer.SetFloat(volumenSonidosString, VolumenEnDecibelios(volumen));

        PlayerPrefs.SetFloat(volumenSonidosString, volumen);
        PlayerPrefs.Save();
    }

    float VolumenEnDecibelios(float volumenNormalizado)
    {
        float rangoMinimo = 0.0001f;
        float decibelios = 20.0f * Mathf.Log10(Mathf.Max(volumenNormalizado, rangoMinimo));

        return decibelios;
    }
}
