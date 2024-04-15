namespace WinFormsApp_лаба_11_2
{
    class AEROFLOT
        {
            public string city;
            public string number;
            public string plane;

            public AEROFLOT(string city, string number, string plane)
            {
                this.city = city;
                this.number = number;
                this.plane = plane;
            }
            public string WhatCity()
            {
                return city;
            }
            public string Print()
            {
                return $"{city} {number} {plane}";
            }
            public string Print(string town)
            {
                return $"{number} {plane}";
            }
        }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<AEROFLOT> time_table = new List<AEROFLOT>();
        private void button1_Click(object sender, EventArgs e)
        {
            string[] cities = { "Сочи", "Москва", "Красноярск", "Владивосток", "Стамбул", "Кемерово" };
            string[] numbers = { "45F664", "24H74H", "63HJ48", "48HBX9", "238JBH92" };
            string[] planes = { "Boeing 737", "Boeing 777", "Airbus А319", "Airbus А320", "Superjet 100" };
            Random random = new Random();
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            time_table.Add(new AEROFLOT(cities[random.Next(0, 6)], numbers[random.Next(0, 5)], planes[random.Next(0, 5)]));
            for (int i = 0; i < time_table.Count; i++)
                listBox1.Items.Add(time_table[i].Print());
            using (StreamWriter writer = new StreamWriter("C:\\Users\\zanko\\Desktop\\AEROFLOT.txt", false))
            {
                for (int i = 0; i < time_table.Count; i++)
                    writer.WriteLine(time_table[i].Print());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                    listBox1.Items.Clear();
            }
            if (time_table.Count != 0)
                time_table.Clear();
            using (StreamReader reader = new StreamReader("C:\\Users\\zanko\\Desktop\\AEROFLOT.txt"))
            {
                string content = reader.ReadToEnd();
                string[] str_sentens = content.Split('\n');
                for (int k = 0; k < str_sentens.Length -1; k++)
                {
                    string[] zabiv = str_sentens[k].Split(' ');
                    time_table.Add(new AEROFLOT(zabiv[0], zabiv[1], $"{zabiv[2]} {zabiv[3]}"));
                }
                foreach (string str in str_sentens)
                    listBox1.Items.Add(str);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
                listBox2.Items.Clear();
            byte count = 0;
            if (textBox1.Text != null)
            {
                for (int j = 0; j < time_table.Count; j++)
                {
                    if (textBox1.Text == time_table[j].WhatCity())
                    { listBox2.Items.Add(time_table[j].Print(textBox1.Text)); count = 1; }
                }
                if (count != 1)
                    listBox2.Items.Add("Таких рейсов нет! Выберете другой город");
            }
        }
    }
}
