using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer {

    GameObject soundPlayerObj;
    AudioSource audioSource;
    Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();

    // AudioClip information
    class AudioClipInfo {
        public string resourceName;
        public string name;
        public AudioClip clip;

        public AudioClipInfo( string resourceName, string name ) {
            this.resourceName = resourceName;
            this.name = name;
        }
    }

    public SoundPlayer() {
        audioClips.Add( "sei_ka_chins", new AudioClipInfo( "sei_ka_chin", "sei_ka_chin" ) );
        audioClips.Add( "sei_ka_mokugyo02", new AudioClipInfo( "sei_ka_mokugyo02", "sei_ka_mokugyo02" ) );
        audioClips.Add( "harisen", new AudioClipInfo( "harisen", "harisen" ) );
    }

    public bool playSE( string seName ) {
        if ( audioClips.ContainsKey( seName ) == false )
            return false; // not register

        AudioClipInfo info = audioClips[ seName ];

        // Load
        if ( info.clip == null )
            info.clip = (AudioClip)Resources.Load( info.resourceName );

        if ( soundPlayerObj == null ) {
            soundPlayerObj = new GameObject( "SoundPlayer" ); 
            audioSource = soundPlayerObj.AddComponent<AudioSource>();
        }

        // Play SE
        audioSource.PlayOneShot( info.clip );

        return true;
    }
}
