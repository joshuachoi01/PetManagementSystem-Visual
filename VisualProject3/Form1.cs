using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProject3
{
    public partial class Form1 : Form
    {
        Dictionary<int, Pet> petList = new Dictionary<int, Pet>();
        int nextId = 1;
        public Form1()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cmbType.Items.Count == 0)
            {
                cmbType.Items.Add("Dog");
                cmbType.Items.Add("Cat");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //gather info from form to add to specific object
            string name = txtName.Text.Trim();
            int age = (int)numAge.Value;
            string breed = cmbBreed.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(breed))
            {
                MessageBox.Show("Please enter all pet information.");
                return;
            }

            Pet pet = null;

            //checking for the type chosen
            if (cmbType.Text == "Dog")
            {
                pet = new Dog
                {
                    ID = nextId,
                    Name = name,
                    Age = age,
                    Breed = (Dog.DogBreed)Enum.Parse(typeof(Dog.DogBreed), breed)
                };
            }
            else if (cmbType.Text == "Cat")
            {
                pet = new Cat
                {
                    ID = nextId,
                    Name = name,
                    Age = age,
                    Breed = (Cat.CatBreed)Enum.Parse(typeof(Cat.CatBreed), breed)
                };
            }

            if (pet != null)
            {
                petList[nextId++] = pet;
                RefreshPetList();
            }
        }


        private void lstPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPets.SelectedItem == null) return;

            string selected = lstPets.SelectedItem.ToString();
            int id = int.Parse(selected.Split(':')[0]);
            Pet pet = petList[id];

            string breed = pet is Dog d ? d.Breed.ToString() : ((Cat)pet).Breed.ToString();

            lblDetails.Text =
                $"Name: {pet.Name}\n" +
                $"Age: {pet.Age}\n" +
                $"Breed: {breed}\n" +
                $"Says: {pet.MakeSound()}";
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBreed.Items.Clear();

            //adds list of breeds based on type chosen
            if (cmbType.Text == "Dog")
            {
                cmbBreed.Items.AddRange(Enum.GetNames(typeof(Dog.DogBreed)));
            }
            else if (cmbType.Text == "Cat")
            {
                cmbBreed.Items.AddRange(Enum.GetNames(typeof(Cat.CatBreed)));
            }
        }


        //used to refresh pet list
        private void RefreshPetList()
        {
            lstPets.Items.Clear();
            foreach (var pet in petList.Values)
            {
                lstPets.Items.Add($"{pet.ID}: {pet.Name} ({pet.GetType().Name})");
            }
        }

    }
}

