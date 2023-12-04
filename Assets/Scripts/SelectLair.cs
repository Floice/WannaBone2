using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLair : MonoBehaviour
{
    public Sprite transparent;
    public Sprite selectedSprite;
    public bool isSelected=false;
    private SelectLair[] selections;
    // Start is called before the first frame update
    void Start()
    {
        selections = FindObjectsOfType<SelectLair>();
        GetComponent<Image>().sprite = transparent;
        // ��ȡ��ť���
        Button button = GetComponent<Button>();
        // ��ӵ���¼�������
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick()
    {
        print("down");
        if (isSelected)
        {
            GetComponent<Image>().sprite = transparent;
            isSelected = false;
        }
        else
        {
            foreach (SelectLair selectlair in selections)
            {
                selectlair.changeToNull();
            }
            GetComponent<Image>().sprite = selectedSprite;
            isSelected = true;
        }
    }

    public void changeToNull()
    {
        GetComponent<Image>().sprite = transparent;
        isSelected = false;
    }
}
