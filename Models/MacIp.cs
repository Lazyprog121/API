namespace webApi.Models
{
    public class MacIp
    {
        public MacIp(Mac mac, Ip ip)
        {
            Mac_isPrivate = mac.vendorDetails.isPrivate;
            Mac_companyName = mac.vendorDetails.companyName;
            Mac_companyAddress = mac.vendorDetails.companyAddress;
            Mac_countryCode = mac.vendorDetails.countryCode;
            Mac_isValid = mac.macAddressDetails.isValid;
            Mac_searchTerm = mac.macAddressDetails.searchTerm;

            Ip_ip = ip.ip;
            Ip_type = ip.type;
            Ip_country = ip.country;
            Ip_latitude = ip.latitude;
            Ip_longitude = ip.longitude;
            Ip_city = ip.city;
        }
        public bool Mac_isPrivate { get; set; }
        public string Mac_companyName { get; set; }
        public string Mac_companyAddress { get; set; }
        public string Mac_countryCode { get; set; }
        public bool Mac_isValid { get; set; }
        public string Mac_searchTerm { get; set; }
        public string Ip_ip { get; set; }
        public string Ip_type { get; set; }
        public string Ip_country { get; set; }
        public double Ip_latitude { get; set; }
        public double Ip_longitude { get; set; }
        public string Ip_city { get; set; }
    }
}
