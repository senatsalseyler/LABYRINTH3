using System;
using Labyrinth3.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Labyrinth3.UI
{
    public class CountDown : MonoBehaviour
    {
        public float timeStart;
        private TMP_Text textBox;
        bool isGameStopped = false;

        private void OnGameStopEvent(GameStopEvent e)
        {
            isGameStopped = true;
        }

        private void OnGameResumeEvent(GameResumeEvent e)
        {
            isGameStopped = false;
        }

        private void OnTimePowerupPickupEvent(TimePowerupPickupEvent e)
        {
            timeStart += e.value;
        }

        private void Start()
        {
            textBox = transform.GetComponent<TMP_Text>();
            EventManager.AddListener<TimePowerupPickupEvent>(OnTimePowerupPickupEvent);
            EventManager.AddListener<GameStopEvent>(OnGameStopEvent);
            EventManager.AddListener<GameResumeEvent>(OnGameResumeEvent);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!isGameStopped)
            {
                timeStart -= Time.deltaTime;
                textBox.text = "" + Mathf.Round(timeStart);

                if (timeStart <= 0)
                {
                    LoseLevelEvent loseLevelEvent = Events.LoseLevelEvent;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    EventManager.Broadcast(loseLevelEvent);
                }
            }
        }


        private void OnDestroy()
        {
            EventManager.RemoveListener<TimePowerupPickupEvent>(OnTimePowerupPickupEvent);
        }
    }
}