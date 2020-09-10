using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public bool havecollision;
    // Start is called before the first frame update
    void Start()
    {
        havecollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -3f, 0) * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BW")
        {
            Destroy(this.gameObject);
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        if ((collision.gameObject.name == "player") && (havecollision == false) && (playermove.quantumState == false))
        {

            Destroy(this.gameObject);
            havecollision = true;
            playermove.lifenum --;
            Debug.Log(playermove.lifenum);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BW")
        {
            Destroy(this.gameObject);
        }


    }
}
