using System;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCore.Processor
{
    public class Processor : IProcess
    {
        #region Var

        private Queue<IProcess> _processes = new Queue<IProcess>();
        private IProcess _currentProcess;

        #endregion

        #region Properties      

        public int Progress { get { return 100 / (_processes.Count + 1); } set { } }

        public Action OnDone { get; set; }

        #endregion

        #region Methods

        public Processor() { }

        public Processor(Queue<IProcess> processes) => _processes = processes;

        /// <summary>
        /// Add process to the queue
        /// </summary>
        /// <param name="process"></param>
        public void AddProcess(IProcess process)
        {
            _processes.Enqueue(process);
        }

        /// <summary>
        /// Start the processor
        /// </summary>
        public void Execute()
        {           
            try
            {
                SetCurrentProcess();
                Debug.Log("The Processor is started");
            }
            catch(Exception e)
            {
                throw new Exception("The processor is empty " + e);
            }
        }

        /// <summary>
        /// Set the current process and execute 
        /// </summary>
        private void SetCurrentProcess()
        {
            _currentProcess = _processes.Dequeue();
            _currentProcess.OnDone += OnCurrentProcessDone;
            _currentProcess.Execute();

            Debug.Log("The current process is setted ");
        }

        /// <summary>
        /// When the current process end, start the next process
        /// </summary>
        private void OnCurrentProcessDone()
        {
            Debug.Log("The currrent process is done");

            if (_processes.Count <= 0) Done();

            else SetCurrentProcess();
        }

        /// <summary>
        /// When all process are finished
        /// </summary>
        public void Done()
        {
            Debug.Log("All processes are done");
            OnDone?.Invoke();
        }

        #endregion
    }
}