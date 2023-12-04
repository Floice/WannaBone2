using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LairBlueMonster : MonoBehaviour
{
    public float stayTimeMin;//停留时间最小值
    public float stayTimeMax;//停留时间最大值

    private LairBlue[] lairs;
    private int lastLairNumber=-1;
    private int count;//有几个祭坛
    private float stayTime;//停留时间
    public float time = 0;
    private int stayLairNumber;//停留祭坛编号

    private OrderController orderController;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        orderController = FindObjectOfType<OrderController>();
        lairs = FindObjectsOfType<LairBlue>();
        count = lairs.Length;
        stayTime = Random.Range(stayTimeMin, stayTimeMax);
        stayLairNumber = Random.Range(0, count);
        time = stayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (orderController.isRunning == true)
        {
            foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = true;
            }
        }
        else
        {
            foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }
        }

        if (orderController.isRunning == true && GetComponent<Monster>().state != 3 && GetComponent<Monster>().isAttacking == false)
        {
            time += Time.deltaTime;
            if (time > stayTime)
            {
                if (lastLairNumber != -1)
                {
                    lairs[lastLairNumber].staying = false;
                }
                transform.position = lairs[stayLairNumber].transform.position; //瞬移
                lairs[stayLairNumber].staying = true;
                lastLairNumber = stayLairNumber;

                stayTime = Random.Range(stayTimeMin, stayTimeMax);
                while (stayLairNumber == lastLairNumber) //确保随机到不同巢穴
                {
                    stayLairNumber = Random.Range(0, count);
                }
                time = 0;
            }
        }
        if(GetComponent<Monster>().isAttacking == true || GetComponent<Monster>().state == 3)
        {
            lairs[lastLairNumber].staying = false;
        }
    }
}
