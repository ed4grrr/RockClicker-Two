using System;


using System.Timers;

namespace RockClicker_Two
{
    public class GameCycle
    /// <summary>
    /// This class is used to create a timer that triggers a game cycle at specified intervals.
    {
        private Timer _timer; // Timer object to handle the game cycle timing

        
        public event EventHandler CyclePassed; // Define the event using EventHandler

        private const int DefaultInterval = 1; // Default interval in seconds

        public GameCycle(int seconds = DefaultInterval)
        /// <summary>
        /// Initializes a new instance of the GameCycle class.
        /// 
        /// This class is used to create a timer that triggers a game cycle at specified intervals.
        /// </summary>
        /// 
        /// <param name="seconds">The interval in seconds for the game cycle.</param>
        {
            _timer = new Timer(seconds*1000); // Set the interval to 1 second (1000 milliseconds)
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true; // Ensure the timer repeats
            _timer.Enabled = true; // Start the timer
        }

        internal void changeInterval(int seconds)
        /// <summary>
        /// used to change how often a game cycle occurs
        ///</summary>
        ///
        /// <param name="seconds">The new interval in seconds.</param>
        /// <param name="e">data about the timer elapsed event </param>"
        {
            if (_timer != null)
            {
                _timer.Interval = seconds *1000; // Change the timer interval
            }
        }

        // Method to handle the timer's Elapsed event
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        /// <summary>
        /// creates the event that is raised when the timer elapses
        /// 
        /// The timer elapsing serves as a game cycle.
        /// </summary>
        /// 
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">data about the timer elapsed event </param> 
        {
            // Raise the CyclePassed event
            CyclePassed?.Invoke(this, EventArgs.Empty);
        }


        // Method to stop the timer
        internal void Pause()
        /// <summary>
        ///     Used to pause the timer
        ///     </summary>    
        {
            if (_timer != null)
            {
                _timer.Enabled = false; // Stop the timer
            }
        }

        // Method to resume the timer
        internal void Resume()
        /// <summary>
        /// used to resume the timer
        /// </summary>
        {
            if (_timer != null)
            {
                _timer.Enabled = true; // Start the timer
            }
        }
    }
}


