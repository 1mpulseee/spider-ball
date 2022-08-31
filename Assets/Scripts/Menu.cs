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
}
