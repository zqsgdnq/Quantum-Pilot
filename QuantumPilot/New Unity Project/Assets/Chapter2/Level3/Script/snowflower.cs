using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowflower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -3f, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "snowbottom")|| (collision.gameObject.tag == "alien"))
        {
            Destroy(gameObject);
        }
    }
}
