using UnityEngine;
using System.Collections;

public class EmitWelding : MonoBehaviour
{
    public GameObject particles;
	
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Weldeable")
        {
            /*Sigil effect - particle*/
            GameObject.Instantiate(particles, other.gameObject.transform.position, new Quaternion());
        }
    }
}
