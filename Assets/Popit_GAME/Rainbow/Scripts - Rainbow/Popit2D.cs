using System.Collections;
using System.Linq;
using UnityEngine;

namespace Rainbow
{
    public class Popit2D: MonoBehaviour
    {
        public GameObject BG;
        public Transform PopitsParent;
        private BoxCollider2D[] popits;
        int count;
        int total;
        bool initialized;
        SelectionPopit SM;
        //public ParticleSystem spikes;
        private void OnEnable()
        {
            EnablePopit();
            PopitsParent = transform;
        }
        private void Start()
        {
            SM = FindObjectOfType<SelectionPopit>();
            total = PopitsParent.childCount;
            popits = PopitsParent.GetComponentsInChildren<BoxCollider2D>();
            initialized = true;
        }
        public void EnablePopit()
        {
            if (initialized)
            {
                for (int i = 0; i < popits.Length; i++)
                {
                    popits[i].gameObject.SetActive(true);
                }
                count = 0;
            }
        }

        void Update()
        {
#if UNITY_EDITOR
            EditorInput();
#else
                MobileInput();
#endif
        }

        void MobileInput()
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    CheckHit(touch.position);
                }
            }
        }

        void EditorInput()
        {
            if (Input.GetMouseButton(0))
            {
                CheckHit(Input.mousePosition);
            }
        }

        void CheckHit(Vector3 position)
        {
            position = Camera.main.ScreenToWorldPoint(new Vector3(position.x , position.y , -Camera.main.transform.position.z));
            RaycastHit2D hit = Physics2D.Raycast(position , Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "obj" && count < popits.Length)
            {
                hit.transform.gameObject.SetActive(false);
                count++;
                if (GlobalVars.Instance.Sound)
                    SoundManagerPopit.Instance.PlayRandomAudio();
                //if (GlobalVars.Instance.Vibration)    //rainbow
                //    MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Selection);


                if (GlobalVars.Instance.Vibration && Dino.SoundManager.isHaptic)    //rainbow
                    MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Selection);



                /*            MobileCaseManger.Instance.AddCoin(hit.point,Popit2DManager.level);*/
                /*spikes.transform.position = hit.point;
                spikes.Play();*/
                if (count == total)
                {


                    SelectionPopit.selectManagerRaibowInstance.PlayParticles();
                    SoundManagerPopit.Instance.PlayOneShot("PopitLevelUp");
                    Invoke("ShowInterstitailAD", 1f);

                    StartCoroutine(ResetBlends());
                    StartCoroutine(GiveCoins());
                }
            }

        }

        private IEnumerator GiveCoins()
        {
            int num = total;

            int c = total;

            for (int i = 0; i < c; i++)
            {
                GlobalVars.Instance.SetLevelCoins(transform.name , GlobalVars.Instance.GetLevelCoins(transform.name) + 1);
                num -= 1;
                SM.UpdateUI();
                yield return null;
            }
            GlobalVars.Instance.SetLevelCoins(transform.name , GlobalVars.Instance.GetLevelCoins(transform.name) + num);
            GlobalVars.Instance.TotalCoins += total;
            num = 0;
            SM.UpdateUI();
        }
        private IEnumerator ResetBlends()
        {
            print("Reset Blends");
            var rand = new System.Random();
            var shuffled = popits.OrderBy(p => rand.Next());
            int i = 1;
            int count = popits.Length / 5;
            yield return new WaitForSeconds(0.5f);
            foreach (Collider2D popits in shuffled)
            {
                if (i % count == 0)
                {
                    if (GlobalVars.Instance.Sound)
                        SoundManagerPopit.Instance.PlayRandomAudio();
                    yield return new WaitForSeconds(0.1f);
                }
                i++;
                popits.gameObject.SetActive(true);
            }
            print("Reset");
            this.count = 0;
        }


        public void ShowInterstitailAD()
        {
            //if (GMAdsManager.Instance)
            //    GMAdsManager.Instance.Show_Interstitial();
            //Debug.Log("Ad showed");
        }


    }
}