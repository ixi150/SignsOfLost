using UnityEngine;
using System.Collections;

public class WispMovement : MonoBehaviour
{
    public float speed = 18f;

    private GameObject player;
    private bool following = true;
    private Rigidbody rb;

	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
	    if (following)
        {
            if (rb.velocity.magnitude < speed)
            { 
                Vector3 vector = player.transform.position - transform.position;
                Vector3 delta = vector.normalized * speed * Time.deltaTime;

                rb.AddForce(delta);
                //transform.position = transform.position + delta;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            following = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            following = true;
    }
}
