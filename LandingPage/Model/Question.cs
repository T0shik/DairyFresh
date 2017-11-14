using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPage.Model
{
    public class Question
    {
        public int Id { get; set; }
        //Would you use a service like this?
        public string Question1 { get; set; }
        //What time would you like to recieve your milk?
        public string Question2 { get; set; }
        //Payment Methods?
        public string Question3 { get; set; }
        //Other Products?
        public string Question4 { get; set; }
        //How would you prefer to use this service Website vs App?
        public string Question5 { get; set; }
        //How much milk would you purchase a week?
        public string Question6 { get; set; }
        public string Comments { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PostCode { get; set; }
    }
}
