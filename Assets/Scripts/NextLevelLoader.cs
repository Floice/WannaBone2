using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextLevelLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string nextSceneName = GetNextSceneName(currentSceneName);
        print("nextLevel" + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
        ResetStaticVariables();
    }

    private string GetNextSceneName(string currentSceneName)
    {
        // 在这里编写根据当前场景名称获取下一个场景名称的逻辑
        // 示例逻辑：根据场景名称的数字部分递增获取下一个场景名称
        string nextSceneName = "";

        if (currentSceneName.StartsWith("Level"))
        {
            int currentLevel = int.Parse(currentSceneName.Substring(5));
            int nextLevel = currentLevel + 1;
            nextSceneName = "Level" + nextLevel;
        }

        return nextSceneName;
    }
     private static void ResetStaticVariables()
    {
        CreateNewLine.counter = 1;
        CreateNewLine_l.counter_l = 1; 
        OrderController.instructionList = new List<string>();
        OrderController.alreadyRunCounter = 0;
        OrderController.ForBreakList = new List<int>(); //记录何时停止for循环
        OrderController.ForinstructionList = new List<List<int>>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.WhileinstructionList = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.WhileBreakList = new List<int>(); //记录何时停止for循环
        OrderController.IfinstructionList = new List<int>(); //二维列表，元素为<for所在的行数，循环次数>
        OrderController.IfBreakList = new List<int>(); //记录何时停止for循环
    }
}

