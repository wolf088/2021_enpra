using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text score_ave;
    public Text score_std;
    public Text score_max;
    public Text score_;
    public Text comment;
    public Text ave_mark;
    public Text std_mark;
    public Image image;
    public Sprite Logo_manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RenderHeatMap.mode){
            //scoreをテキストとして表示する
            score_ave.text = "膜厚の平均値: " + RenderHeatMap.average.ToString("F2") + " μm";
            score_max.text = "膜厚の最大値: " + RenderHeatMap.max.ToString("F2") + " μm";
            score_std.text = "膜厚バラツキ: " + RenderHeatMap.stdev.ToString("F2") + " μm";
            score_.text = "点数: " + RenderHeatMap.score.ToString() + " / 100";
            image.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            image.sprite = Logo_manager;
            
            switch(RenderHeatMap.grade){
                case 1:
                    comment.text = "あなたは塗装の神です。";
                    ave_mark.text = "◎";
                    ave_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    std_mark.text = "◎";
                    std_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    break;
                case 2:
                    comment.text = "かなり上手です！より平滑だと◎。";
                    ave_mark.text = "◎";
                    ave_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    std_mark.text = "〇";
                    std_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    break;
                case 3:
                    comment.text = "もう少し平滑になるように塗ろう！";
                    ave_mark.text = "◎";
                    ave_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    std_mark.text = "△";
                    std_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    break;
                case 4:
                    comment.text = "丁寧ですが目標膜厚から少し遠いかも。";
                    ave_mark.text = "〇";
                    ave_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    std_mark.text = "◎";
                    std_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    break;
                case 5:
                    comment.text = "普通ですね。";
                    ave_mark.text = "〇";
                    ave_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    std_mark.text = "〇";
                    std_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    break;
                case 6:
                    comment.text = "もう少し平滑になるように塗ろう！";
                    ave_mark.text = "〇";
                    ave_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    std_mark.text = "△";
                    std_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    break;
                case 7:
                    comment.text = "薄すぎ！もしくは厚すぎ！でも平滑です。";
                    ave_mark.text = "△";
                    ave_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    std_mark.text = "◎";
                    std_mark.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    break;
                case 8:
                    comment.text = "もっと頑張りましょう。";
                    ave_mark.text = "△";
                    ave_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    std_mark.text = "〇";
                    std_mark.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    break;
                case 9:
                    comment.text = "あなたは塗装の神を怒らせた。";
                    ave_mark.text = "△";
                    ave_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    std_mark.text = "△";
                    std_mark.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    break;
                default:
                    comment.text = "エラーです！やり直してください。";
                    break;
            }
        }
        else{
            score_ave.text = "";
            score_std.text = "";
            score_max.text = "";
            score_.text = "";
            comment.text = "";
            ave_mark.text = "";
            std_mark.text = "";
            image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
