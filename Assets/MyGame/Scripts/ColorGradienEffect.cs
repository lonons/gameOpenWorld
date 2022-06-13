using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorGradienEffect : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private ColorGrading _colorGrading;
    private int _valueTemperature =-20;

    private void Start()
    {
        SettingsColorGrading();
        var settings = new PostProcessEffectSettings[] { _colorGrading };
        _postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer,2,settings);
        StartCoroutine(CoroutineChangeColorGrading());
        
    }

    private IEnumerator CoroutineChangeColorGrading()
    {
        while (true)
        {
            _colorGrading.temperature.value = _valueTemperature;
            _valueTemperature++;
            if (_valueTemperature >= 30) break;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    private void SettingsColorGrading()
    {
        _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        _colorGrading.enabled.Override(true);
        _colorGrading.temperature.Override(1f);
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(_postProcessVolume, true, true);
    }
}
