using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level3 : MonoBehaviour
{
    public int levelIndex;
    public GameObject levellock;
    public GameObject levelBtn;
    public int lockstate;
    public string SceneName;
    void Start()
    {
        levelIndex = 3;
        SceneName = "Intro3";
        
        levelBtn.GetComponent<Button>().onClick.AddListener(GotoScene);

    }

    // Update is called once per frame
    void Update()
    {
        lockstate = PlayerPrefs.GetInt("level" + levelIndex);
        if (lockstate == 1)
        {

            levellock.SetActive(false);
        }
    }

    public void GotoScene()
    {
        if (lockstate == 1)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
