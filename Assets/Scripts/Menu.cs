using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class Menu : MonoBehaviour
{
    public LeaderboardYG leaderboardYG;

    public static Menu instance;
    private void Awake()
    {
        if (instance != null)
        {
            lvl = instance.lvl;
        }
        instance = this;
        for (int i = 0; i < SceneObjs.Length; i++)
        {
            SceneObjs[i].SetActive(false);
        }
        SceneObjs[0].SetActive(true);
        YandexGame.GetDataEvent += Load;
    }
    public int lvl;
    public GameObject[] SceneObjs;
    public void Change(int id)
    {
        for (int i = 0; i < SceneObjs.Length; i++)
        {
            SceneObjs[i].SetActive(false);
        }
        if (id == 1 && YandexGame.SDKEnabled)
        {
            leaderboardYG.NewScore(lvl);
            leaderboardYG.UpdateLB();
        }
        SceneObjs[id].SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void Load()
    {
        lvl = YandexGame.savesData.lvl;
        leaderboardYG.NewScore(lvl);
        leaderboardYG.UpdateLB();
    }

    [SerializeField] List<GameObject> Wallpaper;
    [SerializeField] List<GameObject> imgWallpaper;
    public void ChangeWallpaper()
    {
        //Ads
        //есть тип список, из списка врубаетс€ фон, типо, фон сет актив (список‘онов[переменна€‘он++])
        //как фон добавить, чтобы он ни с чем не конфликтовал и ничего не перекрывал(а то верЄвку он перекрывает если просто как объект добавить), не знаю
        //смена картинки в настройках


    }
}
