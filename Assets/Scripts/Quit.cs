using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("游戏已退出");
        Application.Quit();
    }
}

