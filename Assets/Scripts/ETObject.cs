
using UnityEngine;

public abstract class ETObject : MonoBehaviour
{
    protected bool isFocused = false;
    protected bool isPressed = false;
    public virtual void IsFocused()
    {
        isFocused = true;
    }
    public virtual void UnFocused()
    { 
        isFocused = false; 
    }
    public virtual void IsPressed()
    {
        isPressed = true;
    }
    public virtual void UnPressed()
    {
        isPressed = false;
    }
    public virtual bool CheckPress(){
        return isPressed;
    }
}
