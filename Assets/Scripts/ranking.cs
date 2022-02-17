using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ranking : MonoBehaviour
{
    // Playprefsランキング //次のステージへ（入力正誤問題）　//もう一度やる
    [SerializeField] Text text;
    [SerializeField] Text typeText;
    string rank;
    int rankint;
    void Start()
    {
        int top = Typing.count;
        rankint=PlayerPrefs.GetInt(rank);
        if (top>rankint)
        {
            PlayerPrefs.SetInt(rank,top);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rankint = PlayerPrefs.GetInt(rank);
        text.text = "最高記録"+ "<color=#F00000>"+rankint.ToString()+"</color>" + "国！！";
        typeText.text = "今回あなたは一秒あたり" + Typing.efficiency.ToString("f1") + "回打てました！";
    }
    public void ResetButton()
    {
        PlayerPrefs.SetInt(rank,0);
    }
}
