using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR;
using Valve.VR;

public class MoveGun : MonoBehaviour
{
    //右コントローラの位置座標格納用
    public static Vector3 RightHandPosition;
    //右コントローラの回転座標格納用（クォータニオン）
    public Quaternion RightHandRotationQ;
    //右コントローラの回転座標格納用
    public static Vector3 RightHandRotation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*InputTracking.GetLocalPosition(XRNode.機器名)で機器の位置や向きを呼び出せる*/


        //RightHand（右コントローラ）の情報を一時保管--------------------
        //位置座標を取得
        RightHandPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
        //回転座標をクォータニオンで値を受け取る
        RightHandRotationQ = InputTracking.GetLocalRotation(XRNode.RightHand);
        //取得した値をクォータニオン → オイラー角に変換
        RightHandRotation = RightHandRotationQ.eulerAngles;
        //--------------------------------------------------------------


        //取得したデータを表示（HMDP：HMD位置，HMDR：HMD回転，LFHR：左コン位置，LFHR：左コン回転，RGHP：右コン位置，RGHR：右コン回転）
        //Debug.Log("RGHP:" + RightHandPosition.x + ", " + RightHandPosition.y + ", " + RightHandPosition.z + "\n" +
            //"RGHR:" + RightHandRotation.x + ", " + RightHandRotation.y + ", " + RightHandRotation.z);
        
        
        //キーボード操作でデバッグするとき用
        /*if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += new Vector3(0,1 * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position += new Vector3(0,-1 * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(0,0,1 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(0,0,-1 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(1 * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(-1 * Time.deltaTime,0,0);
        }
        //↓ここから回転コードを付け足しています
        if(Input.GetKey(KeyCode.T)){
            transform.Rotate(50 * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.G)){
            transform.Rotate(-50 * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.H)){
            transform.Rotate(0,0,-50 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.F)){
            transform.Rotate(0,0,50 * Time.deltaTime);
        }*/
    }
}
