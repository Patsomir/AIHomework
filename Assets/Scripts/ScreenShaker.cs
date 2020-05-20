using System.Collections;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve shakeCurve = null;

    private Vector3 initialCameraPosition;

    private static ScreenShaker instance;
    void Start()
    {
        instance = this;
        initialCameraPosition = transform.position;
    }

    public static void ShakeScreen(float intensity, float duration)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ScreenShakeCoroutine(intensity, duration));
    }

    private IEnumerator ScreenShakeCoroutine(float intensity, float duration)
    {
        float shakeStart = Time.time;
        float shakeEnd = shakeStart + duration;

        float noiseSeed = Random.value * 1000;
        float cameraJiggle = intensity * 10;

        while(Time.time < shakeEnd)
        {
            transform.position = initialCameraPosition;
            float normalizedTime = (Time.time - shakeStart) / duration;
            float offsetX = Mathf.PerlinNoise(noiseSeed + Time.time * cameraJiggle, 0);
            float offsetY = Mathf.PerlinNoise(0, noiseSeed + Time.time * cameraJiggle);

            Vector3 shake = new Vector2(offsetX, offsetY) *
                        shakeCurve.Evaluate(normalizedTime) *
                        intensity;

            transform.position = transform.position + shake;
            yield return null;
        }

        
    }

}
