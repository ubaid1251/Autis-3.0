using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SetFruits : MonoBehaviour
{
    public GameObject FruitInstantiateObj; // Prefab to instantiate
    public GameObject FruitParent,ShadowParent,Emoji,BallonCanvas,GamePlay;         // Parent object for fruits
    public int FruitCount=0;     // Number of fruits to create
    public Sprite[] FruitSprites;          // Array of fruit sprites
    public float delay = 0.0001f;
    private int playCount;
    public List<GameObject> AllFruit;
    public GameObject[] Shadows;
    public static SetFruits ins;
    public bool Ballon=false;
    void Start()
    {
        ins = this;
        if (SetNumber.Count >= 2)
        {
            ShuffleChildren();
        }
        CheckGap();
        playCount= PlayerPrefs.GetInt("countScene");
        //print("playCount= " + playCount);
    }
    public void EndCall()
    {
        print(SetNumber.Count);
        if (SetNumber.Count < 6)
        {
            PlayerPrefs.SetInt("countScene", PlayerPrefs.GetInt("countScene") + 1);
            if (playCount >= 2)
            {
                // Reset the play count and increase SetNumber.Count
                SetNumber.Count++;
                PlayerPrefs.SetInt("countScene", 0);
                // Optionally, you can log the increment
                Debug.Log($"SetNumber.Count incremented to {SetNumber.Count}");
                Ballon = true;
            }
        }
        else if(SetNumber.Count == 6)
        {
            PlayerPrefs.SetInt("countScene", PlayerPrefs.GetInt("countScene") + 1);
            if (playCount >= 2)
            {
                PlayerPrefs.SetInt("countScene", 0);
                Ballon = true;
            }
        }
        if (Ballon == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Ballon == true)
        {
            BallonCanvas.SetActive(true);
            GamePlay.SetActive(false);
            Ballon = false;
        }
    }
   void CheckGap()
    {
        if (SceneManager.GetActiveScene().name == "Fruit")
        {
            if (SetNumber.Count == 1 || SetNumber.Count == 2)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(100f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(100f, 0f);
            }
            else if (SetNumber.Count == 3)
            {
                    FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(0f, 0f);
                    ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(0f, 0f);
            }
            else if (SetNumber.Count == 4)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-30f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-30f, 0f);
            }
            else if (SetNumber.Count == 5)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-45f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-45f, 0f);
            }
            else if (SetNumber.Count == 6)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-60f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-60f, 0f);
            }
        }


        else
        {
            if (SetNumber.Count == 1 || SetNumber.Count == 2)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
            }
            else if (SetNumber.Count == 3)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
            }
            else if (SetNumber.Count == 4)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
            }
            else if (SetNumber.Count == 5)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(7.8f, 0f);
            }
            else if (SetNumber.Count == 6)
            {
                FruitParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-18f, 0f);
                ShadowParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(-18f, 0f);
            }

        }
        InstantiateFruits();
    }
    void InstantiateFruits()
    {
        // Ensure parent object exists
        if (FruitParent == null)
        {
            Debug.LogError("FruitParent is not assigned!");
            return;
        }

        // Ensure prefab exists
        if (FruitInstantiateObj == null)
        {
            Debug.LogError("FruitInstantiateObj is not assigned!");
            return;
        }

        // Ensure there are enough sprites for the number of fruits
        if (FruitSprites.Length < SetNumber.Count)
        {
            Debug.LogError("Not enough sprites in FruitSprites to assign unique images!");
            return;
        }

        // Create a list to track available sprites
        List<Sprite> availableSprites = new List<Sprite>(FruitSprites);

        // Instantiate the specified number of fruits
        for (int i = 0; i < SetNumber.Count; i++)
        {
            GameObject fruit = Instantiate(FruitInstantiateObj, FruitParent.transform);

            // Get a random sprite and remove it from the list
            int randomIndex = Random.Range(0, availableSprites.Count);
            Sprite selectedSprite = availableSprites[randomIndex];
            availableSprites.RemoveAt(randomIndex);

            // Assign the sprite to the fruit
            fruit.GetComponent<Image>().sprite = selectedSprite;
            fruit.name = $"Fruit_{i + 1}"; // Name each fruit uniquely
            fruit.GetComponent<DragDropObaid>().Shadow = Shadows[i];
            fruit.GetComponent<SetNewPos>().posObj = Shadows[i];
            Shadows[i].GetComponent<Image>().sprite = selectedSprite;
            Shadows[i].SetActive(true); 
            AllFruit.Add(fruit);
        }
        OrignalPosOfArrayInPlaytime();
        StartCoroutine(OnFruits());
    }
    IEnumerator OnFruits()
    {
       
       yield return new WaitForSeconds(0.3f);
       
        for (int i = 0; i < AllFruit.Count; i++)
        {
             SoundManager.instance.PlayEffect_Instance(8);
            AllFruit[i].GetComponent<Image>().enabled = true;
            AllFruit[i].GetComponent<DOTweenAnimation>().DOPlay();
            AllFruit[i].GetComponent<DragDropObaid>().enabled = true;
            AllFruit[i].GetComponent<BackObject>().enabled = true;
            
            yield return new WaitForSeconds(delay);
        }
        FruitParent.GetComponent<GridLayoutGroup>().enabled = false;
        for (int i = 0; i < AllFruit.Count; i++)
        {
            Shadows[i].GetComponent<Image>().enabled = true;
            Shadows[i].GetComponent<DOTweenAnimation>().DOPlay();
            yield return new WaitForSeconds(delay);
        }
        
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
            children[i] = ShadowParent.transform.GetChild(i);
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
    void OrignalPosOfArrayInPlaytime()
    {
        // Update the Shadows array based on the current hierarchy order
        int childCount = ShadowParent.transform.childCount;
        Shadows = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            Shadows[i] = ShadowParent.transform.GetChild(i).gameObject;
        }

        // Debug: Log the new order of Shadows
        //Debug.Log("Updated Shadows Order:");
        //foreach (var shadow in Shadows)
        //{
        //    Debug.Log(shadow.name);
        //}
    }
}
