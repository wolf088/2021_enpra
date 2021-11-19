using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Valve.VR;

public class IsTrigger : MonoBehaviour
{

    public ParticleSystem SprayObject;

    //InteractUIボタン（初期設定はトリガー）が押されてるのかを判定するためのIuiという関数にSteamVR_Actions.default_InteractUIを固定
    public SteamVR_Action_Boolean Iui = SteamVR_Actions.default_InteractUI;
    //結果の格納用Boolean型関数interacrtui
    public static Boolean interacrtui;

    // Start is called before the first frame update
    void Start()
    {
        //SprayObject.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey("space"))
        {
            SprayObject.Play();
        }else
        {
            SprayObject.Stop();
        }*/

        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        interacrtui = Iui.GetState(SteamVR_Input_Sources.RightHand);
        //InteractUIが押されているときにコンソールにInteractUIと表示
        if (interacrtui)
        {
            //Debug.Log("InteractUI");
            SprayObject.Play();
        }else{
            SprayObject.Stop();
        }
    }
}
