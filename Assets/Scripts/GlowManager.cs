using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GlowManager : MonoBehaviour
{
    private Image image;
    private Coroutine glowingCoroutine;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    private float[] HsvToRgb(float h, float s, float v)
    {
        int i;
        float f, p, q, t;

        if (s < float.Epsilon) {
            int c = (int)(v * 255);
            return new float[] { c, c, c };
        }

        h /= 60;
        i = (int)Math.Floor(h);
        f = h - i;
        p = v * (1 - s);
        q = v * (1 - s * f);
        t = v * (1 - s * (1 - f));

        float r, g, b;
        switch (i) {
            case 0: r = v; g = t; b = p; break;
            case 1: r = q; g = v; b = p; break;
            case 2: r = p; g = v; b = t; break;
            case 3: r = p; g = q; b = v; break;
            case 4: r = t; g = p; b = v; break;
            default: r = v; g = p; b = q; break;
        }
        return new float[] { r * 255, g * 255, b * 255 };
    }
    
    public void StartGlowing(float speedCoefficient)
    {
        glowingCoroutine = StartCoroutine(ColorGlow());
    }
    public void StopGlowing()
    {
        if (glowingCoroutine != null) StopCoroutine(glowingCoroutine);
        image.enabled = false;
    }
    public IEnumerator ColorGlow()
    {
        image.enabled = true;
        while (true)
        {
            for (int i = 0; i < 361; i += 10) 
            {
                float[] rgbColor = HsvToRgb(i, 1f, 1f);
                image.color = new Color(rgbColor[0] / 255, rgbColor[1] / 255, rgbColor[2] / 255, 0.3f);
                yield return new WaitForSeconds(0.000001f);
            }
        }
    }
}
