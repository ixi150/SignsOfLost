using UnityEngine;
using System.Collections;

public class SigillAbsorb : MonoBehaviour
{
    public GameObject emiter;

    private Animator animator;
    private SigilSpawning sigilSpawning;
    private ParticleSystem emiterParticle;

    void Awake()
    {
        animator = GetComponent<Animator>();
        sigilSpawning = GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>();
        emiterParticle = emiter.GetComponent<ParticleSystem>();
        Balancer.setUpParticleSystem(emiterParticle);
    }

    void Update()
    {
        bool shouldEmit = false;
        bool glow = animator.GetBool("glow");
        if (glow)
        {
            if (sigilSpawning.sigills[2] == null)
            {
                if (sigilSpawning.sigills[1] != null)
                {
                    emiter.transform.LookAt(sigilSpawning.sigills[1].transform);
                    shouldEmit = true;
                }
            }
            else
            {
                emiter.transform.LookAt(sigilSpawning.sigills[2].transform);
                shouldEmit = true;
            }
        }

        emiterParticle.enableEmission = shouldEmit;
    }
}
