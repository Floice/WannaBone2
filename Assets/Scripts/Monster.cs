using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{   
    public Sprite asleep;
    public Sprite awake;
    public Sprite charmed;
    public Sprite flame;
    public float speed;            //׷���ʱ���ƶ��ٶ�
    public int state = 0;          //0˯��,1����,2�Ȼ�,3����
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
                    if (player.name == "��")
                    {
                        //ɱ�󹷣���Ҫ����
                        if (player.GetComponent<Dog>().state != 1)
                        {
                            float distance = Vector3.Distance(transform.position, player.transform.position);
                            if (distance <= attackRange)
                            {
                                player.GetComponent<LoseCondition>().lose();
                            }
                        }
                    }
                    if (player.name == "С��")
                    {
                        //��С���Ȼ�
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
                    if (player.name == "С��")
                    {
                        //���Ȼ�
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
