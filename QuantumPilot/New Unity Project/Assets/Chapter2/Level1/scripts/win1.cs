using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class win1 : MonoBehaviour
{
    public GameObject winimage;
    public int nextlevel;
    public GameObject backbtn;
    void Start()
    {
        backbtn = GameObject.Find("backbtn");

        winimage.SetActive(false);
        nextlevel = 2;

        backbtn.GetComponent<Button>().onClick.AddListener(BackMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Scene00");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winimage.SetActive(true);
            PlayerPrefs.SetInt("level" + nextlevel, 1);
        }
    }
}
