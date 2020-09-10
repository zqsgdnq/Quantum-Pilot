using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollstar : MonoBehaviour
{
    // Start is called before the first frame update

    public float translate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translate= Time.deltaTime * 10;

        transform.Translate(-translate, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BW")
        {
            Destroy(this.gameObject);
        }

    }
}
