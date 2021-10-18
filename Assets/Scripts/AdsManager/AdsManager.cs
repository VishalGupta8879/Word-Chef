﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
///using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

/**
  * Scene:All
  * Object:WebelinxCMS
  * Description: Scripta za komunikaciju sa native WebelinxCMS-om. Radi i za Android i za iOS. U sebi sadrzi f-je za prikaz Interstial-a, video reklama, za prikaz i sklanjanje banner-a, kao i za uzimanje raznih vrednosti sa servera.
  * Pre upotrebe skripte procitati uputstvo koje se nalazi na putanji Z:\+Unity\Unity Integration Guide for WebelinxCMS\
  **/
public class AdsManager : MonoBehaviour {

	public static AdsManager Instance;


	#region AdMob
	[Header("Admob")]
	public bool isTestAd;
	public string adMobAppID = "";
	// this is test ID
	public string interstitalAdMobId = "ca-app-pub-9543260370753546/5028476844";
	// this is test ID
	public string videoAdMobId = "ca-app-pub-9543260370753546/7715184083";
	// this is test ID
	public string bannerAdMobId = "ca-app-pub-9543260370753546/3835842346";
	/*private BannerView bannerView;
	InterstitialAd interstitialAdMob;
	private RewardBasedVideoAd rewardBasedAdMobVideo; 
	AdRequest requestAdMobInterstitial, AdMobVideoRequest;*/
	#endregion
	[Space(15)]
	#region
	[Header("UnityAds")]
	public string unityAdsGameId;
	public string unityAdsVideoPlacementId = "rewardedVideo";
	#endregion

	

	void Awake ()
	{
		
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
		
		/*gameObject.name = this.GetType().Name;
		DontDestroyOnLoad(gameObject);*/
		
	}

	private void Start()
	{
		InitializeAds();
	}

	public void ShowInterstitial()
	{
		//ShowAdMob();
		Yodo1AdsManager.instance.ShowInterstitial();//ads
	}

	public void IsVideoRewardAvailable()
	{
		Debug.Log("IsVideoRewardAvailable");
		
		if(isVideoAvaiable())
		{
			ShowVideoReward();
		}
		else
		{
			if (SceneManager.GetActiveScene().name == "MainScene")
				LevelSelectManager.levelSelectManager.menuManager.ShowPopUpMenu(Camera.main.GetComponent<ShopManager>().videoNotAvailablePopup);
			else
				GameplayManager.gameplayManager.menuManager.ShowPopUpMenu(Camera.main.GetComponent<ShopManager>().videoNotAvailablePopup);
		}
	}

	public void ShowVideoReward()
	{
		/*if(rewardBasedAdMobVideo.IsLoaded())
		{
			AdMobShowVideo();
		}*/
		//TapdaqAdHandler.instance.ShowRewardedVideoInterstitialWithUserId();//ads
		Yodo1AdsManager.instance.ShowReward();
	}

	private void RequestInterstitial()
	{

		if (isTestAd)
			interstitalAdMobId = "ca-app-pub-3940256099942544/1033173712";

		/*// Initialize an InterstitialAd.
		interstitialAdMob = new InterstitialAd(interstitalAdMobId);

		// Called when an ad request has successfully loaded.
		interstitialAdMob.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		interstitialAdMob.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is shown.
		interstitialAdMob.OnAdOpening += HandleOnAdOpened;
		// Called when the ad is closed.
		interstitialAdMob.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitialAdMob.OnAdLeavingApplication += HandleOnAdLeavingApplication;

		// Create an empty ad request.
		requestAdMobInterstitial = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitialAdMob.LoadAd(requestAdMobInterstitial);*/
	}

	public void ShowAdMob()
	{
		/*if(interstitialAdMob.IsLoaded())
		{
			interstitialAdMob.Show();
		}
		else
		{
			interstitialAdMob.LoadAd(requestAdMobInterstitial);
		}*/
	}
/*
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLoaded event received");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdClosed event received");
		interstitialAdMob.LoadAd(requestAdMobInterstitial);
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeftApplication event received");
	}
*/
	private void RequestRewardedVideo()
	{
		/*// Called when an ad request has successfully loaded.
		rewardBasedAdMobVideo.OnAdLoaded += HandleRewardBasedVideoLoadedAdMob;
		// Called when an ad request failed to load.
		rewardBasedAdMobVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoadAdMob;
		// Called when an ad is shown.
		rewardBasedAdMobVideo.OnAdOpening += HandleRewardBasedVideoOpenedAdMob;
		// Called when the ad starts to play.
		rewardBasedAdMobVideo.OnAdStarted += HandleRewardBasedVideoStartedAdMob;
		// Called when the user should be rewarded for watching a video.
		rewardBasedAdMobVideo.OnAdRewarded += HandleRewardBasedVideoRewardedAdMob;
		// Called when the ad is closed.
		rewardBasedAdMobVideo.OnAdClosed += HandleRewardBasedVideoClosedAdMob;
		// Called when the ad click caused the user to leave the application.
		rewardBasedAdMobVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplicationAdMob;
		// Create an empty ad request.
		AdMobVideoRequest = new AdRequest.Builder().Build();

		if (isTestAd)
			videoAdMobId = "ca-app-pub-3940256099942544/1033173713";


		// Load the rewarded video ad with the request.
		this.rewardBasedAdMobVideo.LoadAd(AdMobVideoRequest, videoAdMobId);*/
	}

    #region Reward Callback's
    /*public void HandleRewardBasedVideoLoadedAdMob(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
		
	}

	public void HandleRewardBasedVideoFailedToLoadAdMob(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);

	}

	public void HandleRewardBasedVideoOpenedAdMob(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStartedAdMob(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosedAdMob(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		this.rewardBasedAdMobVideo.LoadAd(AdMobVideoRequest, videoAdMobId);
	}

	public void HandleRewardBasedVideoRewardedAdMob(object sender, Reward args)
	{
		Camera.main.GetComponent<ShopManager>().AddCoinsAfterVideoWatched();
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);

	}

	public void HandleRewardBasedVideoLeftApplicationAdMob(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}*/
    #endregion

    void InitializeAds()
	{
		/*MobileAds.Initialize(adMobAppID);
		this.RequestBanner();
		this.rewardBasedAdMobVideo = RewardBasedVideoAd.Instance;
		this.RequestRewardedVideo();
		RequestInterstitial();*/
	}


	void AdMobShowVideo()
	{
		//rewardBasedAdMobVideo.Show();	
	}

	bool isVideoAvaiable()
	{
		#if !UNITY_EDITOR
		/*if(rewardBasedAdMobVideo.IsLoaded())
		{
			return true;
		}*/
		#endif
		return Yodo1AdsManager.instance.isRewardAvailable();
	}

	private void RequestBanner()
	{
		if (isTestAd)
			bannerAdMobId = "ca-app-pub-3940256099942544/6300978111";

/*
		if (this.bannerView != null)
		{
			this.bannerView.Destroy();
		}

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(bannerAdMobId, AdSize.SmartBanner, AdPosition.Top);

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleBannerOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleBannerOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleBannerOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleBannerOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleBannerOnAdLeavingApplication;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		this.bannerView.LoadAd(request);*/
	}


    #region callback's
    /*public void HandleBannerOnAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLoaded event received");
		bannerView.Show();
	}

	public void HandleBannerOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
			+ args.Message);
	}

	public void HandleBannerOnAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleBannerOnAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdClosed event received");
	}

	public void HandleBannerOnAdLeavingApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeftApplication event received");
	}*/
    #endregion
}
