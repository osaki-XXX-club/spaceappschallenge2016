using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public Texture texture0;
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public Texture texture4;
	public Texture texture5;
	public Texture texture6;
	public int textureNum = 0;


     /// <summary>加速度？傾き？</summary>
     private Vector3 acceleration;
     /// <summary>フォント</summary>
     private GUIStyle labelStyle;

     int frameCount = 0;

     // Use this for initialization
     void Start()
     {
         //フォント生成
         this.labelStyle = new GUIStyle();
         this.labelStyle.fontSize = Screen.height / 22;
         this.labelStyle.normal.textColor = Color.white;
     
		Texture targetTexture = texture0;
		int tatamiFlag = 0;
		switch (textureNum) {
		case 0:
			targetTexture = texture0;
			tatamiFlag = 1;
			break;
		case 1:
			targetTexture = texture1;
			tatamiFlag = 0;
			break;
		case 2:
			targetTexture = texture2;
			tatamiFlag = 0;
			break;
		case 3:
			targetTexture = texture3;
			tatamiFlag = 0;
			break;
		case 4:
			targetTexture = texture4;
			tatamiFlag = 0;
			break;
		case 5:
			targetTexture = texture5;
			tatamiFlag = 0;
			break;
		case 6:
			targetTexture = texture6;
			tatamiFlag = 0;
			break;
		default:
			break;
		}
		GetComponent<Renderer>().material.SetTexture("_MainTex", targetTexture);
		GameObject.Find("Cube").transform.localScale = new Vector3(14 * tatamiFlag, 7 * tatamiFlag, 10 * tatamiFlag);
	}

     // Update is called once per frame
     void Update()
     {
         //文字描画はOnGUIでしかできないらしいので保持
         this.acceleration = Input.acceleration;

            frameCount++;
           if (frameCount % 100 == 0) {
               if ( System.Math.Round(this.acceleration.x, 3) < -0.5 || 0.5 < System.Math.Round(this.acceleration.x, 3)) {
                 Singleton<SoundPlayer>.instance.playSE( "harisen" );
               }
               frameCount = 0;
            }

     }

     /// <summary>
     /// GUI更新はここじゃないとダメらしいよ。
     /// まだよくわかんない。
     /// </summary>
     void OnGUI()
     {
         if (acceleration != null)
         {
             float x = Screen.width / 10;
             float y = 0;
             float w = Screen.width * 8 / 10;
             float h = Screen.height / 20;

             for (int i = 0; i < 3; i++)
             {
                 y = Screen.height / 10 + h * i;
                 string text = string.Empty;

                 switch (i)
                 {
                     case 0://X
                         text = string.Format("accel-X:{0}", System.Math.Round(this.acceleration.x, 3));
                         break;
                     case 1://Y
                         text = string.Format("accel-Y:{0}", System.Math.Round(this.acceleration.y, 3));
                         break;
                     case 2://Z
                         text = string.Format("accel-Z:{0}", System.Math.Round(this.acceleration.z, 3));
                         break;
                     default:
                         throw new System.InvalidOperationException();
                 }

                 // GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);

             }
         }
     }
 }

