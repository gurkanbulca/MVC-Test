using UnityEngine;

public abstract class Element : MonoBehaviour
{
    private Application _app;

    public Application App
    {
        get
        {
            if (_app == null)
            {
                _app = GameObject.FindObjectOfType<Application>();
            }
            return _app;
        }
    }
}