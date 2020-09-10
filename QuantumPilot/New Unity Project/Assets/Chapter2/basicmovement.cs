using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicmovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void basicmove()
    {

        float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(horizontal);
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;

        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);
        // Vector2 position = transform.position;
        position.y = position.y + 0.1f * vertical;

        transform.position = position;
        

    }

    public void basicmove_Anim()
    {

        float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(horizontal);
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal*0.1f * 0.1f * 0.1f * 0.1f * 0.1f * 0.1f * 0.1f;

        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);
        // Vector2 position = transform.position;
        position.y = position.y + 0.1f * vertical*0.1f * 0.1f * 0.1f * 0.1f * 0.1f * 0.1f * 0.1f;

        transform.position = position;
        if (horizontal > 0)
        {
            transform.Rotate(0, -45, 0, Space.Self);
        }

    }


}
