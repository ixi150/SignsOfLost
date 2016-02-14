using UnityEngine;
using System.Collections;

public class SigilSpawning : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject[] sigillPrefabs;
    public GameObject[] sigills = new GameObject[] { null, null, null };
    public GameObject sigillEffect;
    public float sigillingRange = 5f;
    public bool canEmit = false;

    private GameObject player;


    void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () 
    {
        int limit = 1;
        if (canEmit)
            limit = 3;
        for (int i = 0; i<limit; i++)
            if (Input.GetMouseButtonDown(i))
                makeSigill(i);

        /*reset sigills*/
        if (Input.GetButtonDown("Reset") && canEmit)
        {
            foreach (GameObject sigill in sigills)
            {
                if (sigill != null)
                    destroySigill(sigill);
            }
            sigills = new GameObject[] { null, null, null };
        }
    }

    void makeSigill(int prefabIndex)
    {
        var x = Screen.width / 2;
        var y = Screen.height / 2;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        if (Physics.Raycast(ray, out hit, sigillingRange, layerMask))
        {
            GameObject currentObjectOver = hit.collider.gameObject;
            //Debug.Log(currentObjectOver);
            //Debug.DrawLine(ray.origin, hit.point);
            if (currentObjectOver.layer == LayerMask.NameToLayer("Sigillable"))
            {
                GameObject sigill = GameObject.Instantiate(sigillPrefabs[prefabIndex], hit.point, currentObjectOver.transform.rotation) as GameObject;

                Transform trans = sigill.transform;
                Vector3 playerPivot = new Vector3(player.transform.position.x, sigill.transform.position.y, player.transform.position.z);
                trans.LookAt(playerPivot); //namierzanie konarami

                float yRot = currentObjectOver.transform.rotation.eulerAngles.y;
                float xRot = 0f;
                if (currentObjectOver.tag == "Floor")
                {
                    xRot = 90f;
                    yRot = trans.rotation.eulerAngles.y + 180;
                }
                sigill.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
                sigill.transform.Translate(0, 0, -0.01f, sigill.transform);

                if (sigills[prefabIndex] != null)
                    destroySigill(sigills[prefabIndex]);
                sigills[prefabIndex] = sigill;

                /*Sigil effect - particle*/
                GameObject.Instantiate(sigillEffect, sigill.transform.position, sigill.transform.rotation);

                /*GLOWING*/
                bool shouldGlow = false;
                Sigillable sigillable = currentObjectOver.GetComponent<Sigillable>();
                switch (prefabIndex)
                {
                    case 0:
                        shouldGlow = sigillable.Absorbable;
                        break;
                    case 1:
                        shouldGlow = sigillable.Emitable;
                        break;
                    case 2:
                        shouldGlow = sigillable.Modifyable;
                        break;
                }
                sigill.GetComponent<Animator>().SetBool("glow", shouldGlow);
            }
        }
    }

    void destroySigill(GameObject sigill)
    {
        sigill.GetComponent<Animator>().SetTrigger("die");
        ParticleSystem emiterParticle = null;
        ParticleSystem[] parSysArray = sigill.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem parSys in parSysArray)
        {
            if (parSys != null)
                emiterParticle = parSys;
        }
        emiterParticle = sigill.gameObject.GetComponentInChildren<ParticleSystem>();
        if (emiterParticle != null)
        {
            emiterParticle.enableEmission = false;
            emiterParticle.emissionRate = 0;
        }
        sigill.GetComponent<BoxCollider>().enabled = false;
        GameObject.Destroy(sigill, 10f);
    }
}
