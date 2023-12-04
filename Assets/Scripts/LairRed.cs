using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LairRed : MonoBehaviour
{
    public GameObject monster;
    public float moveSpeed; //�����ƶ��ٶ�
    public float callInterval; //�����ٻ�Ƶ��
    public float pauseTime; //������ͣƵ��
    [Tooltip("1��������\n2������\n3������\n4������\n5������\n6�����������")]
    public int type;
    public float time=0;   //��ʱ��
    public bool isup = false;

    //private bool isRunning = false;
    private bool down = false;
    private GameObject spawnedMonster;
    private bool hasCreated=false;
    private OrderController orderController;
    // Start is called before the first frame update
    void Start()
    {
        orderController = FindObjectOfType<OrderController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (type == 6)//������³�Ѩ
        {
            if (isRunning == false)
            {
                if (orderController.isRunning == true)
                {
                    isRunning = true;
                    if (Random.Range(0, 2) == 0)
                        {
                            isup = true;
                        }
                    else
                        {
                            isup = false;
                        }
                }
            }
            else
            {
                if (orderController.isRunning == false)
                {
                    isRunning = false;
                }
            }
        }*/
        

        if (orderController.isRunning == true)
        {
            time += Time.deltaTime;

            if (time > callInterval - pauseTime && hasCreated == false)
            {
                spawnedMonster = Instantiate(monster, transform.position, Quaternion.identity, transform);
                spawnedMonster.SetActive(true);
                hasCreated = true;
            }
            else if(time > callInterval)
            {
                switch (type)
                {
                    case 1:
                        if (down == false)
                        {
                            StartCoroutine(MoveUp(spawnedMonster));
                            down = !down;
                        }
                        else
                        {
                            StartCoroutine(MoveDown(spawnedMonster));
                            down = !down;
                        }
                        break;
                    case 2:
                        StartCoroutine(MoveLeft(spawnedMonster));
                        break;
                    case 3:
                        StartCoroutine(MoveRight(spawnedMonster));
                        break;
                    case 4:
                        StartCoroutine(MoveUp(spawnedMonster));
                        break;
                    case 5:
                        StartCoroutine(MoveDown(spawnedMonster));
                        break;
                    case 6:
                        if (isup==true)
                        {
                            StartCoroutine(MoveUp(spawnedMonster));
                            break;
                        }
                        else
                        {
                            StartCoroutine(MoveDown(spawnedMonster));
                            break;
                        }

                }
                time = 0;
                hasCreated = false;
            }
        }
    }
    public void RandomUpDown()
    {
        if (Random.Range(0, 2) == 0)
        {
            isup = true;
        }
        else
        {
            isup = false;
        }
    }
    private IEnumerator MoveUp(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking==false)
        {
            // �������ÿ֡�ƶ��ľ���
            float distanceToMove = moveSpeed * Time.deltaTime;
            // �ƶ������λ��
            monster.transform.Translate(Vector3.up * distanceToMove);
            yield return null;
        }
    }
    private IEnumerator MoveDown(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // �������ÿ֡�ƶ��ľ���
            float distanceToMove = moveSpeed * Time.deltaTime;
            // �ƶ������λ��
            monster.transform.Translate(Vector3.down * distanceToMove);
            yield return null;
        }   
    }
    private IEnumerator MoveLeft(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // �������ÿ֡�ƶ��ľ���
            float distanceToMove = moveSpeed * Time.deltaTime;
            // �ƶ������λ��
            monster.transform.Translate(Vector3.left * distanceToMove);
            yield return null;
        }
    }
    private IEnumerator MoveRight(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // �������ÿ֡�ƶ��ľ���
            float distanceToMove = moveSpeed * Time.deltaTime;
            // �ƶ������λ��
            monster.transform.Translate(Vector3.right * distanceToMove);
            yield return null;
        }
    }
}
