using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Purchased", 1);
        Invoke("wait1", 0.2f);
    }

    // Update is called once per frame
    void wait1()
    {
        SceneManager.LoadScene("Selection");
    }
}
