using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornGrass : MonoBehaviour
{

    public ForthMoveTrans GrassTrans;

    public bool begin;
    public bool trigger1;
    public bool trigger2;

    public GrassBarrier grass;

    // Start is called before the first frame update
    void Start()
    {
        GrassTrans = new ForthMoveTrans();
        GrassTrans.CreateTrans();
        InitTrans();
        begin = false;
        trigger1 = false;
        trigger2 = false;

        InvokeRepeating("CreateGrass", 1f, 1f);

    }


    public void InitTrans()
    {
        GrassTrans.Birth.CurrentOperate = BirthMove;
        GrassTrans.Trail1.CurrentOperate = MoveLeft;
        GrassTrans.Trail2.CurrentOperate = MoveRight;

    }

    public void BirthMove()
    {

    }

    public void MoveLeft()
    {
        transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);
    }


    public void UpdateTransition()
    {
        GrassTrans.StartMove.ifTrans = begin;
        GrassTrans.OnCorner1.ifTrans = trigger1;
        GrassTrans.OnCorner2.ifTrans = trigger2;

    }
    // Update is called once per frame
    void Update()
    {
        if (player2_2.PlayerStage == 1)
        {
            begin = true;
        }

        UpdateTransition();
        GrassTrans.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GrassLeft")
        {
            trigger1 = true;
        }

        if (collision.gameObject.name == "GrassRight")
        {
            trigger2 = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GrassLeft")
        {
            trigger1 = false;
        }

        if (collision.gameObject.name == "GrassRight")
        {
            trigger2 = false;
        }
    }

    public void CreateGrass()
    {
        if (player2_2.PlayerStage == 1) { 
            GrassBarrier instanceGrass = Instantiate(grass, transform.position,transform.rotation);
        }
       
       


    }
}
