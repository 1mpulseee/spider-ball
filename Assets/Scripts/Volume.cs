using UnityEngine;
using YG;
public class Volume : MonoBehaviour
{
    private AudioSource AudioSource;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        if (YandexGame.SDKEnabled)
        {
            Load();
        }
        else
        {
            AudioSource.enabled = false;
        }
    }
    private void OnEnable()
    {
        Music.instance._Volume += ChangeVolume;
        Music.instance._Load += Load;
    }
    private void OnDisable()
    {
        Music.instance._Volume -= ChangeVolume;
        Music.instance._Load -= Load;
    }
    public void ChangeVolume()
    {
        AudioSource.volume = YandexGame.savesData.Volume;
    }
    public void Load()
    {
        AudioSource.enabled = true;
        AudioSource.volume = YandexGame.savesData.Volume;
    }
}
