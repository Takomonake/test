using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityRawInput;

public class test : MonoBehaviour
{
    public GameObject btf1, btf1off, btf2, btf2off, btf3, btf3off, btf4, btf4off, fxf5, fxf5off, fxf6, fxf6off;
    public GameObject[] teston=new GameObject[6];
    public GameObject[] testoff=new GameObject[6];
    public int a=0;
    private void OnEnable()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyUp += OnKeyUp;
        RawKeyInput.OnKeyDown += OnKeyDown;
        //Debug.Log("start");
    }

    private void OnDisable()
    {
        RawKeyInput.Stop();
        RawKeyInput.OnKeyUp -= OnKeyUp;
        RawKeyInput.OnKeyDown -= OnKeyDown;
        //Debug.Log("end");
    }
    void Start()
    {
        GameObject[] teston={btf1,btf2,btf3,btf4,fxf5,fxf6};
        GameObject[] testoff={btf1off,btf2off,btf3off,btf4off,fxf5off,fxf6off};
        for(int i=0;i<6;i++){
        teston[i].SetActive(false);
        testoff[i].SetActive(true);
        }
    }

   private void OnKeyUp(RawKey key)
    {
        GameObject[] teston={btf1,btf2,btf3,btf4,fxf5,fxf6};
        GameObject[] testoff={btf1off,btf2off,btf3off,btf4off,fxf5off,fxf6off};
        a=(int)key-112;
        try{
        if (RawKeyInput.IsKeyDown(key))
        {}
        else
        {
            teston[a].SetActive(false);
            testoff[a].SetActive(true);
        }
        }
        catch{}
    }
    private void OnKeyDown(RawKey key)
    {
        GameObject[] teston={btf1,btf2,btf3,btf4,fxf5,fxf6};
        GameObject[] testoff={btf1off,btf2off,btf3off,btf4off,fxf5off,fxf6off};
        a=(int)key-112;
        try{
        if (RawKeyInput.IsKeyDown(key))
        {
            //Debug.Log("Key Down: "+(key-112)+a);
            teston[a].SetActive(true);
            testoff[a].SetActive(false);
        }
        }
    catch{}
}
