using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayAgain : MonoBehaviour
{
    public void OnClickRestart()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetStaticVariables();
    }

    private static void ResetStaticVariables()
    {   
        CreateNewLine.counter = 1; 
        CreateNewLine_l.counter_l = 1;
        OrderController.instructionList = new List<string>();
        OrderController.alreadyRunCounter = 0;
        OrderController.ForinstructionList = new List<List<int>>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.ForBreakList = new List<int>(); //记录何时停止for循环
        OrderController.WhileinstructionList = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.WhileBreakList = new List<int>(); //记录何时停止for循环
        OrderController.IfinstructionList = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.IfBreakList = new List<int>(); //记录何时停止for循环

        OrderController_lit.instructionList_l = new List<string>();
        OrderController_lit.alreadyRunCounter_l = 0;
        OrderController_lit.ForinstructionList_l = new List<List<int>>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController_lit.ForBreakList_l = new List<int>(); //记录何时停止for循环
        OrderController_lit.WhileinstructionList_l = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController_lit.WhileBreakList_l = new List<int>(); //记录何时停止for循环
        OrderController_lit.IfinstructionList_l = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController_lit.IfBreakList_l = new List<int>(); //记录何时停止for循环
    }
}

