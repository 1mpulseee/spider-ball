using UnityEngine;
using YG;
public class Ads : MonoBehaviour
{
    public static Ads instance;
    private YandexGame yg;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            yg = gameObject.GetComponent<YandexGame>();
        }
    }
    private float time;
    public int AdsDelay = 150;
    private void Update()
    {
        time += Time.deltaTime;
    }
    public void ShowAds()
    {
        if (time > AdsDelay)
        {
            time = 0;
            yg._FullscreenShow();
        }
    }
}
