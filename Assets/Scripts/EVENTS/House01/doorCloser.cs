using UnityEngine;
using System.Collections;

public class doorCloser : MonoBehaviour
{
    public GameObject door;
    public GameObject emitSigil;

    private bool triggered = false;
	
    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.gameObject.tag == "Player" && door.GetComponent<Animator>().GetBool("isOpen"))
        {
            triggered = true;
            door.GetComponent<Animator>().SetBool("isOpen", false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>().sigills[1] = emitSigil;
            GameObject.Destroy(gameObject);
        }
    }
}
