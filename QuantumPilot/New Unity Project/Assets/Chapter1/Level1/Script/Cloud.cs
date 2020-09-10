using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public bool collideLeft;

    public star star;
    //public bool collideRight;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateStar", 3f, 1f);
        collideLeft = false;
       // collideRight = false;
    }

    // Update is called once per frame
    void Update()
    {
       

       
        
        if (collideLeft==false) { 
            transform.Translate(new Vector3(-2f, 0, 0) * Time.deltaTime, Space.World);
            
            
         }
        

        if (collideLeft)
        {
            transform.Translate(new Vector3(2f, 0, 0) * Time.deltaTime, Space.Self);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
     if(other.gameObject.name=="leftCor")
        {
            Debug.Log("leftcorner");
           

        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "leftCor")
        {
            Debug.Log("leftcorner");
 collideLeft = true;
        }

        if (collision.gameObject.name == "rightCor")
        {
            Debug.Log("rightcorner");
          //  collideRight = true;
            collideLeft = false;
        }

    }

    public void CreateStar() {

        star instanceStar = Instantiate(star, transform.position, transform.rotation);
       
    }
}
