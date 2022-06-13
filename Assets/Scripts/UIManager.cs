using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SoundManager sounds;
    public Text coin_text;
    public Image whiteeffectimage;
    private int effectcontrol =0;
    private bool radialshine;
    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;
    public Animator LayoutAnimator;
    //butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibraiton_On;
    public GameObject vibraiton_Off;
    public GameObject iap;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject taptomove_Text;
    public GameObject noAds;
    public GameObject shop;
    public GameObject RestartScreen;

    //Oyun Sonu Ekranı
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radialShine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject noThanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public Text achievedText;

    public object SceeneManager { get; private set; }
    public object SceenManager { get; private set; }

    public void Start() 
    {
        if(PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound",1);
        }

        if(PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration",1);
        }

        if(PlayerPrefs.GetInt("Noads") == 1)
        {
            NoadsRemove();
        }
        CoinTextUpdate();
    }
    public void Update()
    {
        if(radialshine == true)
        {
            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0,0,15f * Time.deltaTime));
        }
       FillRateImage.fillAmount = ((Player.transform.position.z * 100) / (FinishLine.transform.position.z))/100; // 100 ile çarpıp 100 ile bölmenin nedeni fillrate barı başlangıçta dolu gözükmesin diye
       //yoksa player 0 noktasında başlaması gerekiyor

    }


    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        taptomove_Text.SetActive(false);
        noAds.SetActive(false);
        shop.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        vibraiton_On.SetActive(false);
        vibraiton_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }

    public void NoadsRemove()
    {
        noAds.SetActive(false);
    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartSceen()
    {
        Variables.firsttouch = 0;
        Time.timeScale =1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextSceen()
    {
        Variables.firsttouch = 0;
        Time.timeScale =1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(1.3f);
        sounds.CompleteSound();
        radialShine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(3f);
        noThanks.SetActive(true);
    } 

    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        rewarded.SetActive(false);
        noThanks.SetActive(false);
        for (int i = 0; i < 401; i+=4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);
    }

   public void Privacy_Policy()
   {
       Application.OpenURL("https://www.google.com/");
   }
   public void TermOfUse()
   {
       Application.OpenURL("https://www.google.com/");
   }

    //buton fonksiyonları

    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if(PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }

        if(PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibraiton_On.SetActive(true);
            vibraiton_Off.SetActive(false);
        }
         else if(PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibraiton_On.SetActive(false);
            vibraiton_Off.SetActive(true);
        }
    }
    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
    }
    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound",2);
    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound",1);

    }
    public void Vibration_On()
    {
        vibraiton_On.SetActive(false);
        vibraiton_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration",2);
    }
    public void Vibration_Off()
    {
        vibraiton_On.SetActive(true);
        vibraiton_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration",1);
    }
    //haskey
    //get (getirir)
    //set (yerleştirir)

    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while(effectcontrol == 0)
        {   
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color += new Color(0,0,0,0.1f);
            if(whiteeffectimage.color == new Color(whiteeffectimage.color.r,whiteeffectimage.color.g,whiteeffectimage.color.b,1))
            {
                effectcontrol =1;
            }
        }

       while(effectcontrol ==1)
       {
           yield return new WaitForSeconds(0.001f);
           whiteeffectimage.color -= new Color(0,0,0,0.1f);
           if(whiteeffectimage.color == new Color(whiteeffectimage.color.r,whiteeffectimage.color.g,whiteeffectimage.color.b,0))
           {
               effectcontrol =2;
           }
       }
       if(effectcontrol == 2)
       {
           Debug.Log("Effekt bitti");
       }
    }
}
