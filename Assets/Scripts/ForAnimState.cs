using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ForAnimState : MonoBehaviour
{
    // Start is called before the first frame update
    void OffGameObj()
    {
        if (SceneManager.GetActiveScene().name == "Fruit" || SceneManager.GetActiveScene().name == "Vegatables")
        {
            SetFruits.ins.EndCall();
        }
        else if (SceneManager.GetActiveScene().name == "FruitSounds" || SceneManager.GetActiveScene().name == "VegetablesSounds" || SceneManager.GetActiveScene().name == "BodyPartsSounds")
        {
            FindObject.ins.ForBallon();
        }
        else if (SceneManager.GetActiveScene().name == "AnimalSounds")
        {
            FindAnimals.ins.ForBallon();
        }
        else if (SceneManager.GetActiveScene().name == "ShapeSounds")
        {
            FindShape.ins.ForBallon();
        }
        else if (SceneManager.GetActiveScene().name == "Objects")
        {
            SelectObjects.ins.ForBallon();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //StartCoroutine(OffChilds());
    }
    void OffPuzzle()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator OffChilds()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        if (SceneManager.GetActiveScene().name == "Fruit" || SceneManager.GetActiveScene().name == "Vegatables")
        {
            SetFruits.ins.EndCall();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void OffLostGameObj()
    {
        StartCoroutine(OffLostChilds());
    }
    IEnumerator OffLostChilds()
    {
        yield return new WaitForSeconds(0.2f);
        transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        //if (SceneManager.GetActiveScene().name == "Fruit" || SceneManager.GetActiveScene().name == "Vegatables")
        //{
        //    SetFruits.ins.EndCall();
        //}
        //else
        //{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }
    public void WrongSound()
    {
        SoundManager.instance.PlayEffect_Complete(18);
    }
    public void RightSound()
    {
        SoundManager.instance.PlayEffect_Complete(19);
    }
    public void AnimOff()
    {
        GetComponent<Animator>().enabled = false;
    }
    public void AnimOffInapp()
    {
        GetComponent<Animator>().enabled = false;
      transform.parent.parent.transform.GetComponent<ScrollRect>().enabled = true;
    }
}