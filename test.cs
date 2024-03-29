//このコードはRawKey.csの6～11行をコメントアウトする前提です。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityRawInput;

public class test : MonoBehaviour
{
    //public GameObject bta, btaoff, btb, btboff, btc, btcoff, btd, btdoff, fxa, fxaoff, fxb, fxboff;//必要なくなった。
    //public bool InterceptMessages;//使ってなくて無くてもいいのでコメントアウト
    public GameObject[] on=new GameObject[6];//配列の用意。DictionaryはRawKeyの取得が上手くいかなかったので断念。
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
        off[i].SetActive(true);//気にするほどじゃないでしょうがラグった場合オブジェクトが消失する可能性を考えてTrueを先に。   
        on[i].SetActive(false);//ただ、オブジェクトが重なった際メッシュがバグったりするかもしれないのでどちらが良いのかはなんとも。
        }
    }

   private void OnKeyUp(RawKey key)
    {
        a=(int)key-112;//入力キーの番号識別(F1=112)細かいのはRawKey.cs(16進)かKeycord等参照
        //想定しているF1~F6以外だと異常値が出てUnityが強制終了するので対策としてtry,catchの実装。
        try{
            if (!(RawKeyInput.IsKeyDown(key)))//通常ifは使われてなかったので削除
            {
                off[a].SetActive(true);            
                on[a].SetActive(false);
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
