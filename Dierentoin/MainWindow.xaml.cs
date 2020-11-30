using Dierentoin.Data;
using Dierentoin.Data.Animals;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Dierentoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDictionary<Animal, AnimalTab> Animals = new Dictionary<Animal, AnimalTab>();

        public MainWindow()
        {
            InitializeComponent();
            AddDefaultAnimals();
            CreateTimer();
        }

        private void CreateTimer()
        {
            var timer = new Timer(500);

            timer.Elapsed += Tick;
            timer.AutoReset = true;
            timer.Start();
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            foreach (var animal in Animals)
            {
                animal.Key.UseEnergy();

                if (animal.Key.Energy <= 0)
                {
                    Animals.Remove(animal);

                    AnimalsTabs.Dispatcher.Invoke(new Action(() => {
                        AnimalsTabs.Items.Remove(animal.Value);
                        AnimalsTabs.Items.Refresh();
                    }), DispatcherPriority.Normal);

                    continue;
                }

                animal.Value.EnergyChanged();
            }
        }

        private void AddElephant(object sender, RoutedEventArgs e)
        {
            var animal = new Elephant();
            AddAnimal(animal);
        }

        private void AddLion(object sender, RoutedEventArgs e)
        {
            var animal = new Lion();
            AddAnimal(animal);
        }

        private void AddMonkey(object sender, RoutedEventArgs e)
        {
            var animal = new Monkey();
            AddAnimal(animal);
        }

        private void AddAnimal(Animal animal)
        {
            var animalTab = new AnimalTab(animal);
            Animals.Add(animal, animalTab);

            AnimalsTabs.Items.Add(animalTab);

            AnimalsTabs.SelectedIndex = Animals.Count - 1;
        }

        private void AddDefaultAnimals()
        {
            var elephant = new Elephant();
            elephant.Name = "die ene met de slurf";
            AddAnimal(elephant);

            var lion = new Lion();
            lion.Name = "Lion the Gamer";
            AddAnimal(lion);

            var monkey = new Monkey();
            monkey.Name = "Joe";
            AddAnimal(monkey);

            var monkey1 = new Monkey();
            monkey1.Name = "monke";
            AddAnimal(monkey1);
        }
    }
}
