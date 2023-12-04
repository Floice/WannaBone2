using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LairBlueMonster : MonoBehaviour
{
    public float stayTimeMin;//ͣ��ʱ����Сֵ
    public float stayTimeMax;//ͣ��ʱ�����ֵ

    private LairBlue[] lairs;
    private int lastLairNumber=-1;
    private int count;//�м�����̳
    private float stayTime;//ͣ��ʱ��
    public float time = 0;
    private int stayLairNumber;//ͣ����̳���

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
                transform.position = lairs[stayLairNumber].transform.position; //˲��
                lairs[stayLairNumber].staying = true;
                lastLairNumber = stayLairNumber;

                stayTime = Random.Range(stayTimeMin, stayTimeMax);
                while (stayLairNumber == lastLairNumber) //ȷ���������ͬ��Ѩ
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
