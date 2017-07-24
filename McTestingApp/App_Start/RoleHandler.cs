using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McTestingApp.App_Start
{
    public static class RoleHandler
    {
        public static bool isLoggedIn(User user)
        {
            return user != null;
        }

        public static bool isLevel1(User user)
        {
            return isLoggedIn(user) && Role.Level1.ToString() == user.Role;
        }

        public static bool isAdmin(User user)
        {
            return isLoggedIn(user) && Role.Admin.ToString() == user.Role;
        }

        public static bool isLevel2(User user)
        {
            return isLoggedIn(user) && Role.Level2.ToString() == user.Role;
        }

        public static bool isLevel3(User user)
        {
            return isLoggedIn(user) && Role.Level3.ToString() == user.Role;
        }
    }

    public enum Role
    {
        Admin,
        Level1,
        Level2,
        Level3
    }

    public enum Designation
    {
        Assistant_Director_HR_Training,
        National_Manager_Training,
        Divisional_Manager_Training,
        Manager_Training,
        Assistant_Manager_Training,
        Training_Exective,
        Operation_Consultant,
        Resturant_Manager,
        First_Assistant_Manager,
        Second_Assistant_Manager,
        Trainee_Manager,
        Swing_Manager,
        Crew_Trainer,
        Crew
    }

}