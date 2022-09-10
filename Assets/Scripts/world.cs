using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;
public class world : MonoBehaviour
{
    public SpriteRenderer bg;
    public static world instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable() => YandexGame.CloseVideoEvent += Reward;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Reward;  
    private List<Rigidbody2D> targets = new List<Rigidbody2D>();
    public Rigidbody2D GetTarget(Vector3 pos)
    {
        Rigidbody2D rb = targets[0];
        for (int i = 1; i < targets.Count; i++)
        {
            if (Vector3.Distance(pos, rb.gameObject.transform.position) > Vector3.Distance(pos, targets[i].gameObject.transform.position))
            {
                rb = targets[i];
            }
        }
        return rb;
    }
    private int ChunkCount;
    public GameObject[] Spawns;
    public GameObject[] Chunks;
    public GameObject[] Finishs;
    private Vector3 SpawnPoint;
    private Vector3 Finish;
    private Transform player;
    private GameObject LastChunk;
    public Text LvlText;
    private void Start()
    {
        LvlText.text = Menu.instance.lvl.ToString();
        ChunkCount = 6;
        float C_L = Menu.instance.lvl;
        while (C_L > 1)
        {
            ChunkCount++;
            C_L /= 1.5f;
        }
        ChunkCount = (int)(ChunkCount * Random.Range(.5f, 1.5f));

        LastChunk = Instantiate(Spawns[Random.Range(0, Spawns.Length)], transform);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPoint = player.position;
        AddTargets(LastChunk.GetComponent<Chunk>().targets);
        for (int i = 1; i < ChunkCount; i++)
        {
            int ChunkId = Random.Range(0, Chunks.Length);
            float SpawnPos = LastChunk.transform.localPosition.x + LastChunk.GetComponent<Chunk>().end.localPosition.x - Chunks[ChunkId].GetComponent<Chunk>().start.transform.localPosition.x;
            LastChunk = Instantiate(Chunks[ChunkId], new Vector3(SpawnPos, 0, 0), Quaternion.identity);
            LastChunk.transform.SetParent(transform);
            AddTargets(LastChunk.GetComponent<Chunk>().targets);
        }
        int FinishsId = Random.Range(0, Finishs.Length);
        float SpawnPosF = LastChunk.transform.localPosition.x + LastChunk.GetComponent<Chunk>().end.localPosition.x - Finishs[FinishsId].GetComponent<Chunk>().start.transform.localPosition.x;
        LastChunk = Instantiate(Finishs[FinishsId], new Vector3(SpawnPosF, 0, 0), Quaternion.identity);
        Finish = GameObject.FindGameObjectWithTag("Finish").transform.position;
        LastChunk.transform.SetParent(transform);
        AddTargets(LastChunk.GetComponent<Chunk>().targets);

        bg.size = new Vector2(((Finish.x / bg.transform.localScale.x) * 2) + 2, bg.size.y);

        Pause.SetActive(false);
        PauseBtn.SetActive(true);
    }
    public void AddTargets(Rigidbody2D[] tg)
    {
        if (tg == null)
            return;
        for (int t = 0; t < tg.Length; t++)
            targets.Add(tg[t]);
    }
    public Transform Camera;
    private void FixedUpdate()
    {
        Camera.transform.position = new Vector3(player.position.x + 8, 0, -10);
        if (!player.GetComponent<move>().IsHook && player.transform.localPosition.y < -9)
        {
            player.position = SpawnPoint;
            player.GetComponent<DistanceJoint2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (player.transform.position.x > Finish.x)
        {
            NextLvl();
        }
    }
    public void NextLvl()
    {
        Menu.instance.lvl++;
        YandexGame.savesData.lvl = Menu.instance.lvl;
        YandexGame.SaveProgress();
        Ads.instance.ShowAds();
        SceneManager.LoadScene("Game");
    }
    public void SkipLvl()
    {
        Ads.instance.ShowRewardAd(0);
    }
    public void Reward(int id)
    {
        switch (id)
        {
            case 0:
                NextLvl();
                break;
        }
    }
    public GameObject Pause;
    public GameObject PauseBtn;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(!Pause.activeSelf);
        }
    }
    public void SetPause(bool State)
    {
        Pause.SetActive(State);
        PauseBtn.SetActive(!State);
        if (State)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}