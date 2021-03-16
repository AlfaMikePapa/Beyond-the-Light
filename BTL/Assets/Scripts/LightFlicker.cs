using UnityEngine.Experimental.Rendering.LWRP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public float MaxReduction;
    public float MaxIncrease;
    public float RateDamping;
    public float Strength;
    public bool StopFlickering;

    private float _baseIntensity;
    private bool _flickering;

    public void Reset()
    {
        MaxReduction = 0.2f;
        MaxIncrease = 0.2f;
        RateDamping = 0.1f;
        Strength = 300;
    }

    UnityEngine.Experimental.Rendering.Universal.Light2D myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

        if (myLight == null)
        {
            Debug.LogError("Flicker script must have a Light Component on the same GameObject.");
            return;
        }
        _baseIntensity = myLight.intensity;
        StartCoroutine(DoFlicker());
    }

    void Update()
    {
        if (!StopFlickering && !_flickering)
        {
            StartCoroutine(DoFlicker());
        }
    }

    private IEnumerator DoFlicker()
    {
        _flickering = true;
        while (!StopFlickering)
        {
            myLight.intensity = Mathf.Lerp(myLight.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
            yield return new WaitForSeconds(RateDamping);
        }
        _flickering = false;
    }
}
