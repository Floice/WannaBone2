using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LairRed : MonoBehaviour
{
    public GameObject monster;
    public float moveSpeed; //怪物移动速度
    public float callInterval; //怪物召唤频率
    public float pauseTime; //怪物暂停频率
    [Tooltip("1——上下\n2——左\n3——右\n4——上\n5——下\n6——随机上下")]
    public int type;
    public float time=0;   //计时器
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
        if (type == 6)//随机上下巢穴
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
            // 计算怪物每帧移动的距离
            float distanceToMove = moveSpeed * Time.deltaTime;
            // 移动怪物的位置
            monster.transform.Translate(Vector3.up * distanceToMove);
            yield return null;
        }
    }
    private IEnumerator MoveDown(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // 计算怪物每帧移动的距离
            float distanceToMove = moveSpeed * Time.deltaTime;
            // 移动怪物的位置
            monster.transform.Translate(Vector3.down * distanceToMove);
            yield return null;
        }   
    }
    private IEnumerator MoveLeft(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // 计算怪物每帧移动的距离
            float distanceToMove = moveSpeed * Time.deltaTime;
            // 移动怪物的位置
            monster.transform.Translate(Vector3.left * distanceToMove);
            yield return null;
        }
    }
    private IEnumerator MoveRight(GameObject monster)
    {
        while (monster != null && monster.GetComponent<Monster>().isAttacking == false)
        {
            // 计算怪物每帧移动的距离
            float distanceToMove = moveSpeed * Time.deltaTime;
            // 移动怪物的位置
            monster.transform.Translate(Vector3.right * distanceToMove);
            yield return null;
        }
    }
}
