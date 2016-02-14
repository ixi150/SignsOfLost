using UnityEngine;
using System.Collections;

public class TV_fader : MonoBehaviour
{
    private Animator animator;
    private bool faded = false;
	
	void Start ()
    {
        animator = GetComponent<Animator>();
	}

    void LateUpdate()
    {
        animator.SetBool("dark", faded);
        faded = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "AbsorbSigill")
        {
            faded = true;
        }
    }
}
