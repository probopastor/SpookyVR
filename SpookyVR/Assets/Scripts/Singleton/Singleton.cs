/* 
* Glory to the High Council
* CJ Green
* Singleton.cs
* Make a script inherit this and it will make that script/object a singleton. 
* You can then just write the ClassName.Instance._instance to reference it.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("This singleton isntance does not exist");

                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    Debug.Log("Creating Singleton Instance...");
                    GameObject newGO = new GameObject();
                    _instance = newGO.AddComponent<T>();
                }
            }

            // Returns a reference of the new created Singleton.
            return _instance;
        }
    }

    private void Start()
    {
        if (_instance == null)
        {

            Debug.Log("This singleton isntance does not exist");

        }
    }

}
