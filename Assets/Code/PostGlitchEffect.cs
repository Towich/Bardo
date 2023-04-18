using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostGlitchEffect : MonoBehaviour
{
    public float glitch_speed = 10f;

    private PostProcessVolume postProcessVolume;

    private ChromaticAberration chromaticAberration;

    private float t;

    private Coroutine smoothTrans;
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StopAllCoroutines();
            smoothTrans = StartCoroutine(SmoothTransition());
        }
        if (Input.GetKey(KeyCode.C))
        {
            chromaticAberration.intensity.value = 0f;
        }
    }

    public IEnumerator SmoothTransition()
    {
        float elapsed = 0.0f;
        
        while (chromaticAberration.intensity.value < 1f)
        {
            chromaticAberration.intensity.value += Time.deltaTime * glitch_speed;

            yield return null;
        }
        
        while (chromaticAberration.intensity.value > 0f)
        {
            chromaticAberration.intensity.value -= Time.deltaTime * glitch_speed;

            yield return null;
        }
    }
}
