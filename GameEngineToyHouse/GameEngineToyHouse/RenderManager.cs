using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngineToyHouse
{
    public class RenderManager
    {
        struct Renderlet
        {

        }

        Renderlet[] m_renderlets;

        public void CollectJobs(JobManager manager)
        {
            // alot of this can be created onece and then just updated per frame

            int cpus = manager.CpuCount;
            int pos = 0;
            int elementsPerJob = (m_renderlets.Length / cpus) + 1;
            for (int i = 0; i < cpus; i++)
            {
                int elemntsInThisJob = elementsPerJob;
                if (pos + elemntsInThisJob > m_renderlets.Length)
                {
                    elemntsInThisJob = m_renderlets.Length - pos;
                }
                Renderlet[] work = new Renderlet[elemntsInThisJob];
                Buffer.BlockCopy(m_renderlets, pos, work, 0, elemntsInThisJob);

                Job job = new Job();
                job.AddJob<Renderlet[]>(RenderletWorker, work);
                manager.AddJob(job);

                pos += elementsPerJob;
            }

            // TODO : we require to depend on alle the render jobs to be finished
            Job pressent = new Job();
            pressent.AddJob(PresentWorker);
            manager.AddJob(pressent);
        }

        void RenderletWorker(Renderlet[] work)
        {

        }

        void PresentWorker()
        {

        }
    }
}
