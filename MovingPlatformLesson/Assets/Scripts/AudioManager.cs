using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource excitedAudio;
    [SerializeField] AudioSource peacefulAudio;
    [SerializeField] float fadeSpeed;

    float maxVolume = 1;
    float minVolume = 0;

    void Start()
    {
        excitedAudio.volume = maxVolume;
        peacefulAudio.volume = minVolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(FadeAudio(excitedAudio, minVolume));
            StartCoroutine(FadeAudio(peacefulAudio, maxVolume));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(FadeAudio(peacefulAudio, minVolume));
            StartCoroutine(FadeAudio(excitedAudio, maxVolume));
        }
    }

    IEnumerator FadeAudio(AudioSource audio, float volumeTarget)
    {
        float step = fadeSpeed * Time.deltaTime;
        while (audio.volume != volumeTarget)
        {
            audio.volume = Mathf.MoveTowards(audio.volume, volumeTarget, step);
            yield return null;
        }

        yield break;
    }
}
