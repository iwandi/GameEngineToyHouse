using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngineToyHouse
{
    public class LoopManager
    {
        JobManager job;
        RenderManager render;

        public bool Active { get; set; }
        
        public void Init()
        {
            job = new JobManager();
            render = new RenderManager();
        }

        public void Run()
        {
            Active = true;
            RunWorker();
        }

        void RunWorker()
        {
            while (Active)
            {
                RunUpdate();
            }
        }

        void RunUpdate()
        {
            render.CollectJobs(job);
            job.ExcuteJobs();
        }

        public void Stop()
        {
            Active = false;
        }

        public void DeInit()
        {

        }
    }
}
