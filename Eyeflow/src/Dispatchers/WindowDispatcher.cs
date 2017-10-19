﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyeflow.Events;
using Eyeflow.Util;
using System.Timers;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Eyeflow.Dispatchers
{
    public class WindowDispatcher : Dispatcher
    {
        private event EventHandler<WindowEventArgs> WindowEvent;
        private static Logger log = Logger.get(typeof(WindowDispatcher));

        public void start()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(onTimerTick);
            timer.Interval = 3000;
            timer.Enabled = true;
        }

        protected void onTimerTick(object source, ElapsedEventArgs e)
        {
            onWindowEvent();
        }

        public void stop()
        {
            
        }

        public void addEventHandler(EventHandler<WindowEventArgs> handler)
        {
            WindowEvent += handler;
        }

        private void onWindowEvent()
        {
            WindowEvent(this, new WindowEventArgs());
        }
    }
}
