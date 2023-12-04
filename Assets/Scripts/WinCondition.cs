using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinCondition : MonoBehaviour
{
    public Transform[] targets; // 目标物体的Transform组件数组
    public GameObject winScreen; // 通关画面的UI元素
    public bool isWin = false;
    private int count = 0;
    private void Update()
    {
        // 检查玩家与列表中每个目标物体的接触情况
        foreach (Transform target in targets)
        {
            Vector3 playerCenter = transform.position ;
            Vector3 targetCenter = target.position ;
            //print(Vector3.Distance(playerCenter, targetCenter));
            // 检测中心点重合
            if (target.gameObject.activeSelf && Vector3.Distance(playerCenter, targetCenter) < 0.1f)
            {
                if (target.CompareTag("altar") == true)
                {
                    if (target.gameObject.GetComponent<Altar>().state == 1 && gameObject.GetComponent<Dog>().state!=1)
                    {
                        target.gameObject.SetActive(false);
                        count = count + 1;
                    }
                }
                else
                {
                    target.gameObject.SetActive(false);
                    count = count + 1;
                }
            }
        }
        // 根据所有目标是否被接触来判断游戏胜利

        IfLittleDogGetnipple LittleDog = FindObjectOfType<IfLittleDogGetnipple>();
        if(LittleDog!=null){
            bool getnipple = LittleDog.getNipple;
            if (count >= targets.Length && getnipple)
            {   
                isWin = true;
                // 显示通关画面
                winScreen.SetActive(true);
                print("win");
            }
            else
            {
                // 隐藏通关画面
                winScreen.SetActive(false);
            }
        }else{
            if (count >= targets.Length)
            {   
                isWin = true;
                // 显示通关画面
                winScreen.SetActive(true);
            }
            else
            {
                // 隐藏通关画面
                winScreen.SetActive(false);
            }
        }
    }
}


