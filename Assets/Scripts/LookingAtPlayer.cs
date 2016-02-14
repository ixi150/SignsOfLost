using UnityEngine;
using System.Collections;

public class LookingAtPlayer : MonoBehaviour
{
    static private Vector3 rotationFix = new Vector3(0, 180, 0);
    private GameObject player;
    
	void Awake ()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        Transform trans = this.transform;
        Vector3 playerPivot = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z); 
        trans.LookAt(playerPivot); //namierzanie konarami
        trans.Rotate(LookingAtPlayer.rotationFix);

        this.transform.rotation = trans.rotation;
    }
}
