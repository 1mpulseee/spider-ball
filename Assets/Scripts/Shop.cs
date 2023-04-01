using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;
public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ThreadColor
    {
        public Color color;
        public int Price;
    }
    public ThreadColor[] ThreadColors;
    public GameObject SuccessfulPurchase;
    public TMP_Text BuyInfo;
    private void Start()
    {
        SuccessfulPurchase.SetActive(false);
    }
    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += PurchaseAuthorization;
    }
    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= PurchaseAuthorization;
    }
    public void PurchaseAuthorization(string id)
    {
        switch (id)
        {
            case "1":
                Menu.instance.AddMoney(100);
                SuccessfulPurchase.SetActive(true);
                BuyInfo.text = "100 монет";
                break;
            case "2":
                Menu.instance.AddMoney(500);
                SuccessfulPurchase.SetActive(true);
                BuyInfo.text = "500 монет";
                break;
            case "3":
                Menu.instance.AddMoney(3000);
                SuccessfulPurchase.SetActive(true);
                BuyInfo.text = "3000 монет";
                break;
            case "4":
                Menu.instance.AddMoney(15000);
                SuccessfulPurchase.SetActive(true);
                BuyInfo.text = "15000 монет";
                break;
            case "5":
                YandexGame.savesData.premium = true;
                Menu.instance.AddMoney(1000);

                YandexGame.SaveProgress();

                SuccessfulPurchase.SetActive(true);
                BuyInfo.text = "Премиуим";
                break;
        }
    }
    public void CloseSuccessfulPurchase()
    {
        SuccessfulPurchase.SetActive(false);
    }
}
