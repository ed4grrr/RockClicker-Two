using System;


using System.Timers;

public class GameCycle
{
    private Timer _timer;

    // Define the event using EventHandler
    public event EventHandler CyclePassed;

    public GameCycle(int seconds=1000)
    {
        _timer = new Timer(seconds); // Set the interval to 1 second (1000 milliseconds)
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true; // Ensure the timer repeats
        _timer.Enabled = true; // Start the timer
    }

    // Method to handle the timer's Elapsed event
    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Raise the CyclePassed event
        CyclePassed?.Invoke(this, EventArgs.Empty);
    }
}



