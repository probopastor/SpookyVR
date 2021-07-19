using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// To be overwritten. Causes this object to be interacted with. 
    /// </summary>
    public abstract void Interact();
}
