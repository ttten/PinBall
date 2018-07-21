using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
        //HingiJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start () {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);

        }

        // Update is called once per frame
        void Update () {
                //タッチの検出
                if(Input.touchCount > 0){

                        for(int i = 0; i < Input.touchCount; i++){
                                
                                //タッチ情報の取得
                                Touch touch = Input.GetTouch(i);

                                //タッチした直後
                                if(touch.phase == TouchPhase.Began){

                                        //画面の右半分をタップした時、右フリッパーを動かす
                                        if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag") {
                                                SetAngle (this.flickAngle);

                                        //画面の左半分をタップした時、左フリッパーを動かす
                                        } else if (Input.mousePosition.x < Screen.width / 2 && tag == "LeftFripperTag") {
                                                SetAngle (this.flickAngle);
                                        }

                                //画面から指が離れたらフリッパーを元に戻す
                                } else if (touch.phase == TouchPhase.Ended){
                                        SetAngle (this.defaultAngle);
                                }
                        }
                }
        }


        //フリッパーの傾きを設定
        public void SetAngle (float angle){
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }
}
