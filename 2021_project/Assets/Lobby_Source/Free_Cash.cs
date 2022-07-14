using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Free_Cash : MonoBehaviour
{
    [SerializeField]
    GameObject Ads_Panel;
    [SerializeField]
    GameObject Free_plus_Panel;
    [SerializeField]
    Text Free_cash_Text;

    [SerializeField]
    Text Coin_Text;
    [SerializeField]
    Text Cash_Text;

    GameObject google_ads;
    GameObject Player_Manager;

    int Random_free_cash = 0;


    private void Start()
    {
        google_ads = GameObject.Find("Google_Ads");
        Player_Manager = GameObject.Find("Player_Manager");
        Coin_Text.text = ": " + Player_Manager.GetComponent<PlayerManager>().Coin.ToString();
        Cash_Text.text = ": " + Player_Manager.GetComponent<PlayerManager>().Cash.ToString();
    }

    public void Ads_onoff()
    {
        if(Ads_Panel.activeSelf == false)
        {
            Ads_Panel.SetActive(true);
        }
        else
        {
            Ads_Panel.SetActive(false);
        }
    }

    public void free_plus_panel()
    {
        if(Free_plus_Panel.activeSelf == true)
        {
            Free_plus_Panel.SetActive(false);
            Ads_Panel.SetActive(false);
        }
        else
        {
            google_ads.GetComponent<Goolge_Ads>().AdStart();
            Random_free_cash = Random.Range(10,50);
            Free_cash_Text.text = Random_free_cash.ToString(); // 랜덤 다이아 얼마 받았는지 표기
            Player_Manager.GetComponent<PlayerManager>().Cash += Random_free_cash; // 랜덤값을 플레이어 매니저에 저장
            Cash_Text.text = ": " + Player_Manager.GetComponent<PlayerManager>().Cash.ToString(); // 랜덤값 메인화면 UI 표기
            Free_plus_Panel.SetActive(true);
        }
    }

    public void Game_Start_button()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
