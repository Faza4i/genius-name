using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class kakhoroshotebevidno : MonoBehaviour
{
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
