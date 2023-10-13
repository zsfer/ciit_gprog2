using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{
    private Volume _vol;

    void Start()
    {
        _vol = GetComponent<Volume>();
    }

    void Update()
    {
        if (_vol.profile.TryGet(out LensDistortion dst))
        {
            var dstVal = Mathf.Clamp(PlayerController.Instance.Input.InputVector.magnitude * -0.5f, -0.7f, 0.5f);
            dst.intensity.value = Mathf.Lerp(dst.intensity.value, dstVal, 10 * Time.deltaTime);
        }
    }
}
