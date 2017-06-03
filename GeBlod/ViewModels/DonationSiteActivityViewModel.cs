using System.Collections.ObjectModel;
using System.Net.Http;
using GeBlod.Models;
using Newtonsoft.Json;

namespace GeBlod.ViewModels
{
    public class DonationSiteActivityViewModel
    {
        private readonly string _url =
            @"https://geblod.nu/wp-content/themes/default/api/?type=schedule&rid=13&d1=2017/05/20&d2=2017/05/29";

        private readonly HttpClient _client = new HttpClient();
        public ObservableCollection<DonationSite> DonationSites { get; private set; } = new ObservableCollection<DonationSite>();

        public DonationSiteActivityViewModel()
        {
            LoadJson();
        }

        public async void LoadJson()
        {
            var response = await _client.GetStringAsync(_url);
            var schemeResponse = JsonConvert.DeserializeObject<SchemeResponse>(response);
            foreach (var donationSite in schemeResponse.Data)
            {
                DonationSites.Add(donationSite);
            }
        }
    }
}
