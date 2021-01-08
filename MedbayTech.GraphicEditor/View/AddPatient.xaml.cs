using GraphicEditor.ViewModel;
using System;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;

namespace MedbayTech.GraphicEditor
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            DateTime dateOfBirth;
            if (!DateTime.TryParseExact(textBoxDateOfBirth.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                MessageBox.Show("Date of birth is not valid!");
                return;
            }
            if (textBoxDateOfBirth.Text.Equals("") || textBoxName.Text.Equals("") || textBoxSurname.Text.Equals("") || textBoxNameEmail.Text.Equals("") || textBoxPhone.Text.Equals(""))
            {
                MessageBox.Show("You didn't fill all informations!");
                return;
            }

            Patient patient = CreateNewPatient(dateOfBirth);
            SaveToDatabase(patient);
        }

        private void SaveToDatabase(Patient patient)
        {
            string jsonRoom = JsonConvert.SerializeObject(patient);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://localhost:53109/api/registration/", content);
            result.Wait();
            MessageBox.Show("Saved to database!");
            this.Close();
        }

        private Patient CreateNewPatient(DateTime dateOfBirth)
        {
            Patient patient = new Patient()
            {
                Id = DateTime.Now.ToString(),
              /*  Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                DateOfBirth = dateOfBirth,
                Phone = textBoxPhone.Text,
                Email = textBoxNameEmail.Text,
                Username = textBoxName.Text + textBoxSurname.Text + DateTime.Now.ToString(),
                Password = "guest",
                DateOfCreation = DateTime.Now,
                EducationLevel = EducationLevel.secondar,
                Profession = "patient",
                ProfileImage = "",
                Gender = Gender.FEMALE,
                PlaceOfBirthId = 21000,
                CurrResidenceId = 3,
                InsurancePolicyId = "policy1",
                IsGuestAccount = true,
                ChosenDoctorId = "2407978890043",
                Confirmed = true,
                Blocked = false,
                ShouldBeBlocked = false,
                Token = null*/
            };
            return patient;
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
