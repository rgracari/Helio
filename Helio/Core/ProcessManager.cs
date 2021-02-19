using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Core
{
    public class ProcessManager
    {
        private List<Process> _processes;
        private List<Process> _processesToDestroyed;
        private List<Process> _processesToAttach;

        public ProcessManager()
        {
            _processes = new List<Process>();
            _processesToDestroyed = new List<Process>();
            _processesToAttach = new List<Process>();
        }

        public int UpdateProcesses(GameTime deltaTime)
        {
            int successCount = 0;
            int failCount = 0;

            foreach (Process process in _processes)
            {
                if (process.GetState() == ProcessState.UNINITIALIZED)
                    process.OnInit();

                if (process.GetState() == ProcessState.RUNNING)
                    process.OnUpdate(deltaTime);
                
                if (process.IsDead())
                {
                    switch (process.GetState())
                    {
                        case ProcessState.SUCCEEDED:
                            process.OnSuccess();
                            Process? childProcess = process.RemoveChild();
                            if (childProcess != null)
                                _processesToAttach.Add(childProcess);
                            else
                                ++successCount;
                            break;
                        
                        case ProcessState.FAILED:
                            process.OnFail();
                            ++failCount;
                            break;

                        case ProcessState.ABORTED:
                            process.OnAbort();
                            ++failCount;
                            break;

                        default:
                            Logger.Error($"Process Manager -> {process.GetState()} shouldn't be this state here");
                            break;
                    }
                    _processesToDestroyed.Add(process);
                }
            }

            foreach (Process process in _processesToDestroyed)
            {
                process.OnDestroy();
                _processes.Remove(process);
            }
            _processesToDestroyed.Clear();

            foreach (Process process in _processesToAttach)
            {
                AttachProcess(process);
            }
            _processesToAttach.Clear();

            return (successCount - failCount);
        }

        public Process AttachProcess(Process process)
        {
            _processes.Add(process);
            return process;
        }

        public void AbortAllProcesses(bool immediate)
        {
            foreach (Process process in _processes)
            {
                if (process.IsAlive())
                {
                    process.SetState(ProcessState.ABORTED);
                    if (immediate)
                    {
                        process.OnAbort();
                        _processes.Remove(process);
                    }
                }
            }
        }

        public int GetProcessCount() => _processes.Count;

        public void ClearAllProcesses()
        {
            foreach (Process process in _processes)
            {
                process.OnDestroy();
            }
            _processes.Clear();
        }
    }
}
