using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

    public Transform player;

    public float distance = 2f;
    public float height = 3f;

	void Start () {
        player = GameObject.Find("Player").transform;
        this.transform.eulerAngles = new Vector3(50, 0, 0);
	}
	
	void Update () {
        this.transform.position = new Vector3(player.position.x, player.position.y + height, player.position.z - distance);
	}
}
