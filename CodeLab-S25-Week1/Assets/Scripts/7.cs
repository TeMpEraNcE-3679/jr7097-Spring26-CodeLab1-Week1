using System.Threading;
using UnityEngine;

public class 7 : MonoBehaviour
{
    

// I want to use this script to create a game that generates random number with in 100,
// and player need to intereact in the given time to gain score，
// otherwise the host (the game itself) would gain score and once someone reach the goal score the game ends.

//task list:
//1. generate a random number that range from [1,99]; regenarate after a certain time(fixed update?)
//2. if this number can be divided by 7，should use bool
//3. if this player interact, use bool
//4. if this interaction is successful, use if
//5. player score or system score, if & bool
//6. how many score this round
//7. if it meets the condition to end game
//8. end game text



//to finish task1: "generate a random number that range from [1,99]; regenarate after a certain time" I need to run a function to put in the regeneration,
//and I should use the timer and the interval somehow to control when the function is called

public int number; //name the Number
public float interval; //name the time before every number regenerates itself;
private float timer; // to monitor how much time passed to see if the number should be regenerate

    void Start()
        {
            
        }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (timer >= interval)
        {
            RegenerateNumber       
            timer = 0f;
        }
    }

    private void RegenerateNumber()
        //name the function we use to generate number
    {
        number = Random.Range(0, 100);//number = [1,99]
        Debug.Log（number）；
    }

}
