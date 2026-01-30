using System.Threading;
using UnityEngine;
using UnityEngine.UI;//turns out I cant name a button without stating Unity UI
using TMPro;
using Unity.VisualScripting;

public class Seven : MonoBehaviour
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
//9. user interface & its attachment in the gamemanager script (I did it after task 2 because I realized that should be set up in the first place)



//to finish task1: "generate a random number that range from [1,99]; regenarate after a certain time" I need to run a function to put in the regeneration,
//and I should use the timer and the interval somehow to control when the function is called

//to finish task2: "if this number can be divided by 7，should use bool" create a function to see if the number can be divided,
//the function need to call in the number,and this function should be used after every time the number is renewed
//should also name a bool that can be called in the function. and the bool has to be public? to be called in task3/4

//to finish task3: “ if this player interact,use bool” I should create a game object with a 2D collider and get that component in the script,
//and a bool to determine whether the interaction happened, I am not sure how to let game manager know it happen by this point now because its definitely another game object.
//Yes maybe I should create a game object in game manager to put the collider object in the game manager
//and perhaps another game object/text to show the number.
//on click the bool that player interacts = true

//to finish task9:"user interface & its attachment in the game manager script" I should create a basic minimum of the game objects that need to be dragged and called into this script
//like 1) the button to interact, 2) the rule text, 3) the number text, and perhaps 4) player score and 5) system score

private bool GameOver = false;//so the game could be stopped when theres a winner

public int number; //name the Number
public float interval; //name the time before every number regenerates itself;
private float timer; // to monitor how much time passed to see if the number should be regenerate
public bool DividedBy7 = false; //name the bool to see if number can be divided by 7

public TMP_Text numberText;//text to show the shifting number
public TMP_Text ruleText; //text to explain the rules
public TMP_Text SystemScoreText;
public TMP_Text PlayerScoreText;
public Button Button;

private bool PlayerInteract = false; //bool to find out if player click the button
public int WinTimes = 0;
public int LoseTimes = 0;

public TMP_Text WinText;//text would appear if player wins
public TMP_Text LoseText;//text appears if player loses

private int PlayerScore = 0;
private int SystemScore = 0;
    void Start()
        {

            WinText.gameObject.SetActive(false);
            LoseText.gameObject.SetActive(false);

        }

    // Update is called once per frame
    void Update()
    {
        if(GameOver)return;
        
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            
            RegenerateNumber();
            
            numberText.text = number.ToString(); //Link the number to the text
            
            If7();
            
            PlayerScoreOrSystemScore();
            
            PlayerScoreText.text = "Player Score:" + PlayerScore.ToString(); //Link the player score to the text it belongs
            SystemScoreText.text = "System Score:" + SystemScore.ToString(); //Link the system score to the text it belongs
            
            WinOrLose();
            
            timer = 0f;
            
        }
    }

    private void RegenerateNumber() //the function to complete task1
        //name the function we use to generate number
    {
        number = Random.Range(0, 100);//number = [1,99]
        Debug.Log(number);
    }

    private void If7() //the function to complete task2
    {
        
        if (number % 7 == 0) //desicribe the condition
        {
            DividedBy7 = true;
        }
    
    }

    public void OnHitButtonPressed() //to determine if the player interacts
    {
        PlayerInteract = true;
    }

    public void PlayerScoreOrSystemScore() //the function to find out if the player would get point
    {
        if (DividedBy7 == true && PlayerInteract == true)
        {
            WinTimes++;
            LoseTimes = 0;
            PlayerScore += WinTimes*10;
        }
        else if (DividedBy7 == false && PlayerInteract == true)
        {
            LoseTimes++;
            WinTimes = 0;
            SystemScore += LoseTimes*10;
        }
        else if (DividedBy7 == true && PlayerInteract == false)
        {
            LoseTimes++;
            WinTimes = 0;
            SystemScore += LoseTimes*10;
        }
        else if (DividedBy7 == false && PlayerInteract == false)
        {
            return;
        }
    }

    private void WinOrLose() //the function to determine whether the game needs to end
    {
        if (PlayerScore >= 100 || SystemScore >= 100) //either would cause GameOver;
        {
            GameOver = true;
            
            if (PlayerScore >= 100) //if player wins
            {
                WinText.gameObject.SetActive(true);
            }
            else //if system wins
            {
                LoseText.gameObject.SetActive(true);
            }
        }
    }

}
