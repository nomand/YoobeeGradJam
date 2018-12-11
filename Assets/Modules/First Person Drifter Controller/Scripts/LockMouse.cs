using UnityEngine;

public class LockMouse : MonoBehaviour
{
    bool lockstate = true;

	void Start()
	{
		LockCursor(true);
	}

    void Update()
    {
    	// lock when mouse is clicked
    	if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
    	{
    		LockCursor(true);
    	}
    
    	// unlock when escape is hit
        if  ( Input.GetKeyDown(KeyCode.Escape) )
        {
        	LockCursor(lockstate);
        }
    }
    
    public void LockCursor(bool state)
    {
    	Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
        lockstate = !state;
    }
}