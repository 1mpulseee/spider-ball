using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;
using System;
using TMPro;

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
    public bool premium;
    [HideInInspector] public int Money
    {
        get { return _Money; }
        set 
        {
            _Money = value;
            MoneyText.text = value.ToString();
        }
    }
    private int _Money;
    public TMP_Text MoneyText;
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
        SceneManager.LoadScene(1);
    }
    public void Load()
    {
        lvl = YandexGame.savesData.lvl;
        Money = YandexGame.savesData.Money;
        premium = YandexGame.savesData.premium;
        leaderboardYG.NewScore(lvl);
        leaderboardYG.UpdateLB();
        AudioListener.volume = YandexGame.savesData.Volume;
    }
    public List<Sprite> Wallpapers;
    public Color _color;
    public bool Buy(int price)
    {
        if (Money > price)
        {
            Money -= price;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AddMoney(int Count)
    {
        Money += Count;
        YandexGame.savesData.Money = Money;
        YandexGame.SaveProgress();
    }
}
