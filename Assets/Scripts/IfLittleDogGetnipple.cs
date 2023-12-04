using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfLittleDogGetnipple : MonoBehaviour
{   
    public Transform target; // 目标物体的Transform组件数组
    public bool getNipple = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {       
        if(target!=null){
            Vector3 playerCenter = transform.position ;
            Vector3 targetCenter = target.position ;
            if (Vector3.Distance(playerCenter, targetCenter) < 0.1f)
            {
                target.gameObject.SetActive(false);
                getNipple = true; 
            }
        }else{
            getNipple = true; 
        }
    }
}
