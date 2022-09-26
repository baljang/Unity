using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 1. original 이미 들고 있으면 바로 사용
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        
        // 2. 혹시 풀링된 애가 있을까? 
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name; 

        return go;  
    }

    public void Destroy(GameObject go)  // 나중에 필요하면 시간도 넣는 거 만들어 주면 된다. 
    {
        if (go == null)
            return;

        // 만약에 풀링이 필요한 아이라면 -> 풀링 매니져한테 위탁
        // 당장 Destroy 하는게 아니라 내부적으로 숨겨 놔서 관리를 하다가 나중에 딴애가 필요하게 됐다고 하면 Intantiate의 2에서 뱉어주면 된다. 

        Object.Destroy(go);
    }
}