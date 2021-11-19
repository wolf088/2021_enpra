using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePaint : MonoBehaviour
{
    private Texture2D workingTexture; // the texture we modify
    private Renderer mioRenderer; // renderer component
    Texture2D texture; 
     Color32 baseColor = new Color32(255,0,0,255);


    // Start is called before the first frame update
    void Start()
    {
        /*mioRenderer = GetComponent<Renderer>();
        texture = mioRenderer.material.mainTexture as Texture2D;
        workingTexture = new Texture2D (texture.width, texture.height);

        Color32[] sourcePixels = texture.GetPixels32();
         workingTexture.SetPixels32(sourcePixels);
         mioRenderer.material.mainTexture = workingTexture;
         workingTexture.Apply();*/
    }

    /*void OnParticleCollision(GameObject other){
        int num = other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize();
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[num]; //
        int result = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, collisionEvents);
        //Color32 pixelColor = new Color32(0,255,0,255);
      
      RaycastHit hit;
      Vector3 pos = Vector3.zero;
      Vector2 pixelUV;
      Vector2 pixelPoint;
      for(int i=0;i<num;i++){
         if(Physics.Raycast (collisionEvents [i].intersection, -Vector3.up, out hit)){
             //Debug.Log("hit");
             pos = hit.point;
             pixelUV = hit.textureCoord;
             pixelPoint = new Vector2(pixelUV.x = texture.width,pixelUV.y = texture.height);
             workingTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y,baseColor);
            }
            workingTexture.Apply();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
