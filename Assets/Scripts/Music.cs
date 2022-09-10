using System.Collections;
using UnityEngine;
using System;
using YG;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public Slider slider;
    private void Awake()
    {
        YandexGame.GetDataEvent += Load;
        if (YandexGame.SDKEnabled)
        {
            Load();
        }
    }
    public static Action _Volume;
    public static Action _Load;
    public IEnumerator Edit()
    {
        YandexGame.savesData.Volume = slider.value;
        _Volume.Invoke();
        yield return new WaitForSeconds(1f);
        YandexGame.SaveProgress();
    }
    public void Change()
    {
        if (gameObject.activeInHierarchy)
        {
            StopAllCoroutines();
            StartCoroutine(routine: Edit());
        }
    }
    public void Load()
    {
        slider.value = YandexGame.savesData.Volume;
        _Load.Invoke();
    }
}
