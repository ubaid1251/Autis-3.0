using GameWork.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rainbow
{
    public class SelectionPopit : MonoBehaviour
    {

        public GameObject[] levels;
        private int currentLevel;
        public GameObject SelectionPanel;
        public GameObject Hud;
        public LoadingScreen loadingScreen;
        public GameObject PlayScreen;
        public GameObject SettingUI;
        public GameObject RatingbarUI;
        public GameObject ExitScreen, confettiParticles;
        public Text coinsLable;
        public Image BG;
        public Sprite[] BgSprites;
        public static SelectionPopit selectManagerRaibowInstance;
        // Start is called before the first frame update
        void Start()
        {
            Hud.SetActive(false);
            SelectionPanel.SetActive(true);

            if (selectManagerRaibowInstance == null)
            {
                selectManagerRaibowInstance = this;
            }

        }
        private void OnEnable()
        {
            int randomIndex = Random.Range(0, BgSprites.Length);
            BG.sprite = BgSprites[randomIndex];
        }
        public void Play()
        {
            loadingScreen.ShowLoadingScreen().OnComplete(() =>
            {
                PlayScreen.SetActive(false);
                SelectionPanel.SetActive(true);
                coinsLable.text = GlobalVars.Instance.TotalCoins.ToString();
            });
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
        
        public void Home()
        {
            //GoogleAdMobController.THIS.ShowInterstitialAd(); //AdCallPosition

            loadingScreen.ShowLoadingScreen().OnComplete(() =>
            {
                coinsLable.text = GlobalVars.Instance.TotalCoins.ToString();
                levels[currentLevel].SetActive(false);
                SelectionPanel.SetActive(true);
                Hud.SetActive(false);
                if (!GlobalVars.Instance.Rated)
                {
                    GlobalVars.Instance.RateCount++;
                    if (GlobalVars.Instance.RateCount > 5)
                    {
                        Invoke("ShowRatingbar" , 5f);
                        GlobalVars.Instance.RateCount = 0;
                    }
                }
            });

        }

        public void SelectLevel(int index)
        {
            //if (GMAdsManager.Instance)
            //{
            //    GMAdsManager.Instance.Show_SmallBanner_1();
            //    Debug.Log("Banner shown");
            //}

            var selectedObj = EventSystem.current.currentSelectedGameObject;
            var rewardBase  =selectedObj.transform.GetComponent<RewardBaseUnlock>();

            if (rewardBase.isLocked)
            {
                Debug.Log("show ad");
                //if (GMAdsManager.Instance)
                //    GMAdsManager.Instance.ShowBothRewarded(rewardBase.UnlockedLevel);
            }
            else
            {
                bool showAd = true;
                loadingScreen.ShowLoadingScreen().OnComplete(() =>
                {
                    SelectionPanel.SetActive(false);
                    levels[index].SetActive(true);
                    Hud.SetActive(true);
                    coinsLable.text = GlobalVars.Instance.GetLevelCoins(levels[index].name).ToString();
                    currentLevel = index;
                }).OnUpdate((progress) =>
                {
                    if (progress > 0.3f && showAd)
                    {
                        showAd = false;
                        // GoogleAdMobController.THIS.ShowInterstitialAd(); //AdCallPosition
                    }
                });
            }
        }

        public void Rate()
        {

            Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        }

        public void ShowSetting()
        {
            SettingUI.SetActive(true);
        }
        public void ShowExit()
        {
            ExitScreen.SetActive(true);
        }

        public void ShowRatingbar()
        {
            RatingbarUI.SetActive(true);
        }
        public void UpdateUI()
        {
            coinsLable.text = GlobalVars.Instance.GetLevelCoins(levels[currentLevel].name).ToString();
        }


        public void PlayParticles()
        {
            confettiParticles.SetActive(true);
            Invoke("StopParticles", 3f);

        }

        public void StopParticles()
        {
            confettiParticles.SetActive(false);
        }
    }
}