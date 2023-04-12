using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;

    void Start()
    {
        
    }

    public void SetValue(float value)
    {
        AudioListener.volume = value;
        volumeSlider.value = value;
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
