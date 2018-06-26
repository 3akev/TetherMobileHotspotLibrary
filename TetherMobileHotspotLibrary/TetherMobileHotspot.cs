using System;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Networking.NetworkOperators;

namespace TetherMobileHotspotLibrary
{
    public class TetherMobileHotspot
    {
        private NetworkOperatorTetheringManager tetheringManager;

        public TetherMobileHotspot()
        {
            ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            tetheringManager = NetworkOperatorTetheringManager.CreateFromConnectionProfile(InternetConnectionProfile);
        }

        public TetheringOperationStatus StartTethering()
        {
            return StartTetheringAsync().GetAwaiter().GetResult();
        }

        public async Task<TetheringOperationStatus> StartTetheringAsync()
        {

            NetworkOperatorTetheringOperationResult result = await tetheringManager.StartTetheringAsync();
            return result.Status;
        }

        public TetheringOperationalState GetTetheringOperationalState()
        {
            return tetheringManager.TetheringOperationalState;
        }

        public String GetClientCount()
        {
            return tetheringManager.ClientCount.ToString() + " / " + tetheringManager.MaxClientCount.ToString();
        }
    }
}
