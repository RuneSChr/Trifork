﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace TriforkTest
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>
    {

    }
    public class ButtonActions : MonoBehaviour
    {

        [SerializeField]
        private Coroutine resetTimer, timer, difference;
        [SerializeField]
        private Button target,random;
        [SerializeField]
        private TMP_Text clickText;
        [SerializeField]
        private Animator anim;

        private int numberOfClicks = 0;

        public BoolEvent resetEvent;
        private void Start()
        {
            if(resetEvent == null)
            {
                resetEvent = new BoolEvent();
            }
            resetEvent.AddListener(CleanUp);
        }
        // Update is called once per frame
        void Update()
        {
            clickText.text = numberOfClicks + "";
            
        }

        //#region timers
        ///// <summary>
        ///// Starts the 2 seconds interval timer for main game logic.
        ///// Uses the bool running as a defensive param.
        ///// </summary>
        //public void StartTimer()
        //{
        //    if (!running)
        //    {
        //        running = !running;
        //        timer = StartCoroutine(Timer());
        //    }
        //}
        ///// <summary>
        ///// 2 second loop that only triggers on first click and does not reset by subsequent clicks
        ///// </summary>
        ///// <returns></returns>
        //private IEnumerator Timer()
        //{

        //    for (int i = 0; i < 2; i++)
        //    {
        //        yield return new WaitForSeconds(1);
        //    }
        //    //cleanup
        //    running = !running;
        //    //anim.SetInteger("numberOfClicks", numberOfClicks);
        //    //DoAction(numberOfClicks,target);
        //    //ResetClicks();
        //}
        ///// <summary>
        ///// checks to see if coroutine is running to start/restart the timer
        ///// Uses bool runningReset as defensive param
        ///// </summary>
        //public void StartResetTimer()
        //{
        //    if (runningReset)
        //    {
        //        runningReset = !runningReset;
        //        StopCoroutine(resetTimer);
        //    }
        //    runningReset = !runningReset;
        //    resetTimer = StartCoroutine(ResetTimer());
        //}

        ////for 5 second rule
        //private IEnumerator ResetTimer()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        yield return new WaitForSeconds(1);
        //    }
        //    //cleanup
        //    //ResetClicks();
        //    //anim.SetInteger("numberOfClicks", numberOfClicks);
        //    //DoAction(numberOfClicks,target);
        //}
        //#endregion

        #region Do random
        public void DoRando()
        {
            int rand = Random.Range(1, 6);
            DoAction(rand,random);
        }
        #endregion

        #region helper methods
       
        public void ClickIncrease()
        {
            numberOfClicks++;
        }

        public void ResetClicks()
        {
            numberOfClicks = 0;
        }

        public void CleanUp(bool resetTimer)
        {
            if (!resetTimer)
            {
                anim.SetInteger("numberOfClicks", numberOfClicks);
                DoAction(numberOfClicks, target);
                ResetClicks();
            }
            else
            {
                ResetClicks();
                anim.SetInteger("numberOfClicks", numberOfClicks);
                DoAction(numberOfClicks, target);
            }
            
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
                    //anim.SetInteger("numberOfClicks", 2);
                    break;
                case 1:
                    //blue
                    target.GetComponent<Image>().color = Color.blue;
                    //anim.SetInteger("numberOfClicks", 1);
                    break;
                default:
                    //green
                    target.GetComponent<Image>().color = Color.green;
                    //anim.SetInteger("numberOfClicks", 0);
                    break;
            }
        }
        #endregion
    }
}
