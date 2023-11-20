using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenMúsica : MonoBehaviour
{
    public Slider sliderVolumen;
    public AudioSource musica;

    void Start()
    {
        if (musica != null && sliderVolumen != null)
        {
            sliderVolumen.value = musica.volume;
        }
    }

    public void AjustarVolumen()
    {
        if (musica != null && sliderVolumen != null)
        {
            musica.volume = sliderVolumen.value;
        }
    }
}
