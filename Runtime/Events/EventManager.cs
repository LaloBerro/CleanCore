﻿//Robado de aca jeje
//https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#5cf5960fedbc2a281acd21fa

using UnityEngine.Events;
using System.Collections.Generic;
using CleanCore.Patterns;

namespace CleanCore.Managers
{
    public class EventManager : Singleton<EventManager>
    {
        public bool dontDestroyOnload;

        private Dictionary<string, UnityEvent> eventDictionary;

        private void Awake()
        {
            if (dontDestroyOnload)
                if (Instance != this)
                    Destroy(gameObject);
                else
                    DontDestroyOnLoad(this);

            Init();
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (Instance == null) return;

            if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(string eventName)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}