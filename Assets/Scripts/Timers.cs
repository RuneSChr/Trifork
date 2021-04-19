using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers : MonoBehaviour
{
    [SerializeField]
    private TriforkTest.ButtonActions actions;
    private bool running, runningReset;
    private Coroutine resetTimer;
    //private IEnumerator timer;

    
    /// <summary>
    /// Starts the 2 seconds interval timer for main game logic.
    /// Uses the bool running as a defensive param.
    /// </summary>
    public void StartTimer()
    {
        if (!running)
        {
            running = !running;
            StartCoroutine(Timer());
        }
    }
    /// <summary>
    /// 2 second loop that only triggers on first click and does not reset by subsequent clicks
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1);
        }
        //cleanup
        running = !running;
        actions.resetEvent.Invoke(false);
        //anim.SetInteger("numberOfClicks", numberOfClicks);
        //DoAction(numberOfClicks,target);
        //ResetClicks();
    }
    /// <summary>
    /// checks to see if coroutine is running to start/restart the timer
    /// Uses bool runningReset as defensive param
    /// </summary>
    public void StartResetTimer()
    {
        if (runningReset)
        {
            runningReset = !runningReset;
            StopCoroutine(resetTimer);
        }
        runningReset = !runningReset;
        resetTimer = StartCoroutine(ResetTimer());
    }

    //for 5 second rule
    private IEnumerator ResetTimer()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
        }
        //cleanup
        actions.resetEvent.Invoke(true);
        //ResetClicks();
        //anim.SetInteger("numberOfClicks", numberOfClicks);
        //DoAction(numberOfClicks,target);
    }
   
}
