using UnityEngine;
using System.Collections;

public class doorOpener : MonoBehaviour
{
    public GameObject door;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.gameObject.tag == "Player")
        {
            triggered = true;
            door.GetComponent<Animator>().SetBool("isOpen", true);
            GameObject.Destroy(gameObject);
        }
    }
}
