using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
    public float thrust_force = .001f;
    public float velocityx = 0;
    public float velocityy = 0;

    // Use this for initialization
    void Start () {
       
	
	}
	
	// Update is called once per frame
	void Update () {

        float net_forceX,net_forceY;

        net_forceX = thrust_value(1) + gravity(1);
        net_forceY = thrust_value(0) + gravity(0);

        print(net_forceY);
        velocityx = velocityx + net_forceX * Time.deltaTime;
        velocityy = velocityy + net_forceY * Time.deltaTime;

       
        transform.Translate(velocityx, 0 , velocityy, Space.World);


    }



    public float thrust_value(int x)
    {
        float forceX = 0;
        float forceY = 0;

        if (Input.GetKey("up"))
            {
          
                forceY = thrust_force;

            }
            if (Input.GetKey("down"))
            {
                forceY = -thrust_force;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                forceX = thrust_force;

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                forceX = -thrust_force;
            }

        if (x == 1)
        {
           return forceX;
        }
        if (x == 0)
        {
            return forceY;
        }

        else return 0;

    }
    public float gravity(int x)
    {

        //for gravity
        return 0;
    }
}
