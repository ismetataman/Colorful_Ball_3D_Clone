using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
    public AdManager admanager;
    public void Start() 
    {
        CoinCalculator(0);
        Debug.Log("Money = " + PlayerPrefs.GetInt("moneyy"));
    }
    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Oyun Bitti");
            if(PlayerPrefs.GetInt("Noads") == 0)
            {
                admanager.RequestInterstitial();
            }
            admanager.RequestRewardedAd();
            CoinCalculator(100);
            uimanager.CoinTextUpdate();
            uimanager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex",PlayerPrefs.GetInt("LevelIndex")+ 1);
        }
    }

    public void CoinCalculator(int money)
    {
        if(PlayerPrefs.HasKey("moneyy")) // bu yoksa anlamına geliyor == false ile aynı yoksa 0 moneyy ata dedik
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy",oldScore + money); //eski paranın üzerine yenisini eklemek
        }
        else
        {
            PlayerPrefs.SetInt("moneyy",0);
        }
    }
}
