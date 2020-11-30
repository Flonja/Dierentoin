using Dierentoin.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Dierentoin
{
    /// <summary>
    /// Interaction logic for AnimalTab.xaml
    /// </summary>
    public partial class AnimalTab : TabItem
    {
        public AnimalTab(Animal animal)
        {
            Animal = animal;
            InitializeComponent();

            AnimalType.Content = animal.GetType().Name + ":";

            Header = animal.Name;
            AnimalName.Text = animal.Name;
            AnimalName.TextChanged += NameChanged;

            AnimalEnergy.Value = animal.Energy;
            AnimalEnergy.Maximum = animal.Energy;

            AnimalEnergyText.Content = "Energy: " + animal.Energy;
        }

        public Animal Animal { get; set; }

        private void NameChanged(object sender, TextChangedEventArgs e)
        {
            Animal.Name = AnimalName.Text;

            Header = Animal.Name;
            AnimalName.Text = Animal.Name;
        }

        private void Eat(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => {
                Animal.Eat();
            }), DispatcherPriority.Normal);

            EnergyChanged();
        }

        public void EnergyChanged()
        {
            Dispatcher.Invoke(new Action(() => {
                AnimalEnergy.Value = Animal.Energy;

                if (Animal.Energy > AnimalEnergy.Maximum)
                {
                    AnimalEnergy.Maximum = Animal.Energy;
                }

                AnimalEnergyText.Content = "Energy: " + Animal.Energy;
            }), DispatcherPriority.Normal);
        }
    }
}
