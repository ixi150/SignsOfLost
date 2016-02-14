using UnityEngine;
using System.Collections;

public class SigillEffect : MonoBehaviour
{
    public float timeToDie;
    void Awake()
    {
        GameObject.Destroy(this.gameObject, this.timeToDie);
    }
}
