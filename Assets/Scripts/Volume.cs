using UnityEngine;
using UnityEngine.UI;
using YG;
public class volume : MonoBehaviour
{
    private Image Sound;
    public Sprite active;
    public Sprite disabled;
    private void Awake()
    {
        Sound = GetComponent<Image>();
    }
    private void OnEnable()
    {
        if (YandexGame.SDKEnabled)
            LoadVolume();
        else
            YandexGame.GetDataEvent += LoadVolume; 
    }
    private void OnDisable() => YandexGame.GetDataEvent -= LoadVolume;
    public void ChangeVolume()
    {
        if (YandexGame.savesData.Volume == 0)
        {
            YandexGame.savesData.Volume = 1;
            Sound.sprite = active;
        }
        else
        {
            YandexGame.savesData.Volume = 0;
            Sound.sprite = disabled;
        }
        AudioListener.volume = YandexGame.savesData.Volume;
        YandexGame.SaveProgress();
    }
    public void LoadVolume()
    {
        if (YandexGame.savesData.Volume == 0)
            Sound.sprite = disabled;
        else
            Sound.sprite = active;
    }
}