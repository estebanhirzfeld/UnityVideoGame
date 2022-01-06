using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoiseManager : MonoBehaviour
{
    protected NoiseManager() { }
    public float playerNoise = 0f;
    public Slider sliderNoise;
    public static NoiseManager Instance;
    bool variationEffect = true;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartCoroutine(SliderVariation());
    }
    public void IncreaseNoise(float noise)
    {
        StartCoroutine(IncreasingNoise(noise));
    }
    public void DecreaseNoise(float noise)
    {

        StartCoroutine(DecreasingNoise(noise));
    }
    IEnumerator IncreasingNoise(float noise)
    {
        for (float i = 0; i < noise; i++)
        {
            playerNoise += 1;
            sliderNoise.value = playerNoise / 100;
            yield return new WaitForSeconds(0.01f);
        }

    }
    IEnumerator DecreasingNoise(float noise)
    {
        for (float i = 0; i < noise; i++)
        {
            playerNoise -= 1;
            sliderNoise.value = playerNoise / 100;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator SliderVariation()
    {
        float temp = 0.07f;
        while(variationEffect)
        {
             sliderNoise.value += 0.01f;
            yield return new WaitForSeconds(temp);
            sliderNoise.value -= 0.005f;
            yield return new WaitForSeconds(temp);
            sliderNoise.value += 0.005f;
            yield return new WaitForSeconds(temp);
            sliderNoise.value -= 0.01f;
            yield return new WaitForSeconds(temp);
        }

    }
}

