using System.Collections.Generic;
using SuperCoolLibrary.CoolStuff.NameCheckers;

namespace SuperCoolLibrary.CoolStuff
{
    public class NameManager : INameManager
    {
        public PopCultureNameModel GetModel(string name)
        {
            //logging - name to check

            var nameCheckers = new List<ICheckNames>
            {
                new ScoobyDooNameChecker(),
                new SmurfNameChecker(),
                new GameOfThronesChecker()
            };

            foreach (var nameChecker in nameCheckers)
            {
                //logging - current name checker

                if (nameChecker.CheckName(name))
                {
                    //logging - we have a match

                    return new PopCultureNameModel
                    {
                        Name = name,
                        NameChecker = nameChecker.GetType().Name,
                        FriendlyName = nameChecker.FriendlyName
                    };
                }
            }

            //logging - we didn't find anything!

            return new PopCultureNameModel
            {
                Name = name,
                NameChecker = "Unknown",
                FriendlyName = "Unknown!"
            };
        }
    }
}
