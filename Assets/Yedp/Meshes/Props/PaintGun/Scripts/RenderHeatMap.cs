using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RenderHeatMap : MonoBehaviour
{
    public GameObject prefabObj;
    public Transform parentTran;
    public GameObject spray;
    public GameObject guntip;

    //生成した625個のCubeを格納するリストを定義
    public List<GameObject> list_object = new List<GameObject>();
    public List<double> list_function = new List<double>();

    //膜厚の値
    // public double function=0.0;

    //表示モード
    public static bool mode = false;

    /*public static double average = 0.0;
    public static double max = 0.0;
    public static double stdev = 0.0;
    public static int score = 0;
    public static int grade = 0;*/

    [SerializeField] double Q = 10000000;
    [SerializeField] double dt = 0.0016;
    [SerializeField] double theta_x = Math.PI / 5.0;
    [SerializeField] double theta_y = Math.PI / 4.0;


    //透明オブジェクトを平面上に配置
    void CreateObject(){

        //GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
        //obj.transform.SetParent(parentTran);
        
        //cloneObject = prefabObj;

        Vector3 v_init = new Vector3(0.02f,1.02f,0.0f);
        Vector3 v_add_x = new Vector3(0.04f,0.0f,0.0f);
        Vector3 v_add_y = new Vector3(0.0f,0.04f,0.0f);
        Quaternion rote = Quaternion.Euler(90.0f, 0.0f, 0.0f);

        for(int i=0;i<25;i++){
            for(int j=0; j<25; j++){
                Vector3 v_result = v_init + v_add_x * j + v_add_y * i;
                GameObject clone_object = Instantiate(prefabObj, v_result, rote);
                //clone_object.transform.localPosition = v_result;

                //x__0= v_result_i.magnitude; //x__0，y__0,z__0=ワークの座標を取得(絶対値化してベクトル→スカラーへ変換)
                //y__0= v_result_j.magnitude;
                //z__0=0;

                list_object.Add(clone_object);
                list_function.Add(0.0);
            }
        }
    }


    void Rendering(int a, int b){
        //オブジェクトリスト内のCubeを指定
        //int step = 20;
        GameObject cube_n = list_object[25*b+a];
        double function = list_function[25*b+a];
        //function = 135;
        //ヒートマップ表示
        if(function > 80){
            //関数値によってグラデーション化ができない　とりあえず定数で　関数の最大値を求めて正規化→最大255に変換できたらいいが、
            //forの中で膜厚の最大値が取得できないとか色々
            cube_n.GetComponent<Renderer>().material.color = new Color32(255,0,0,1);
        }else if(function > 55){
            int cval = (int)((80-function) / 25 * 255);
            byte Bf = (byte)cval;
            cube_n.GetComponent<Renderer>().material.color = new Color32(255,Bf,0,1);
        }else if(function > 30){
            int cval = (int)((function-30) / 25 * 255);
            byte Bf = (byte)cval;
            cube_n.GetComponent<Renderer>().material.color = new Color32(Bf,255,0,1);
        }else if(function > 10){
            int cval = (int)((30-function) / 20 * 255);
            byte Bf = (byte)cval;
            cube_n.GetComponent<Renderer>().material.color = new Color32(0,255,Bf,1);
        }else{
            int cval = (int)(function / 10 * 255);
            byte Bf = (byte)cval;
            cube_n.GetComponent<Renderer>().material.color = new Color32(0,Bf,255,1);
        }
    }


    void AppearPlane(bool buf){
        /*double sum = 0.0;
        double sumx2 = 0.0;
        double max_buf = 0.0;*/

        for(int i=0;i<25;i++){
            for(int j=0;j<25;j++){
                GameObject cube_n = list_object[25*j+i];
                cube_n.SetActive(buf);
                //double function = list_function[25*j+i];
                //sum += function;
                //sumx2 += function * function;
                //if(function > max_buf) max_buf = function;
            }
        }
        /*average = sum / 625.0;
        max = max_buf;
        stdev = Math.Sqrt(sumx2 / 625.0 - average * average);
        score = 100 - (int)(Math.Abs(average - 60.0) * 0.9) - (int)(stdev * 0.8);
        //Debug.Log(average);

        if(Math.Abs(average - 60.0) < 10.0){
            if(stdev < 10.0){
                grade = 1;
            }else if(stdev >= 10.0 && stdev < 25){
                grade = 2;
            }else{
                grade = 3;
            }
        }else if(Math.Abs(average - 60.0) >= 10.0 && Math.Abs(average - 60.0) < 20.0){
            if(stdev < 10.0){
                grade = 4;
            }else if(stdev >= 10.0 && stdev < 25){
                grade = 5;
            }else{
                grade = 6;
            }
        }else{
            if(stdev < 10.0){
                grade = 7;
            }else if(stdev >= 10.0 && stdev < 25){
                grade = 8;
            }else{
                grade = 9;
            }
        }*/
    }
  

    //スペースキーを押したらモードチェンジ！関数
    /*bool ModeChange(){
        if (Input.GetKeyDown(KeyCode.Space)){
            mode = !mode;
            AppearPlane(mode);
        }
        return mode;
    }*/


    // Start is called before the first frame update
    void Start()
    {
        CreateObject();
        //AppearPlane(false);
        AppearPlane(true);
    }


    // Update is called once per frame
    void Update(){
      
        //if(!ModeChange()){
            if(Input.GetKey("space")){
                for(int i=0;i<25;i++){
                    for(int j=0;j<25;j++){
                        　　
                        double x_0 = spray.transform.position.x * 1000;       //x_0,y_0,z_0=ガンの位置[mm](本来は変数)
                        double y_0 = spray.transform.position.y * 1000 - 1100.0;
                        double z_0 = spray.transform.position.z * 1000;
                        double phi_x = guntip.transform.localEulerAngles.y - 90.0;       //ガンの角度（姿勢）
                        double phi_y = guntip.transform.localEulerAngles.z;
                        //Debug.Log("x_0="+x_0+"  "+"y_0="+y_0+"  "+"z_0="+z_0);
                        //Debug.Log("phi_x="+phi_x+"  "+"phi_y="+phi_y);

                        //double x_0 = 500;       //x_0,y_0,z_0=ガンの位置[mm](本来は変数)
                        //double y_0 = 1500;
                        //double z_0 = 300;
                        //double phi_x = 0.0;       //ガンの角度（姿勢）
                        //double phi_y = 0.0;

                        double x__0 = x_0 - z_0 * Math.Tan(phi_x * Math.PI / 180.0);
                        double y__0 = y_0 + z_0 * Math.Tan(phi_y * Math.PI / 180.0);
                        double z__0 = 0;

                        double x = (40 * i + 20);    //ワーク上の点の位置[mm]
                        double y = (40 * j + 20);

                        double sigma_x=((z__0-z_0)/3.0)*(Math.Tan(theta_x/2.0));
                        double sigma_y=((z__0-z_0)/3.0)*(Math.Tan(theta_y/2.0));
                        //for(double x=(x__0-(3*sigma_x));x<(x__0+(3*sigma_x));x++){  //座標(x，y)に対して膜厚関数を加算
                            //for(double y=(y__0-(3*sigma_y));y<(y__0+(3*sigma_y));y++){
                        double function=0.0;
                        function = (Q*dt)/(2.0*(Math.PI)*(sigma_x)*(sigma_y)) * Math.Exp((-0.5) * Math.Pow(((x-x__0)/sigma_x), 2.0) + (-0.5) * Math.Pow(((y-y__0)/sigma_y), 2.0));
                        //Debug.Log(MoveGun.RightHandRotation.x);
                        if(!Double.IsNaN(function)){
                            list_function[25*j+i] += function;
                        }
                        Rendering(i, j);
                        //Debug.Log("sigma_x="+sigma_x+"  "+"sigma_y="+sigma_y);
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.O)) Start();
            //function += 0.01;
        /*}
        else{
            for(int i=0;i<25;i++){
                for(int j=0;j<25;j++){
                    Rendering(i, j);
                }
            }
        }*/
    }
}
