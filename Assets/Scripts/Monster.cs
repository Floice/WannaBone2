using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{   
    public Sprite asleep;
    public Sprite awake;
    public Sprite charmed;
    public Sprite flame;
    public float speed;            //追玩家时的移动速度
    public int state = 0;          //0睡着,1醒着,2魅惑,3死亡
    public float attackRange;
    public bool isAttacking = false;
    public Coroutine lastBark;

    private GameObject[] players;

    void Update()
    {
        if (state == 1)
        {
            players = GameObject.FindGameObjectsWithTag("player");
            if (players != null)
            {
                foreach (GameObject player in players)
                {
                    if (player.name == "大狗")
                    {
                        //杀大狗，狗要活着
                        if (player.GetComponent<Dog>().state != 1)
                        {
                            float distance = Vector3.Distance(transform.position, player.transform.position);
                            if (distance <= attackRange)
                            {
                                player.GetComponent<LoseCondition>().lose();
                            }
                        }
                    }
                    if (player.name == "小狗")
                    {
                        //被小狗魅惑
                        if (player.GetComponent<Dog>().state != 1)
                        {
                            float distance = Vector3.Distance(transform.position, player.transform.position);
                            if (distance <= attackRange)
                            {
                                changeToCharmed();
                            }
                        }
                    }
                }
            }
        }
        else if (state == 2)
        {
            players = GameObject.FindGameObjectsWithTag("player");
            if (players != null)
            {
                foreach (GameObject player in players)
                {
                    if (player.name == "小狗")
                    {
                        //解魅惑
                        if (player.GetComponent<Dog>().state != 1)
                        {
                            float distance = Vector3.Distance(transform.position, player.transform.position);
                            if (distance > attackRange)
                            {
                                changeToAwake();
                            }
                        }
                    }
                }
            }
        }
    }
    public void changeToAsleep()
    {
        GetComponent<SpriteRenderer>().sprite = asleep;
        transform.GetChild(0).gameObject.SetActive(false);
        state = 0;
    }
    public void changeToAwake()
    {
        GetComponent<SpriteRenderer>().sprite = awake;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0, 0, 0.2f);
        state = 1;
    }
    public void changeToCharmed()
    {
        GetComponent<SpriteRenderer>().sprite = charmed;
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color= new Color(0, 0.8f, 0, 0.2f);
        state = 2;
    }
    public void changeToFlame()
    {
        GetComponent<SpriteRenderer>().sprite = flame;
        transform.GetChild(0).gameObject.SetActive(false);
        isAttacking = false;
        state = 3;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
