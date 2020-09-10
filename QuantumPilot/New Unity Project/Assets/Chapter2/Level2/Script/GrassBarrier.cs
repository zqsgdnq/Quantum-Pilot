using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,3,0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            Destroy(gameObject);
        }

        if (collision.gameObject.name == "bowl"|| collision.gameObject.name == "GrassTop")
        {

            Destroy(gameObject);
        }

    }
}
