using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class keysousa : MonoBehaviour
{
    private Rigidbody rigidbody;
    public GameObject bullet;
    private bool judge=true;
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        Debug.Log("Start");
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))//スペースキーを離した時
        {
            bullet.SetActive(true);
            Vector3 bulletPosition=GameObject.Find("Gun").transform.position+new Vector3(0,0,0.9f);
            GameObject randomTarget=Instantiate(bullet,bulletPosition,Quaternion.identity);
            bullet.SetActive(false);
        }
        if(Input.GetKey(KeyCode.UpArrow))//上キーを押している間
        {
            if(this.transform.position.x<=9)
            {
               this.gameObject.transform.position+=new Vector3(-0.02f,0.0f,0.0f);
               Debug.Log("front");
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))//下キーを押している間
        {
            if(this.transform.position.x>=-9)
            {
               this.gameObject.transform.position+=new Vector3(0.02f,0.0f,0.0f);
               Debug.Log("back");
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow))//左キーを押している間
        {
            if(this.transform.position.z>=-9.5)
            {
               this.gameObject.transform.position+=new Vector3(0.0f,0.0f,-0.02f);
               Debug.Log("left");
            }
        }
        if(Input.GetKey(KeyCode.RightArrow))//右キーを押している間
        {
            if(this.transform.position.z<=9.5)
            {
               this.gameObject.transform.position+=new Vector3(0.0f,0.0f,0.02f);
               Debug.Log("right");
            }
        }
        if(judge)
        {
            if(Input.GetKeyDown(KeyCode.Z))//Zキーを押したとき
            {
                rigidbody.AddForce(new Vector3 (0,350,0),ForceMode.Acceleration);
                judge=false;//空中でさらにジャンプできないように
                Debug.Log("jump");
                Invoke("controlJump",1.5f);//1.5秒後にcontrolJump()を呼ぶ,
                　　　　　　　　　　　　//つまりジャンプしてから1.5秒間は次のジャンプができない
            }
        }
    }
    private void controlJump()
    {
        judge=true;
    }
}