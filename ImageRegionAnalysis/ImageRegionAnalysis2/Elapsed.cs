using System;
using System.Collections.Generic;

namespace ImageRegionAnalysis2
{
    public class Elapsed
    {
        const string CLASSNAME = "Elapsed";

        public string ownerLocation = "";
        public string processName = "";

        public int cntStarted = 0;
        public int cntEnded = 0;

        private double elapsed = 0;// ms
        private double elapsedIdle = 0;// ms
        private DateTime timeStart { get; set; }
        private DateTime timeEnd { get; set; }

        private DateTime timeLastStarted { get; set; }
        private DateTime timeLastEnded { get; set; }

        private bool isRunning = false;// may not use, may be up to caller to screw things up on their own instead

        public DateTime Start => this.timeStart;
        public DateTime End => this.timeEnd;
        public bool IsRunning => this.isRunning;

        private DateTime nDt = new DateTime();

        public Elapsed() { }

        public Elapsed(bool startTiming)
        {
            if (startTiming && !this.start())
            {
                L.err(CLASSNAME + ".Constructor", "Failed to start timer.");
            }
        }

        public Elapsed(string ownLocation, string processNameFriendly)
        {
            this.ownerLocation = ownLocation == null ? "" : ownLocation;
            this.processName = processNameFriendly == null ? "" : processNameFriendly;
        }

        public Elapsed(string ownLocation, string processNameFriendly, bool startTiming)
        {
            this.ownerLocation = ownLocation == null ? "" : ownLocation;
            this.processName = processNameFriendly == null ? "" : processNameFriendly;
            if (startTiming && !this.start())
            {
                L.err(CLASSNAME + ".Constructor", "Failed to start timer.");
            }
        }


        public bool end()
        {
            this.timeLastEnded = DateTime.Now;
            this.timeEnd = this.timeLastEnded;
            this.isRunning = false;
            this.cntEnded++;

            if (this.timeStart == null || this.timeStart == this.nDt) return false;
            if (this.timeLastEnded < this.timeLastStarted) return false;

            TimeSpan timeSpan = this.timeLastEnded - this.timeLastStarted;
            this.elapsed += timeSpan.TotalMilliseconds;

            return !this.isRunning;
        }

        public bool start()
        {
            this.timeLastStarted = DateTime.Now;
            if (this.timeStart == null || this.timeStart == this.nDt) this.timeStart = this.timeLastStarted;
            //if (this.timeStart == null) this.timeStart = DateTime.Parse(this.timeLastStarted.ToString(L.TAG.DTF));
            this.isRunning = true;
            this.cntStarted++;
            return this.isRunning;
        }

        public double getElapsed()
        {// allow checking elapsed while running
            return this.elapsed;
        }

        public double getIdleTime()
        {
            if (this.timeStart == null) return -1;
            if (this.timeEnd == null) return -1;
            if (this.timeEnd < this.timeStart) return -1;
            if (this.elapsed <= 0) return -1;
            TimeSpan timeSpan = this.timeEnd - this.timeStart;
            this.elapsedIdle = timeSpan.TotalMilliseconds - this.elapsed;
            return this.elapsedIdle;
        }

        public string toString()
        {
            return
                "Process (" + (this.processName == null ? "Unknown Process" : this.processName).PadLeft(30) +
                "), Elapsed (" + this.elapsed +
                "), Idle (" + this.elapsedIdle +
                "), Started (" + this.cntStarted +
                "), Stopped (" + this.cntEnded +
                "), Start Time (" + (this.timeStart == null ? "not started" : this.timeStart.ToString(L.TAG.DTF)) +
                "), Stop Time (" + (this.timeEnd == null ? "not stopped" : this.timeEnd.ToString(L.TAG.DTF)) +
                "), Owner (" + (this.ownerLocation == null ? "Unknown.Owner" : this.ownerLocation) + ").";
            /*return
                "Elapsed (" + this.elapsed +
                "), Idle (" + this.elapsedIdle +
                "), Process (" + (this.processName == null ? "Unknown Process" : this.processName) +
                "), Started (" + this.cntStarted +
                "), Stopped (" + this.cntEnded +
                "), Start Time (" + (this.timeStart == null ? "not started" : this.timeStart.ToString(L.TAG.DTF)) +
                "), Stop Time (" + (this.timeEnd == null ? "not stopped" : this.timeEnd.ToString(L.TAG.DTF)) +
                "), Owner (" + (this.ownerLocation == null ? "Unknown.Owner" : this.ownerLocation) + ").";*/
        }

        public string toUiString()// Separate ui from log format if needed
        {
            return this.toString();
        }

        public List<List<string>> toGrid()// TODO - Later, need to get headers and data in same order
        {
            const string location = CLASSNAME + ".toGridForm";
            List<List<string>> retVal = new List<List<string>>();
            try
            {

            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

    }
}
