using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Mars : Global.Base
        {

            
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
               // test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();

            }
            [Test]
            public void AddSkill()
            {
                SkillSharePage skillObj = new SkillSharePage();
                skillObj.SkillShare();
                skillObj.ValidateTheSkillAdded();

            }
            [Test]
            public void DeleteSkill()
            { 
            
                ManageListingsPage manageListingObj = new ManageListingsPage();
                manageListingObj.DeleteListing();
                manageListingObj.ValidatedDeletedSkills();

            }
            [Test]

            public void UpdateSkill()
            {
                ManageListingsPage updateSkillObj = new ManageListingsPage();
                updateSkillObj.UpdatedListing();
            }

        }
    }
}