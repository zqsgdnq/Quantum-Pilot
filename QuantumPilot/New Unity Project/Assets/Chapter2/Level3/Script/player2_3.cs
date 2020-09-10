using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_3 : RewindPlayer
{
    public static bool dying;
    public BagManager thisBag;
    public PlayerTrans3 trans1;
    
    public List<string> deathList;
    

    public bool indoor1area;
    public bool instage1area;
    public bool collideArrow;
    public bool inshootarea;
    public bool indoor2area;

    public GameObject door1;
    public GameObject door2;
    public GameObject stage1;
    public GameObject ChrisTree;
    public GameObject shootarea;

    public ToolItem key1;
    public ToolItem key2;
    public ToolItem arrow;

    public Stack TimeBack2;

    public static int PlayerStage;
    public arrowpick arrowcollect;

    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        dying = false;
        TimeBack2 = new Stack();
        deathList = new List<string>();
        thisBag = GameObject.Find("ToolBag").GetComponent<BagManager>();
        InitRewind();
        InitDeathList();
        PlayerStage = 0;
        trans1 = new PlayerTrans3();
        trans1.CreateTrans();
        initTransition();
        InitTrans();

    }

    public void initTransition()
    {
        indoor1area = false;
        instage1area = false;
        collideArrow = false;
        inshootarea = false;
        indoor2area = false;
    }

    public void InitTrans()
    {
        trans1.Birth.CurrentOperate = normalmove;
        trans1.ApplyKey1.CurrentOperate = opendoor1;
        trans1.GetStage1.CurrentOperate = changestage1;
        trans1.GetStage2.CurrentOperate = changestage2;
        trans1.Shoot.CurrentOperate = startshoot;
        trans1.ApplyKey2.CurrentOperate = opendoor2;





    }
    // Update is called once per frame

    public void normalmove()
    {

    }

    public void opendoor1()
    {
        thisBag.DeleteTool(key1);
        Destroy(door1);
       
    }

    public void changestage1()
    {
        CurrentStack = TimeBack2;
        PlayerStage = 1;
    }

    public void changestage2()
    {
        PlayerStage = 2;
    }

    public void startshoot()
    {
       PlayerStage = 3;
        thisBag.DeleteTool(arrow);

    }

    public void opendoor2()
    {

        Destroy(door2);
    }

    public void UpdateTransition()
    {
        trans1.usingkey1.ifTrans= (indoor1area) && (Input.GetKeyDown(KeyCode.Q)) && (thisBag.GetCurrentCarryName() == "key1");
        trans1.outdoor.ifTrans = (instage1area);
        trans1.GetArrow.ifTrans = collideArrow;
        trans1.usingArrow.ifTrans = (inshootarea) && (Input.GetKeyDown(KeyCode.Q)) && (thisBag.GetCurrentCarryName() == "arrow");
        trans1.usingkey2.ifTrans=(indoor2area) && (Input.GetKeyDown(KeyCode.Q))&& (thisBag.GetCurrentCarryName() == "key2");

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
    public void InitDeathList()
    {
        deathList.Add("alien");
        deathList.Add("arrowcol");

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

        for (int i = 0; i < deathList.Count; i++)
        {

            if ((collision.gameObject.tag == deathList[i]) && (!isQuantum))
            {
                dying = true;
            }
        }
        if (collision.gameObject.name == "doorarea1")
        {
            indoor1area = true;

        }

        if (collision.gameObject.name == "doorarea2")
        {
            indoor2area = true;

        }


        if (collision.gameObject.name == "stage1")
        {
            instage1area = true;
        }

        if (collision.gameObject.tag == "arrowpick")
        {

            collideArrow = true;


        }

        if (collision.gameObject.name== "shootarea")
        {
            //Debug.Log("shootarea");
            inshootarea = true;


        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            isQuantum = false;

        }

        if (collision.gameObject.name == "doorarea1")
        {
            indoor1area = false;
        }

        if (collision.gameObject.name == "doorarea2")
        {
            indoor2area = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < deathList.Count; i++)
        {

            if (collision.gameObject.tag == deathList[i])
            {
                dying = true;
            }
        }

        if (PlayerStage == 1) { 
            
            if (collision.gameObject.name == "ChrisTree")
        {
                arrowpick instanceAlien = Instantiate(arrowcollect, ChrisTree.transform.position, ChrisTree.transform.rotation);

            }
        }
        
        
    }
}
