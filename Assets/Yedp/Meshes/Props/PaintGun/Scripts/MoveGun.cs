using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(0,0.8f * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0,-0.8f * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += new Vector3(0,0,0.8f * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position += new Vector3(0,0,-0.8f * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(0.8f * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(-0.8f * Time.deltaTime,0,0);
        }
        //↓ここから回転コードを付け足しています
        if(Input.GetKey(KeyCode.H)){
            transform.Rotate(0,50 * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.F)){
            transform.Rotate(0,-50 * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.G)){
            transform.Rotate(0,0,-50 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.T)){
            transform.Rotate(0,0,50 * Time.deltaTime);
        }
        //Debug.Log(Time.deltaTime);
    }
}
