using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class win3 : MonoBehaviour
{
    public GameObject winimage;
    public int nextlevel;
    public GameObject backbtn;
    void Start()
    {
        backbtn = GameObject.Find("backbtn");

        winimage.SetActive(false);
        nextlevel = 4;

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
