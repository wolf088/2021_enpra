using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{

    public GameObject SprayObject;

    // Start is called before the first frame update
    void Start()
    {
        SprayObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            SprayObject.SetActive(false);
        }else
        {
            SprayObject.SetActive(true);
        }
    }
}
