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
        Music._Volume += ChangeVolume;
        Music._Load += Load;
    }
    private void OnDisable()
    {
        Music._Volume -= ChangeVolume;
        Music._Load -= Load;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            AudioSource.Play();
        }
    }
}
