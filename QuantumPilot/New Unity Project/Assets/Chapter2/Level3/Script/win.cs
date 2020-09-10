using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject winimage;
    public GameObject backbtn;
    void Start()
    {
        winimage.SetActive(false);
        backbtn = GameObject.Find("backbtn");
        backbtn.GetComponent<Button>().onClick.AddListener(BackMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winimage.SetActive(true);
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Scene00");

    }
}
