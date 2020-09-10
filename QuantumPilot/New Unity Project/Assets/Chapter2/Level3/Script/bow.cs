using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{

    public shootarrow newshoot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateShoot", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateShoot()
    {
        if (player2_3.PlayerStage == 3) 
        {
            shootarrow instanceShoot = Instantiate(newshoot, transform.position, transform.rotation); 
        }
        

    }
}
