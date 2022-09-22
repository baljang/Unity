using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager  
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount]; 

    // MP3 Player  -> AudioSource
    // MP3 ����    -> AudioCllip
    // ����(��)    -> AudioListener

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound"); 
        if(root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound)); 
            for(int i=0; i<soundNames.Length-1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform; 
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true; 
        }
    }

    public void Play(Define.Sound type, string path, float pitch = 1.0f)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}"; 

        if(type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path); 
            if(audioClip == null)
            {
                Debug.Log($"AudioClip Missing! {path}"); 
                return;
            }      
            
            // TODO
        }
        else
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.Log($"AudioClip Missing! {path}");
                return;
            }

            AudioSource audiosource = _audioSources[(int)Define.Sound.Effect];
            audiosource.pitch = pitch; 
            audiosource.PlayOneShot(audioClip); 
             
        }          
    } 
}
