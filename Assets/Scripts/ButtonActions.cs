using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TriforkTest
{
    public class ButtonActions : MonoBehaviour
    {

        [SerializeField]
        private Coroutine resetTimer, timer, difference;
        [SerializeField]
        private Button target,random;
        [SerializeField]
        private TMP_Text clickText;


        private bool runningReset, running;
        private int numberOfClicks = 0;

        // Update is called once per frame
        void Update()
        {
            clickText.text = numberOfClicks + "";
            
        }

        #region timers
        /// <summary>
        /// Starts the 2 seconds interval timer for main game logic.
        /// Uses the bool running as a defensive param.
        /// </summary>
        public void StartTimer()
        {
            if (!running)
            {
                timer = StartCoroutine(Timer());
                running = !running;
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
            DoAction(numberOfClicks,target);
            ResetClicks(numberOfClicks);
            running = !running;
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
            ResetClicks(numberOfClicks);
            DoAction(numberOfClicks,target);

        }
        #endregion
        #region Do random
        public void DoRando()
        {
            int rand = Random.Range(1, 6);
            DoAction(rand,random);
        }
        #endregion
        #region helper methods
        //Worth a method call?
        public void FlipBool(bool running)
        {
            running = !running;
        }
        public void ClickIncrease(int numberOfClicks)
        {
            numberOfClicks++;
        }

        public void ResetClicks(int numberOfClicks)
        {
            numberOfClicks = 0;
        }
        #endregion

        #region state machine
        protected void DoAction(int numberOfClicks, Button target)
        {            
            switch (numberOfClicks)
            {
                case 5:
                    //change to magenta
                    target.GetComponent<Image>().color = Color.magenta;
                    break;
                case 2:
                    //red
                    target.GetComponent<Image>().color = Color.red;
                    break;
                case 1:
                    //blue
                    target.GetComponent<Image>().color = Color.blue;
                    break;
                default:
                    //green
                    target.GetComponent<Image>().color = Color.green;
                    break;
            }
        }
        #endregion
    }

    struct HelperMethods
    {

    }
}
