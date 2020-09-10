using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pole : MonoBehaviour
{
    // Start is called before the first frame update
    public polemoveTrans poleTrans;

    public bool begin;
    public bool trigger1;
    public bool trigger2;
    public bool delay1;
    public bool delay2;
    void Start()
    {
        poleTrans = new polemoveTrans();
        poleTrans.CreateTrans();
        InitTrans();
        begin = false;
        trigger1 = false;
        trigger2 = false;
        delay1 = false;
        delay2 = false;

        

    }

    public void InitTrans()
    {
        poleTrans.Birth.CurrentOperate = BirthMove;
        poleTrans.Trail1.CurrentOperate = MoveDown;
        poleTrans.Wait1.CurrentOperate = InWait1;
        poleTrans.Trail2.CurrentOperate = MoveUp;
        poleTrans.Wait2.CurrentOperate = InWait2;

    }

    public void BirthMove()
    {

    }

    public void MoveDown()
    {
        transform.Translate(new Vector3(0, -3, 0) * Time.deltaTime);
        delay1 = false;
        delay2 = false;
    }

    public void MoveUp()
    {
        transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime);
        delay1 = false;
        delay2 = false;
    }
    public void InWait1()
    {

        Invoke("ChangeWait1", 5f);
    }

    public void InWait2()
    {
        Invoke("ChangeWait2", 5f);

    }


    public void ChangeWait1()
    {
        delay1 = true;
    }
    public void ChangeWait2()
    {
        delay2 = true;

    }

    public void UpdateTransition()
    {
        poleTrans.StartMove.ifTrans = begin;
        poleTrans.OnCorner1.ifTrans = trigger1;
        poleTrans.EndWait1.ifTrans = delay1;
        poleTrans.OnCorner2.ifTrans = trigger2;
        poleTrans.EndWait2.ifTrans = delay2;

    }
    // Update is called once per frame
    void Update()
    {
        if (player2_3.PlayerStage ==3)
        {
            begin = true;
        }

        UpdateTransition();
        poleTrans.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "polebelow")
        {
            trigger1 = true;
        }

        if (collision.gameObject.name == "poleup")
        {
            trigger2 = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "polebelow")
        {
            trigger1 = false;
        }

        if (collision.gameObject.name == "poleup")
        {
            trigger2 = false;
        }
    }

   
}
