using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Introduce2 : MonoBehaviour
{
    public List<GameObject> panellist;
    public GameObject panel1;
    public GameObject panel2;
    public int currentIndex;
    public GameObject next;
    public GameObject pre;
    public GameObject playbtn;
    public int pagenum;
    // Start is called before the first frame update
    void Start()
    {
        panel1 = GameObject.Find("Panel1");
        panel2 = GameObject.Find("Panel2");
        next = GameObject.Find("next");
        pre = GameObject.Find("pre");
        playbtn = GameObject.Find("playbtn");
        panellist = new List<GameObject>();
        panellist.Add(panel1);
        panellist.Add(panel2);
        currentIndex = 0;
        pagenum = panellist.Count;
        next.GetComponent<Button>().onClick.AddListener(nextpage);
        pre.GetComponent<Button>().onClick.AddListener(prepage);
        playbtn.GetComponent<Button>().onClick.AddListener(playgame);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < panellist.Count; i++)
        {
            if (i != currentIndex)
            {
                panellist[i].SetActive(false);
            }
            else
            {
                panellist[i].SetActive(true);
            }

        }
    }


    public void nextpage()
    {
        if (currentIndex < (pagenum - 1))
        {
            currentIndex++;
        }



    }

    public void prepage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
    }

    public void playgame()
    {
        SceneManager.LoadScene("2_1");
    }
}
