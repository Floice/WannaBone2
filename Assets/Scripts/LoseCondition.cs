using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    //public List<Transform> targets; // 目标物体的Transform组件列表
    public GameObject loseScreen; // 通关画面的UI元素
    //public float distanceThreshold=0; // 目标距离阈值
    //private GameObject[] monsters;

    private void Update()
    {
        /*
        monsters = GameObject.FindGameObjectsWithTag("monster");
        if (monsters != null)
        {
            foreach (GameObject monster in monsters)
            {
                //怪物要醒着
                if (monster.GetComponent<Monster>().state == 1)
                {
                    distanceThreshold = monster.GetComponent<Monster>().attackRange;
                }
                float distance = Vector3.Distance(transform.position, monster.GetComponent<Transform>().position);

                if (distance <= distanceThreshold)
                {
                    lose();
                    break; // 结束循环，只要有一个目标满足条件即可
                }
                distanceThreshold = 0;
            }
        }
        // 遍历目标物体列表
        foreach (Transform target in targets)
        {
            // 获取目标物体的中心点位置
            if (target.CompareTag("mine") == true)
            {
                distanceThreshold = target.GetComponent<Mine>().attackRange;
            }

            // 计算玩家与目标的距离
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= distanceThreshold)
            {
                lose();
                break; // 结束循环，只要有一个目标满足条件即可
            }
            distanceThreshold = 0;
        }
        */
    }
    public void lose()
    {
        OrderController.instructionList.Clear();
        gameObject.GetComponent<Dog>().changeToFlame();
        loseScreen.SetActive(true);
    }
}


