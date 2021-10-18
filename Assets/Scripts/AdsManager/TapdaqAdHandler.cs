/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tapdaq;
using Newtonsoft.Json;

public class TapdaqAdHandler : MonoBehaviour
{
    private string mTag = "default";
    public static TapdaqAdHandler instance;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
        OnClickInitialise();
    }
    // Subscribe to Tapdaq events
    private void OnEnable()
    {
        TDCallbacks.TapdaqConfigLoaded += LoadedConfig;
        TDCallbacks.TapdaqConfigFailedToLoad += FailedToLoadConfig;
        TDCallbacks.AdAvailable += AdAvailable;
        TDCallbacks.AdNotAvailable += AdNotAvailable;
        TDCallbacks.AdRefresh += AdRefresh;
        TDCallbacks.AdFailToRefresh += AdFailedToRefresh;
        TDCallbacks.AdWillDisplay += AdWillDisplay;
        TDCallbacks.AdDidDisplay += AdDidDisplay;
        TDCallbacks.AdDidFailToDisplay += AdDidFailToDisplay;
        TDCallbacks.AdClicked += AdClicked;
        TDCallbacks.AdClosed += AdClosed;
        TDCallbacks.AdError += AdError;
        TDCallbacks.RewardVideoValidated += RewardVideoValidated;
    }

    // Unsubscribe from Tapdaq events
    private void OnDisable()
    {
        TDCallbacks.TapdaqConfigLoaded -= LoadedConfig;
        TDCallbacks.TapdaqConfigFailedToLoad -= FailedToLoadConfig;
        TDCallbacks.AdAvailable -= AdAvailable;
        TDCallbacks.AdNotAvailable -= AdNotAvailable;
        TDCallbacks.AdRefresh -= AdRefresh;
        TDCallbacks.AdFailToRefresh -= AdFailedToRefresh;
        TDCallbacks.AdWillDisplay -= AdWillDisplay;
        TDCallbacks.AdDidDisplay -= AdDidDisplay;
        TDCallbacks.AdDidFailToDisplay -= AdDidFailToDisplay;
        TDCallbacks.AdClicked -= AdClicked;
        TDCallbacks.AdClosed -= AdClosed;
        TDCallbacks.AdError -= AdError;
        TDCallbacks.RewardVideoValidated -= RewardVideoValidated;
    }

    public void OnClickInitialise()
    {
        AdManager.Init();
    }

    //Callback handlers
    private void LoadedConfig()
    {
        Debug.Log("LoadedConfig");
        //SDK BOOT COMPLETE
        LoadBanner();
        LoadVideoInterstitial();
        LoadRewardedVideoInterstitial();
    }

    private void FailedToLoadConfig(TDAdError e)
    {
        //("FailedToLoadConfig: " + stringifyError(e));
    }

    private void AdAvailable(TDAdEvent e)
    {
        Debug.Log("AdAvailable Type: " + e.adType + " - Tag: " + e.tag);
        ShowBanner();
        //updateUI();
    }

    private void AdNotAvailable(TDAdEvent e)
    {
        Debug.Log("AdNotAvailable: " + (e.error));
    }

    private void AdRefresh(TDAdEvent e)
    {
        Debug.Log("AdRefresh: " + " - Tag: " + e.tag);
    }

    private void AdFailedToRefresh(TDAdEvent e)
    {
        Debug.Log("AdFailedToRefresh: " + (e.error));
    }

    private void AdWillDisplay(TDAdEvent e)
    {
         Debug.Log("AdWillDisplayType: " + e.adType + " - Tag: " + e.tag);
    }

    private void AdDidDisplay(TDAdEvent e)
    {
        Debug.Log("AdDidDisplay Type: " + e.adType + " - Tag: " + e.tag);
    }

    private void AdDidFailToDisplay(TDAdEvent e)
    {
        Debug.Log("AdDidFailToDisplay: " + (e.error));
    }

    private void AdClicked(TDAdEvent e)
    {
        Debug.Log("AdClicked Type: " + e.adType + " - Tag: " + e.tag);
    }

    private void AdClosed(TDAdEvent e)
    {
        Debug.Log("AdClosed Type: " + e.adType + " - Tag: " + e.tag);

        //updateUI();
    }

    private void AdError(TDAdEvent e)
    {
        Debug.Log("AdError: " + (e.error));
    }

    private void RewardVideoValidated(TDVideoReward e)
    {
        Debug.Log("RewardVideoValidated isValud: " + e.RewardValid + " - name: " + e.RewardName + " - Tag: " + e.Tag + " - amount: " + e.RewardAmount + " - CustomJson: " + JsonConvert.SerializeObject(e.RewardJson));
    }

    // Load Ads
    public void LoadStaticInterstitial()
    {
        Debug.Log("LoadStaticInterstitial");
        AdManager.LoadInterstitial("interstitialad");
    }

    public void LoadVideoInterstitial()
    {
        Debug.Log("LoadVideoInterstitial");
        AdManager.LoadVideo("interstitialad");
    }

    public void LoadRewardedVideoInterstitial()
    {
        Debug.Log("LoadRewardedVideoInterstitial");
        AdManager.LoadRewardedVideo("rewardad");
    }

    public void LoadBanner()
    {
        TDMBannerSize size = TDMBannerSize.TDMBannerStandard;
        AdManager.RequestBanner(size, "bannerad");
    }

    public void ShowStaticInterstitial()
    {
        Debug.Log("ShowStaticInterstitial");
        AdManager.ShowInterstitial("interstitialad");
    }

    public void ShowVideoInterstitial()
    {
        Debug.Log("ShowVideoInterstitial");
        AdManager.ShowVideo("interstitialad");
    }

    public void ShowRewardedVideoInterstitial()
    {
        Debug.Log("ShowRewardedVideoInterstitial");
        AdManager.ShowRewardVideo("rewardad");
    }

    public void ShowRewardedVideoInterstitialWithUserId()
    {
        Debug.Log("ShowRewardedVideoInterstitial");
        AdManager.ShowRewardVideo("rewardad", AdManager.GetUserId());
    }

    public void ShowBanner()
    {
        Debug.Log("ShowBanner");
        if (AdManager.IsBannerReady("bannerad"))
        {
            TDBannerPosition bannerPosition = TDBannerPosition.Bottom;
            AdManager.ShowBanner(bannerPosition, "bannerad");
        }
        else
        {
            LoadBanner();
        }

    }

    public void HideBanner()
    {
        Debug.Log("HideBanner");
        AdManager.HideBanner("bannerad");
        //updateUI();
    }

    public void DestroyBanner()
    {
        Debug.Log("DestroyBanner");
        AdManager.DestroyBanner("bannerad");
        //updateUI();
    }

}
*/