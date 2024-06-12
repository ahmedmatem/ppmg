using Timer = System.Windows.Forms.Timer;
using static Click_Maniac.Constants;

namespace Click_Maniac
{
    public partial class Form1 : Form
    {
        private Board board = new Board(0);
        private Timer timer = new Timer();
        private long timeInMillisLeft = LevelDurationInMillis;

        public Form1()
        {
            InitializeComponent();

            board
                .CreatTiles()
                .LoadIn(panelGameBoard);

            long minsLeft = timeInMillisLeft / 1000 / 60;
            long secondsLeft = (timeInMillisLeft / 1000) % 60;
            textBoxTimer.Text = $"{minsLeft:00}:{secondsLeft:00}";
        }

        private void OnStart(object sender, EventArgs e)
        {
            timer.Start();
            timer.Interval = 1000; // ms
            timer.Tick += new EventHandler(TimerHandler);
        }

        private void TimerHandler(object? sender, EventArgs e)
        {
            timeInMillisLeft -= timer.Interval;
            long minsLeft = timeInMillisLeft / 1000 / 60;
            long secondsLeft = (timeInMillisLeft / 1000) % 60;
            textBoxTimer.Text = $"{minsLeft:00}:{secondsLeft:00}";
        }
    }
}
