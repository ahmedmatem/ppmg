namespace Travel_Map
{
#nullable disable
    public partial class Form1 : Form
    {
        private string source = string.Empty;
        private string destination = string.Empty;
        private int[] paths;
        private int[] distance;

        private Dictionary<string, int> cities = new Dictionary<string, int>()
        {
            { "София", 1},
            { "Пловдив", 2},
            { "Варна", 3},
            { "Бургас", 4},
            { "Русе", 5},
            { "Стара Загора", 6},
            { "Благоевград", 7},
            { "Велико Търново", 8},
            { "Плевен", 9},
            { "Разград", 10},
        };

        private int[,] map = new int[,]
        {
            //  0   1   2   3   4   5   6   7   8   9   10
              { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0 },  // 0
              { 0,  0,144,  0,  0,  0,  0,100,  0,100,   0 },  // 1 София
              { 0,144,  0,  0,  0,  0,103,236,221,  0,   0 },  // 2 Пловдив
              { 0,  0,  0,  0,130,  0,  0,  0,  0,  0, 130 },  // 3 Варна
              { 0,  0,  0,130,  0,  0,172,  0,215,  0,   0 },  // 4 Бургас
              { 0,  0,  0,  0,  0,  0,  0,  0,108,150,  70 },  // 5 Русе
              { 0,  0,103,  0,172,  0,  0,  0,  0,  0,   0 },  // 6 Стара Загора
              { 0,100,236,  0,  0,  0,  0,  0,  0,  0,   0 },  // 7 Благоевград
              { 0,  0,221,  0,215,108,  0,  0,  0,120, 134 },  // 8 Велико Търново
              { 0,100,  0,  0,  0,150,  0,  0,120,  0,   0 },  // 9 Плевен
              { 0,  0,  0,130,  0, 70,  0,  0,134,  0,   0 },  //10 Разград
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            source = comboBoxFrom.SelectedItem.ToString();
            destination = comboBoxTo.SelectedItem.ToString();
            distance = new int[cities.Count + 1];
            paths = Dijkstra.DijkstraAlgorithm(cities.Count, map, cities[source], distance);

            var path = GetPath();
            labelPath.Text = path.Track;
            labelDistance.Text = path.Distance + "km";
        }

        private Path GetPath()
        {
            var result = new Path();
            Stack<string> citiesOnTheReversedPath = new Stack<string>();

            int destIndexOrigin = cities[destination];

            do
            {
                citiesOnTheReversedPath.Push(destination);
                int destinationIndex = cities[destination];
                int prevNodeIndex = paths[destinationIndex];
                destination = cities.First(c => c.Value == prevNodeIndex).Key;
            } while (destination != source);

            citiesOnTheReversedPath.Push(source);

            while(citiesOnTheReversedPath.Count > 0)
            {
                result.Track += citiesOnTheReversedPath.Pop() + " --> ";
            }
            result.Track = result.Track.Trim(' ', '-', '>');

            result.Distance = distance[destIndexOrigin].ToString();
            return result;
        }
    }
}
