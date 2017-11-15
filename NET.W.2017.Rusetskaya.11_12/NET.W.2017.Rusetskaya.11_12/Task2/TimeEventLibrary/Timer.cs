using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeEventLibrary
{
    #region TimerEventArgs
    public sealed class TimerEventArgs : EventArgs
    {
        private readonly string message;
        private int time;

        public TimerEventArgs(int time, string message = "")
        {
            if (ReferenceEquals(message, null))
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {
                this.message = message;
            }

            if (time > 0)
            {
                this.time = time;
            }
        }

        public string Message => message;
        public int Time => time;
    }
    #endregion

    #region MessageManager
    public class MessageManager
    {
        public delegate void NewTimerEventHandler(object sender, TimerEventArgs timerEventArgs);

        public event NewTimerEventHandler NewMessage;

        protected virtual void OnNewMessage(object sender, TimerEventArgs timerEventArgs)
        {
            if (!ReferenceEquals(NewMessage,null))
            {
                Thread.Sleep(timerEventArgs.Time);
                NewMessage(sender, timerEventArgs);
            }
        }

        public void SimulateNewMessage(int time, string message)
        {
            OnNewMessage(this, new TimerEventArgs(time, message));
        }
    }
    #endregion

    #region Listeners
    public sealed class FirstSubscriber
    {
        public FirstSubscriber(MessageManager message)
        {
            message.NewMessage += FirstSubMsg;
        }

        public FirstSubscriber()
        {
        }

        public void Register(MessageManager message)
        {
            message.NewMessage += FirstSubMsg;
        }

        private void FirstSubMsg(object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine($"First subscriber message: {eventArgs.Message}, time: {eventArgs.Time}");
        }

        public void Unregister(MessageManager message)
        {
            message.NewMessage -= FirstSubMsg;
        }
    }

    public class SecondSubscriber
    {
        public SecondSubscriber(MessageManager message)
        {
            message.NewMessage += SecondSubMsg;
        }

        public SecondSubscriber()
        {
        }

        private void SecondSubMsg(Object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine($"Second subscriber message: {eventArgs.Message}, time: {eventArgs.Time}");
        }

        public void Unregister(MessageManager message)
        {
            message.NewMessage -= SecondSubMsg;
        }

        public void Register(MessageManager message)
        {
            message.NewMessage += SecondSubMsg;
        }
    }
    #endregion
}
