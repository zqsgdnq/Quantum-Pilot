using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausepanel;
    public GameObject continuebtn;
    public GameObject quit;
    public GameObject pausebtn;
    // Start is called before the first frame update
    void Start()
    {
        pausebtn.GetComponent<Button>().onClick.AddListener(PauseGame);
       continuebtn.GetComponent<Button>().onClick.AddListener(Continue);
       quit.GetComponent<Button>().onClick.AddListener(QuitGame);
       
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Continue()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scene00");
    }

    public void PauseGame()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0;
    }

}
