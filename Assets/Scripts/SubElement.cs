using UnityEngine;

public abstract class SubElement<T> : Element where T : Object
{
    protected T Controller;
    
    protected virtual void Awake()
    {
        Controller = FindObjectOfType<T>();
    }
}