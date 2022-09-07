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
        if (YandexGame.SDKEnabled)
        {
            Load();
        }
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

        for (int i = 0; i < YandexGame.savesData.IsOpen.Length; i++)
        {
            if (YandexGame.savesData.IsOpen[i] == true)
            {
                Close[i].SetActive(false);
            }
        }
        Open[YandexGame.savesData.Color].SetActive(true);

        if (YandexGame.savesData.Color == 0)
        {
            _color = Color.black;
        }
        if (YandexGame.savesData.Color == 1)
        {
            _color = new Color(255, 24, 0, 255);
        }
        if (YandexGame.savesData.Color == 2)
        {
            _color = new Color(255, 110, 0, 255);
        }
        if (YandexGame.savesData.Color == 3)
        {
            _color = new Color(255, 251, 1, 255);
        }
        if (YandexGame.savesData.Color == 4)
        {
            _color = new Color(16, 255, 1, 255);
        }
        if (YandexGame.savesData.Color == 5)
        {
            _color = new Color(166, 0, 255, 255);
        }
        if (YandexGame.savesData.Color == 6)
        {
            _color = new Color(255, 48, 209, 255);
        }
        if (YandexGame.savesData.Color == 7)
        {
            _color = new Color(255, 154, 255, 255);
        }
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
    [SerializeField] List<GameObject> Close;
    [SerializeField] List<GameObject> Open;
    public Color _color;
     public void ColorChange(int number)
    {
        Ads.instance.ShowRewardAd(number);
    }
    private void OnEnable() => YandexGame.CloseVideoEvent += Reward;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Reward;
    public void Reward(int id)
    {
        for (int i = 0; i < Open.Count; i++)
        {
            Open[i].SetActive(false);
        }
        Close[id].SetActive(false);
        Open[id].SetActive(true);

        YandexGame.savesData.Color = id;
        YandexGame.savesData.IsOpen[id] = true;

        YandexGame.SaveProgress();

        if (YandexGame.savesData.Color == 0)
        {
            _color = Color.black;
        }
        if (YandexGame.savesData.Color == 1)
        {
            _color = new Color(255, 24, 0, 255);
        }
        if (YandexGame.savesData.Color == 2)
        {
            _color = new Color(255, 110, 0, 255);
        }
        if (YandexGame.savesData.Color == 3)
        {
            _color = new Color(255, 251, 1, 255);
        }
        if (YandexGame.savesData.Color == 4)
        {
            _color = new Color(16, 255, 1, 255);
        }
        if (YandexGame.savesData.Color == 5)
        {
            _color = new Color(166, 0, 255, 255);
        }
        if (YandexGame.savesData.Color == 6)
        {
            _color = new Color(255, 48, 209, 255);
        }
        if (YandexGame.savesData.Color == 7)
        {
            _color = new Color(255, 154, 255, 255);
        }
    }
}
