using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class main : MonoBehaviour {
    public float thrust_force = 5f;
    public float velocityx = 0;
    public float velocityy = 0;
    public float fuel = 500.0f;
    public GameObject button;
    public GameObject target;
    public Scrollbar healthbar;
 
    // Use this for initialization
   
         
         void Start () {

        button.SetActive(false);

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
        if (getDistance(target.transform.position, this.transform.position)<2)
           {
            fuel = 35;
           int scene1 = SceneManager.GetActiveScene().buildIndex;
            if (scene1 < 3)
            {
             scene1++; }
            SceneManager.LoadScene(scene1);    
           }
        healthbar.size = fuel / 35;
    }

    public float thrust_value(int x)
    {
        if(fuel <= 0)
        {
            button.SetActive(true);
            return 0.0f;
        }
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
            fuel = fuel - Mathf.Abs(forceX);
            return forceX;
        }
        if (x == 0)
        {
            fuel = fuel - Mathf.Abs(forceY);
            return forceY;
        }
        else return 0;

    }
    public float gravity(int x)
    {
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("gravity");
        float finalForce = 0.0f;
        foreach (GameObject planet in planets)
        {
            float force = 0.0f;
            float distance = getDistance( planet.transform.position, this.transform.position);
            float massEquivalent = planet.GetComponent<Collider>().bounds.size.x;
            float forceConstant = 3.0f;
            if (distance > massEquivalent)
            {
                force = massEquivalent * forceConstant / distance;
            }
            else
            {
                Destroy(this);
                button.SetActive(true);

            } 
            if(x == 0)
            {
                force = force * (planet.transform.position.z - this.transform.position.z) / Mathf.Sqrt(distance);
            }
            else
            {
                force = force * (planet.transform.position.x - this.transform.position.x) / Mathf.Sqrt(distance);
            }
            finalForce += force;
        }
        return finalForce;
    }
    public float getDistance(Vector3 x, Vector3 y)
    {
        float a = (x.x - y.x)*(x.x - y.x);
        float c = (x.z - y.z)*(x.z - y.z);
        return (a + c);
    }

   
}
