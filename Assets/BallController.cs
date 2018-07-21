using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
        
        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

        //スコアを表示するテキスト
        private GameObject scoreText;

        //スコアを初期化
        private int score = 0;

        // Use this for initialization
        void Start () {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");

                //シーン中のScoreTextオブジェクトを取得
                this.scoreText = GameObject.Find("ScoreText");

        }
        
        // Update is called once per frame
        void Update () {
        		//スコアを表示
     	       scoreText.GetComponent<Text> ().text = "Score:" + score;

                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ) {
                        //GameoverTextにゲームオーバを表示
                        this.gameoverText.GetComponent<Text> ().text = "GAME OVER";
                }
        }

        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other) {

        		//大きい星に当たった時：+30点
        		if (other.gameObject.tag == "LargeStarTag"){
        			score += 30;

    	        //小さい星に当たった時：+5点
    	        }else if(other.gameObject.tag == "SmallStarTag"){
        			score += 5;

    	        //大きい雲に当たった時：+15点
    	        }else if(other.gameObject.tag == "LargeCloudTag"){
        			score += 15;
    	        
    	        //小さい雲に当たった時：+10点
    	        }else if(other.gameObject.tag == "SmallCloudTag"){
        			score += 10;
    	        }
    	}
}