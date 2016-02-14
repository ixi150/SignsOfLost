using UnityEngine;
using System.Collections;

public class doorUnlocker : MonoBehaviour
{
    public GameObject door;
    public GameObject orb;
    public GameObject darkness;
    //public GameObject particles;

    private static float timerMax = 2.5f;
    public float timer = timerMax;
    private bool triggered = false;
    private bool wasHit = false;

    void Start()
    {
        foreach (GameObject tree in GameObject.FindGameObjectsWithTag("Tree"))
            tree.name = "Tree";
    }

    void LateUpdate()
    {
        if (wasHit)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < timerMax)
        {
            timer += Time.deltaTime;
        }

        if (!triggered && timer <= 0)
        {
            triggered = true;
            door.GetComponent<Animator>().SetBool("isOpen", true);
            orb.SetActive(true);
            darkness.SetActive(!darkness.active);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>().canEmit = true;
            GameObject.Destroy(gameObject);
        }

        wasHit = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "EmitStream")
        {
            wasHit = true;

            /*Sigil effect - particle*/
            //GameObject.Instantiate(particles, other.gameObject.transform.position, new Quaternion());
        }
    }
}
