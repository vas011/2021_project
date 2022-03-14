using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Goolge_Ads : MonoBehaviour
{
    private InterstitialAd interstitial;

    public void Start()
    {
        MobileAds.Initialize(initStatus =>
        {
            RequestInterstitial();
        });
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnityId = "ca-app-pub-2898828325601039/4224762416";
        #elif UNITY_IPHONE 
        string adUnityId = null;
        #else
                string adUnityId = "unexpected_platform";
        #endif
                this.interstitial = new InterstitialAd(adUnityId);
                AdRequest request = new AdRequest.Builder().Build();
                this.interstitial.LoadAd(request);
    }
    public void AdStart()
    {
        if(this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
