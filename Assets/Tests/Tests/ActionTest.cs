using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class ActionTest
    {
        public BtnActionTest actionsT;
        
        [SetUp]
        public void Setup()
        {
            actionsT = new BtnActionTest();
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ClickIncreaseTest()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
            actionsT.ClickIncrease();
            Assert.AreEqual(actionsT.numberOfClicks, 1);
        }
        /// <summary>
        /// test of reset clicks
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator ResetClicksTest()
        {
            yield return null;
            actionsT.numberOfClicks = 5;
            Assert.AreEqual(actionsT.numberOfClicks, 5);
            actionsT.ResetClicks();
            Assert.AreEqual(actionsT.numberOfClicks, 0);
        }
        /// <summary>
        /// Statemachine default state, access test
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator StateMachineAccess0Test()
        {
            yield return null;
            actionsT.DoAction(0);
            Assert.AreEqual(actionsT.stateNumber, 0);
        }
        /// <summary>
        /// Statemachine first state, access test
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator StateMachineAccess1Test()
        {
            yield return null;
            
            actionsT.DoAction(1);
            Assert.AreEqual(actionsT.stateNumber, 1);
        }
        /// <summary>
        /// Statemachine 2nd state, access test
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator StateMachineAccess2Test()
        {
            yield return null;
          
            actionsT.DoAction(2);
            Assert.AreEqual(actionsT.stateNumber, 2);
           
        }
        /// <summary>
        /// Statemachine 5th state access test
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator StateMachineAccess5Test()
        {
            yield return null;            
            actionsT.DoAction(5);
            Assert.AreEqual(actionsT.stateNumber, 5);
            
        }

        /// <summary>
        /// Accessing doAction(3) should yield a default state of 0, since no state has yet been defined
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator StateMachineAccess3Test()
        {
            yield return null;            
            actionsT.DoAction(3);
            Assert.AreEqual(actionsT.stateNumber, 0);
        }

    }

    public class BtnActionTest
    {
        public Button target;
        public int numberOfClicks,stateNumber;
        public bool running;
        

        public BtnActionTest()
        {
            numberOfClicks = 0;
            stateNumber = 0;
        }
        public void ClickIncrease()
        {
            numberOfClicks++;
        }
        public void ResetClicks()
        {
            numberOfClicks = 0;
        }

        public void DoAction(int numberOfClicks)
        {
            switch (numberOfClicks)
            {
                case 5:
                    //change to magenta
                    stateNumber = 5;
                    //target.GetComponent<Image>().color = Color.magenta;
                    break;
                case 2:
                    //red
                    stateNumber = 2;
                    //target.GetComponent<Image>().color = Color.red;
                    break;
                case 1:
                    //blue
                    stateNumber = 1;
                    //target.GetComponent<Image>().color = Color.blue;
                    break;
                default:
                    //green
                    stateNumber = 0;
                    //target.GetComponent<Image>().color = Color.green;
                    break;
            }
        }
    }
}
