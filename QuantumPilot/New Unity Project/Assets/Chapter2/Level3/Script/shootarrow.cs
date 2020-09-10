using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootarrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(10f, 0, 0) * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "door2") || (collision.gameObject.name == "player"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "pole")
        {

            Destroy(gameObject);
            Debug.Log("pole");
        }


        if(collision.gameObject.name == "warning")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
