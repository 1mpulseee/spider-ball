using System.Collections;
using UnityEngine;
using System;
using YG;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public Slider slider;
    public static Music instance;
    private void Awake()
    {
        instance = this;
        YandexGame.GetDataEvent += Load;
    }
    public Action _Volume;
    public Action _Load;
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
