
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using GeBlod.Models;
using Newtonsoft.Json;

namespace GeBlod
{
    public partial class DonationSiteActivity
    {
        private readonly string _url =
            @"https://geblod.nu/wp-content/themes/default/api/?type=schedule&rid=13&d1=2017/05/20&d2=2017/05/29";

        private readonly HttpClient _client = new HttpClient();
        public ObservableCollection<DonationSite> DonationSites { get; } = new ObservableCollection<DonationSite>();

        public DonationSiteActivity()
        {
            InitializeComponent();
            BindingContext = this;
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

        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            LoadJson();
            //set IsRefreshing to false
        }
    }
}
