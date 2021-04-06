using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerPos;
    public GameObject bonus;
    public int hp = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos)
        {
            transform.LookAt(playerPos);
            transform.position += transform.forward * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (hp > 1) hp--;
            else
            {
                if (Random.Range(0, 5) == 1) Instantiate(bonus, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
