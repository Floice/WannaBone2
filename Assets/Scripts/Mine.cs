using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float attackRange;
    private GameObject[] monsters;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //杀怪物
        monsters = GameObject.FindGameObjectsWithTag("monster");
        if (monsters != null)
        {
            foreach (GameObject monster in monsters)
            {
                //怪物要醒着
                if (monster.GetComponent<Monster>().state != 3)
                {
                    float distance = Vector3.Distance(transform.position, monster.transform.position);
                    if (distance <= attackRange)
                    {
                        monster.GetComponent<Monster>().changeToFlame();
                    }
                }
            }
        }
        //杀玩家
        players = GameObject.FindGameObjectsWithTag("player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                //狗要活着
                if (player.GetComponent<Dog>().state != 1)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance <= attackRange)
                    {
                        player.GetComponent<LoseCondition>().lose();
                    }
                }
            }
        }
    }
}
