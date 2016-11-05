using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
    public float thrust_force = .01f;
    public float velocityx = 0;
    public float velocityy = 0;

    // Use this for initialization
    void Start () {
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("gravity");
    }
	
	// Update is called once per frame
	void Update () {
        float net_forceX,net_forceY;
        net_forceX = thrust_value(1) + gravity(1);
        net_forceY = thrust_value(0) + gravity(0);
        // 0 : y dircn. 1: x dircn
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
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("gravity");
        float force = 0.0f;
        foreach (GameObject planet in planets)
        {
            float distance = getDistance(x, planet.transform.position, this.transform.position);
            float massEquivalent = planet.GetComponent<Collider>().bounds.size.x;
            float forceConstant = 3.0f;
            if (distance > massEquivalent)
            {
                force = massEquivalent * forceConstant / distance;
            }
            else
            {
                Destroy(this);
            } 
            if(x == 0)
            {
                force = force * (planet.transform.position.z - this.transform.position.z) / Mathf.Sqrt(distance);
            }
            else
            {
                force = force * (planet.transform.position.x - this.transform.position.x) / Mathf.Sqrt(distance);
            }
            print(force);
        }
        return force;
    }
    public float getDistance(int option, Vector3 x, Vector3 y)
    {
        float a = (x.x - y.x)*(x.x - y.x);
        float c = (x.z - y.z)*(x.z - y.z);
        return (a + c);
    }
}
