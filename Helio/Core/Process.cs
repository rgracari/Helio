using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Core
{
    public enum ProcessState
    {
        UNINITIALIZED = 0,
        REMOVED,
        RUNNING,
        PAUSED,
        SUCCEEDED,
        FAILED,
        ABORTED
    }

    public abstract class Process
    {

        private ProcessState _state;
        private Process? _child;

        // Le constructeur
        public Process()
        {
            _state = ProcessState.UNINITIALIZED;
        }

        public void Succeed()
        {
            Debug.Assert((_state == ProcessState.RUNNING || _state == ProcessState.PAUSED));
            _state = ProcessState.SUCCEEDED;
        }

        public void Fail()
        {
            Debug.Assert((_state == ProcessState.RUNNING || _state == ProcessState.PAUSED));
            _state = ProcessState.FAILED;
        }

        public void Pause()
        {
            Debug.Assert(_state == ProcessState.RUNNING, "Attemp to pause a process who isn't running");
            _state = ProcessState.PAUSED;
        }

        public void UnPause()
        {
            Debug.Assert(_state == ProcessState.PAUSED, "Attemp to unpause a process who was running");
            _state = ProcessState.RUNNING;
        }

        // The interface
        public virtual void OnInit() => _state = ProcessState.RUNNING;
        public abstract void OnUpdate(GameTime deltaTime);
        public virtual void OnSuccess() { }
        public virtual void OnFail() { }
        public virtual void OnAbort() { }
        public virtual void OnDestroy()
        {
            if (_child != null)
            {
                _child.OnAbort();
            }
        }
    
        // State manipulation
        public ProcessState GetState() => _state;
        public void SetState(ProcessState processState) => _state = processState;
        public bool IsAlive() => (_state == ProcessState.RUNNING || _state == ProcessState.PAUSED);
        public bool IsDead() => (_state == ProcessState.SUCCEEDED || _state == ProcessState.FAILED || _state == ProcessState.ABORTED);
        public bool IsRemoved() => (_state == ProcessState.REMOVED);
        public bool IsPaused() => (_state == ProcessState.PAUSED);

        public void AttachChild(Process childProcess)
        {
            if (_child != null)
                _child.AttachChild(childProcess);
            else
                _child = childProcess;
        }

        public Process? RemoveChild()
        {
            return _child;
        }

        public Process? PeekChild() => _child;
    }
}
