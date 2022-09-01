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
}
