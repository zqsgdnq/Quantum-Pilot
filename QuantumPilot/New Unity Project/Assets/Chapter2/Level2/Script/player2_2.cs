using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_2 :RewindPlayer
{
    public static bool dying;
    public List<string> deathList;
    public playerTrans1 trans1;

    public bool intaparea;
    public bool fireend;
    public bool indoor1area;

    public GameObject realtap;
    public GameObject water;
    public GameObject fire;
    public GameObject door1;

    public BagManager thisBag;

    public ToolItem tapTool;
    public ToolItem key1Tool;

    public Stack TimeBack2;

    public static int  PlayerStage;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerStage = 0;
        TimeBack2 = new Stack();
        thisBag = GameObject.Find("ToolBag").GetComponent<BagManager>();
        deathList = new List<string>();
        InitDeathList();
        trans1 = new playerTrans1();
        trans1.CreateTrans();
        InitRewind();
        dying = false;
        initTransition();
        InitTrans();
        InitGameObject();
    }
    public void initTransition()
    {
        intaparea = false;
        fireend = false;
        indoor1area = false;

    }

    public void InitGameObject()
    {
        realtap.SetActive(false);
        water.SetActive(false);
        fire.SetActive(true);

    }
    public void InitDeathList()
    {
        deathList.Add("egg");
        deathList.Add("fire");
        deathList.Add("grass");

    }
    public void InitTrans()
    {
        trans1.Birth.CurrentOperate = normalmove;
        trans1.ApplyTap.CurrentOperate = FallWater;
        trans1.FireStop.CurrentOperate = DeleteFire;
        trans1.OpenDoor1.CurrentOperate = opendoor1;



    }


   public void  UpdateTransition()
    {
        trans1.usingTap.ifTrans = (intaparea) && (Input.GetKeyDown(KeyCode.Q))&&(BagManager.currentCarry.ToolName=="tap");
        trans1.stopingfire.ifTrans = fireend;
            trans1.usingKey.ifTrans= (indoor1area) && (Input.GetKeyDown(KeyCode.Q)) && (BagManager.currentCarry.ToolName == "key1");

    }
    public void normalmove()
    {

    }
    public void FallWater()
    {
        water.SetActive(true);
        realtap.SetActive(true);
        thisBag.DeleteTool(tapTool);
        Invoke("SetFireEnd", 3f);
    }
    public void SetFireEnd()
    {
        fireend = true;
        
    }
    public void DeleteFire()
    {
        water.SetActive(false);
        fire.SetActive(false);
    }

    public void opendoor1()
    {
        thisBag.DeleteTool(key1Tool);
        Destroy(door1);
        CurrentStack = TimeBack2;
        PlayerStage = 1;
    }


    void Update()
    {
        RewindUpdate();
        if ((!playerRewind) && (!dying))
        {
            anim.SetBool("isQuantum", isQuantum);
            basicmove();
            UpdateTransition();
            trans1.Update();
        }
        
    }
    
    private void FixedUpdate()
    {
        RewindFixUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            isQuantum = true;

        }

        for(int i = 0; i < deathList.Count; i++)
        {

            if ((collision.gameObject.tag == deathList[i])&&(!isQuantum))
            {
                dying = true;
            }
        }


        if (collision.gameObject.name == "UseTap")
        {
            intaparea = true;

        }

        if (collision.gameObject.name == "usingKey1")
        {
            indoor1area = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            isQuantum = false;

        }

        if (collision.gameObject.name == "UseTap")
        {
            intaparea = false;

        }

        if (collision.gameObject.name == "usingKey1")
        {
            indoor1area = false;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < deathList.Count; i++)
        {

            if ((collision.gameObject.tag== deathList[i])&& (!isQuantum))
            {
                dying = true;
            }
        }
    }

}
