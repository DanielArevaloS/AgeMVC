namespace CalculaEdadMVC
{
    public class MenuController
    {
        private UserModel user;
        private MenuView menu;

        public MenuController()
        {
            user = new UserModel();
            menu = new MenuView();
        }

        public void ManageMenu()
        {
            menu.ShowWelcome();
            GetName();
            GetMenu();
            GetFormat();
        }

        public void GetName()
        {
            string name = menu.GetNameInput();
            user.Name = name;

        }

        public void GetMenu()
        {
            int opcion = menu.ShowMenu(user.Name);
            switch (opcion)
            {
                case 1:
                        user.BirthDate = menu.ShowBirthDate(user.Name);
                        break;
                default:
                    GetMenu(); break;
            }
        }


        public void GetFormat()
        {
            int opcion = menu.ShowBirthFormat(user.Name);
            switch (opcion)
            {
                case 1:
                        AgeModel age = user.CalculateAgeMonthDay();
                        menu.ShowAgeMonthDay(age.Years, age.Months, age.Days);
                        break;
                    case 2:
                        int years = user.CalculateAge();
                        menu.ShowAge(years);
                        break;
                    default:
                        GetFormat(); 
                        break;
            }
        }

    }
}
