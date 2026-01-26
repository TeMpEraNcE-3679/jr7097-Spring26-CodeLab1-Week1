using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    Rigidbody rb; //rigidBody for the gameObject this component is attached to
    public float moveForce = 10f; //the force we add to the GameObject

    public Key keyUp = Key.W; //keyUp for the new input system
    public Key keyDown = Key.S;
    Keyboard keyboard = Keyboard.current; //get the keyboard input for this device;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //search for a component of this type on this GameObject
    }

    void FixedUpdate()
    {

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.up * moveForce); //give the object an upward force
        }

        if (keyboard[keyDown].isPressed)
        {
            rb.AddForce(Vector3.down * moveForce);
        }
        
         //if(Input.GetKey(KeyCode.S))
         //{
         //    rb.AddForce(Vector3.down * moveForce); //give the object a downward force
         //}
    }
}