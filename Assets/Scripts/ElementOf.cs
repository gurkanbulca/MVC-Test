using UnityEngine;

public abstract class ElementOf<T> : MonoBehaviour where T : Object
{
    protected T Master
    {
        get
        {
            if (_master == null)
            {
                _master = FindObjectOfType<T>();
            }

            return _master;
        }
    }

    private T _master;
}