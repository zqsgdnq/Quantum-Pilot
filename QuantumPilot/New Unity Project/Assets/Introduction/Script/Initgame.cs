using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Initgame : MonoBehaviour
{
    public GameObject StartBtn;
    void Start()
    {
        PlayerPrefs.SetInt("level1" , 1);
        PlayerPrefs.SetInt("level2" , 0);
        PlayerPrefs.SetInt("level3" , 0);
        PlayerPrefs.SetInt("level4" , 0);
        StartBtn = GameObject.Find("BeginBtn");
        StartBtn.GetComponent<Button>().onClick.AddListener(GotoScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoScene()
    {
       
       
            SceneManager.LoadScene("Scene00");
       
    }
}
