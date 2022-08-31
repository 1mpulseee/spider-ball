using UnityEngine;
using YG;
public class Ads : MonoBehaviour
{
    public static Ads instance;
    public YandexGame yg;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            yg = gameObject.AddComponent<YandexGame>();
        }
    }
}
