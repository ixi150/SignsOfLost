using UnityEngine;
using System.Collections;

public class CrossHairGlow : MonoBehaviour
{
    private Animator animator;
    private SigilSpawning sigilSpawning;

    void Awake ()
    {
        animator = GetComponent<Animator>();
        sigilSpawning = GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>();
    }
	
	void Update ()
    {
        animator.SetBool("glow", shouldGlow());
    }

    private bool shouldGlow()
    {
        var x = Screen.width / 2; 
        var y = Screen.height / 2;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        if (Physics.Raycast(ray, out hit, sigilSpawning.sigillingRange, sigilSpawning.layerMask))
        {
            GameObject currentObjectOver = hit.collider.gameObject;
            if (currentObjectOver.layer == LayerMask.NameToLayer("Sigillable"))
                return true;
        }
        return false;
    }
}
