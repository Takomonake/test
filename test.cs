using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityRawInput;


public class test : MonoBehaviour
{
    //public GameObject bta, btaoff, btb, btboff, btc, btcoff, btd, btdoff, fxa, fxaoff, fxb, fxboff;//必要なくなった。
    //public bool InterceptMessages;//使ってなくて無くてもいいのでコメントアウト
    public GameObject[] on=new GameObject[6];//配列の用意
    public GameObject[] off=new GameObject[6];
    public int a;//配列番号取得？用変数

    private void OnEnable()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyUp += OnKeyUp;
        RawKeyInput.OnKeyDown += OnKeyDown;
    }

    private void OnDisable()
    {
        RawKeyInput.Stop();
        RawKeyInput.OnKeyUp -= OnKeyUp;
        RawKeyInput.OnKeyDown -= OnKeyDown;
    }
    void Start()
    {
        //forと配列の利用での行数削減
        for(int i=0;i<6;i++){
        on[i].SetActive(false);
        off[i].SetActive(true);
        }
    }

   private void OnKeyUp(RawKey key)
    {
        a=(int)key-112;//入力キーの番号識別(F1=112)細かいのはRawKey.cs(16進)かKeycord等参照
        //F1~F6以外だと異常値が出て強制終了するので対策としてtry,catchの実装。
        try{
            if (!(RawKeyInput.IsKeyDown(key)))//通常ifは使われてなかったので削除
            {
                on[a].SetActive(false);
                off[a].SetActive(true);
            }
        }
        catch{}
    }
    private void OnKeyDown(RawKey key)
    {
        a=(int)key-112;
        try{
            if (RawKeyInput.IsKeyDown(key))
            {
                //Debug.Log("Key Down: "+(key-112)+a);
                on[a].SetActive(true);
                off[a].SetActive(false);
            }
        }
        catch{}
    }
}
    //以下略
