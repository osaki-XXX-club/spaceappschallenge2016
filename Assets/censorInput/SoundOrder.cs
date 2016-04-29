using UnityEngine;
using System.Collections;

public class SoundOrder : MonoBehaviour {

 void Update () {
        if ( Input.GetKeyDown(KeyCode.A)) {
            Singleton<SoundPlayer>.instance.playSE( "harisen" );
        }
    }

}
