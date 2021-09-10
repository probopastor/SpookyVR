using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank : MonoBehaviour
{

    public static ResourceBank _resourceBank;

    private void Awake()
    {
        if (_resourceBank != null && _resourceBank != this)
        {
            Destroy(_resourceBank.gameObject);
        }
        else
        {
            _resourceBank = this;
            DontDestroyOnLoad(_resourceBank.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
