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
    [SerializeField] List<GameObject> Close;
    [SerializeField] List<GameObject> Open;
    public string color;
     public void ColorChange(string Value)
    {
        string[] data = Value.Split(' ');
        color = data[0];
        int number = int.Parse(data[1]);
        for (int i = 0; i < Open.Count; i++)
        {
            Open[i].SetActive(false);
        }
        Close[number].SetActive(false);
        Open[number].SetActive(true);

        if (color == "red")
        {
            GetComponent<move>().lineRenderer.material.color = Color.red;
        }
        if (color == "yellow")
        {
            GetComponent<move>().lineRenderer.material.color = Color.yellow;
        }
        if (color == "green")
        {
            GetComponent<move>().lineRenderer.material.color = Color.green;
        }
        if (color == "black")
        {
            GetComponent<move>().lineRenderer.material.color = Color.black;
        }
        if (color == "purpule")
        {
            GetComponent<move>().lineRenderer.material.color = Color.magenta;
        }
        if (color == "orange")
        {
            GetComponent<move>().lineRenderer.material.color = new Color(255, 174, 2, 255);
        }
        if (color == "pink0")
        {
            GetComponent<move>().lineRenderer.material.color = new Color(255, 48, 209, 255);
        }
        if (color == "pink1")
        {
            GetComponent<move>().lineRenderer.material.color = new Color(255, 154, 255, 255);
        }

    }
}
