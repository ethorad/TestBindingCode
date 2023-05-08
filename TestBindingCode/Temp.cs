using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestBindingCode
{
    class Temp : INotifyPropertyChanged
    {
        private Dictionary<AgeGroup, string[]> foodsBasedOnAge = new Dictionary<AgeGroup, string[]>
        {
            { AgeGroup.Baby, new string[] { "Milk", "Baby Food" } },
            { AgeGroup.Child, new string[] { "Milk", "Carrots", "Cookies" } },
            { AgeGroup.Teen, new string[] { "Soda", "Tacos", "Pizza" } },
            { AgeGroup.Adult, new string[] { "Wine", "Steak", "Baked Potato" } },
            { AgeGroup.Senior, new string[] { "Bourbon", "Corned Beef", "Cabbage" } }
        };
        public ObservableCollection<string> FoodList { get; set; } = new ObservableCollection<string>();

        private string selectedFood;
        public string SelectedFood
        {
            get { return selectedFood; }
            set { selectedFood = value; OnPropertyChanged("SelectedFood"); }
        }

        private int num;
        public int Num
        {
            get { return num; }
            set { num = value; OnPropertyChanged("Num"); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (age == value) return;

                UpdateFoodlistBasedOnAge(value);
                age = value;
                OnPropertyChanged("Age");
            }
        }

        private void UpdateFoodlistBasedOnAge(int value)
        {
            AgeGroup ageGroup = AgeGroup.Baby;

            if (value < 2)
            {
                ageGroup = AgeGroup.Baby;
            }
            else if (value < 13)
            {
                ageGroup = AgeGroup.Child;
            }
            else if (value < 20)
            {
                ageGroup = AgeGroup.Teen;
            }
            else if (value < 65)
            {
                ageGroup = AgeGroup.Adult;
            }
            else
            {
                ageGroup = AgeGroup.Senior;
            }

            LoadFoodList(foodsBasedOnAge[ageGroup]);
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public Temp()
        {
            LoadFoodList(foodsBasedOnAge[0]);
        }

        private void LoadFoodList(string[] strings)
        {
            FoodList.Clear();
            for (int i = 0; i < strings.Length; i++)
            {
                FoodList.Add(strings[i]);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
