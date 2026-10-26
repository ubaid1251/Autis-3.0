using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class FindAnimals : MonoBehaviour
{
    public static FindAnimals ins;
    public GameObject AnimalParent, SoundBtn, Emoji, LostEmoji, BallonCanvas, Gameplay, EyesParent; 
    public Sprite[] AnimalSprites;
    public List<GameObject> AllAnimals;
    public List<GameObject> AnimalsEyes;
    public GameObject NameBar;
    public ParticleSystem Confeti;
    public TMP_Text FindAnimalName;
    public TMP_Text[] Names;
    public string[] AnimalsNames;

    public float delay = 0.0001f;
    private int playAnimalCount, soundNum;
    public bool Ballon = false, TextShow = false;

    GameObject Eyes;
    void Start()
    {
        ShuffleChildren();
        ins = this;
        CheckGap();
        playAnimalCount = PlayerPrefs.GetInt("countAnimal");
        if (PlayerPrefs.GetInt("IsText") == 1)
        {
            TextShow = true;
        }
    }
    //private void OnEnable()
    //{
    //    RemoveEyes();
    //}
    public void ConfetiPlay()
    {
        SoundManager.instance.PlayEffect_Instance(0);
        Confeti.gameObject.SetActive(true);
        Confeti.Play();
    }
    public void testng()
    {
        //if (SetNumber.Count < 4)
        //{
        //    PlayerPrefs.SetInt("countAnimal", PlayerPrefs.GetInt("countAnimal") + 1);
        //    if (playShapeCount >= 2)
        //    {
        //        // Reset the play count and increase SetNumber.Count
        //        SetNumber.Count++;
        //        PlayerPrefs.SetInt("countAnimal", 0);
        //        // Optionally, you can log the increment
        //        //Debug.Log($"SetNumber.Count incremented to {SetNumber.Count}");
        //    }
        //}
        //SceneManager.LoadScene(0);
    }
    void CheckGap()
    {
        if (SetNumber.Count == 2)
        {
            AnimalParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(280f, 0f);
        }
        else if (SetNumber.Count == 3)
        {
            AnimalParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(210f, 0f);
        }

        InstantiateAnimals();
    }
    void InstantiateAnimals()
    {
        // Remove any existing eye object
        if (Eyes != null)
        {
            Destroy(Eyes);
            Eyes = null;
        }

        List<Sprite> availableSprites = new List<Sprite>(AnimalSprites);

        for (int i = 0; i < SetNumber.Count; i++)
        {
            int randomIndex = Random.Range(0, availableSprites.Count);
            Sprite selectedSprite = availableSprites[randomIndex];
            availableSprites.RemoveAt(randomIndex);

            AllAnimals[i].GetComponent<Image>().sprite = selectedSprite;
            AllAnimals[i].SetActive(true);

            if (i == 0)
            {
                Eyes = Instantiate(AnimalsEyes[randomIndex], EyesParent.transform);
                soundNum = randomIndex;
            }
        }

        OrignalPosOfArrayInPlaytime();
        StartCoroutine(OnAnimals());
    }
    IEnumerator OnAnimals()
    {
        yield return new WaitForSeconds(0.3f);
        if (PlayerPrefs.GetInt("IsText") == 1)
        {
            NameBar.GetComponent<RectTransform>().DOAnchorPosX(292f, 0.5f).SetEase(Ease.Linear);
            FindAnimalName.text = AnimalsNames[soundNum].ToString();
        }
        PlayAnswerSound();
        for (int i = 0; i < SetNumber.Count; i++)
        {
            AllAnimals[i].GetComponent<Image>().enabled = true;
            AllAnimals[i].GetComponent<DOTweenAnimation>().DOPlay();
            yield return new WaitForSeconds(delay);

        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < SetNumber.Count; i++)
        {
            AllAnimals[i].transform.GetChild(0).GetComponent<Button>().enabled = true;
        }

        yield return new WaitForSeconds(0.7f);
        SoundBtn.GetComponent<Button>().interactable = true;

    }
    public static void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            // Swap the elements
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
    void ShuffleChildren()
    {
        // Get the child objects
        int childCount = SetNumber.Count;
        if (childCount <= 1)
        {
            Debug.LogWarning("Not enough children to shuffle!");
            return;
        }

        // Store children in a list
        Transform[] children = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            children[i] = AnimalParent.transform.GetChild(i);
        }

        // Shuffle the array of children
        for (int i = children.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            // Swap positions in the array
            Transform temp = children[i];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // Reassign the shuffled children to the parent
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetSiblingIndex(i);
        }

    }
    public void PlayAnswerSound()
    {
        if (SceneManager.GetActiveScene().name == "AnimalSounds")
        {
            SoundManager.instance.PlayAnimalEffect_Instance(soundNum);
        }
        Invoke("waitBtn", 1.5f);
    }
    public void ActiveSceneSoundsOff()
    {
        if (SceneManager.GetActiveScene().name == "AnimalSounds")
        {
            SoundManager.instance.StopAllAnimalSounds();
        }
    }
    void waitBtn()
    {
        SoundBtn.GetComponent<Button>().interactable = true;
    }
    void OrignalPosOfArrayInPlaytime()
    {
        int childCount = AnimalParent.transform.childCount;

        // Ensure AllShapes list is initialized
        if (AllAnimals == null || AllAnimals.Count != childCount)
        {
            AllAnimals = new List<GameObject>(childCount);
        }
        else
        {
            AllAnimals.Clear();
        }

        // Populate the AllShapes list with the children of ShapeParent
        for (int i = 0; i < childCount; i++)
        {
            AllAnimals.Add(AnimalParent.transform.GetChild(i).gameObject);
        }

    }
    public void RightBtn()
    {
        //RemoveEyes();
        ActiveSceneSoundsOff();
        if (PlayerPrefs.GetInt("IsText") == 1)
        {
            NameBar.transform.DOMoveX(-15.6f, 0.5f).SetEase(Ease.Linear);
        }
        SoundManager.instance.PlayEffect_Instance(7);
        if (SetNumber.Count < 4)
        {
            PlayerPrefs.SetInt("countAnimal", PlayerPrefs.GetInt("countAnimal") + 1);
            if (playAnimalCount >= 2)
            {
                SetNumber.Count++;
                PlayerPrefs.SetInt("countAnimal", 0);
                Ballon = true;
            }
        }
        else if (SetNumber.Count == 4)
        {
            PlayerPrefs.SetInt("countAnimal", PlayerPrefs.GetInt("countAnimal") + 1);
            if (playAnimalCount >= 2)
            {
                PlayerPrefs.SetInt("countAnimal", 0);
                Ballon = true;
            }
        }
        for (int i = 0; i < AllAnimals.Count; i++)
        {
            AllAnimals[i].transform.GetChild(0).GetComponent<Button>().enabled = false;
        }
        SoundBtn.GetComponent<Button>().interactable = false;
        ConfetiPlay();
        Emoji.SetActive(true);
        SoundBtn.SetActive(false);
    }
    public void ForBallon()
    {
        if (Ballon)
        {
            Ballon = false;
            BallonCanvas.SetActive(true);
            Gameplay.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void WrongBtn()
    {
      //  RemoveEyes();
        ActiveSceneSoundsOff();
        SoundManager.instance.PlayEffect_Instance(7);
        for (int i = 0; i < AllAnimals.Count; i++)
        {
            AllAnimals[i].transform.GetChild(0).GetComponent<Button>().enabled = false;
        }
        SoundBtn.GetComponent<Button>().interactable = false;
        LostEmoji.SetActive(true);
    }
   public void StartEyes()
    {
        Eyes.GetComponent<Animator>().enabled = true;
    }
}

