using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{

    public ParticleSystem SprayObject;

    // Start is called before the first frame update
    void Start()
    {
        //SprayObject.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            SprayObject.Play();
        }else
        {
            SprayObject.Stop();
        }
    }
}
