using UnityEngine;
using System.Collections;

public class thrust : main
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        int force = 0;

        if (Input.GetKey("up"))
        {
            force = 1;

        }
        if (Input.GetKey("down"))
        {
            force = 2;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force = 3;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force = 4;
        }


     

    }


}