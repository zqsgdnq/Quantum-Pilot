using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewindspped : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> numImage;
    public Sprite num1;
    public Sprite num2;
    public Sprite num3;
    public Sprite num4;

    public GameObject shownum;
    public Sprite currentImage;
    public int currentIndex;

    void Start()
    {
        currentIndex = 1;
        numImage.Add(num1);
        numImage.Add(num2);
        numImage.Add(num3);
        numImage.Add(num4);
        currentImage = shownum.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        shownum.GetComponent<Image>().sprite= numImage[currentIndex];
        ChangeSpeed();
    }

    public void ChangeSpeed()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (RewindControl2_3.TimeBackSpeed < 8)
            {
                RewindControl2_3.TimeBackSpeed = RewindControl2_3.TimeBackSpeed + 2;
                currentIndex++;
            }

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (RewindControl2_3.TimeBackSpeed >2)
            {
                RewindControl2_3.TimeBackSpeed = RewindControl2_3.TimeBackSpeed - 2;
                currentIndex--;
            }

        }

    }



}
