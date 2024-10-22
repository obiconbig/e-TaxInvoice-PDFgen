namespace eTaxInvoicePdfGenerate.Models
{
    public class Buyer
    {
        public string name { set; get; } = "";
        public string address1 { set; get; } = "";
        public string address2 { set; get; } = "";
        public string zipcode { set; get; } = "";
        public string tax_id { set; get; } = "";
        public bool is_branch { set; get; } = false;
        public string branch_id { set; get; } = "";
        public string website { set; get; } = "";
        public string email { set; get; } = "";
        public string contact_person { set; get; } = "";
        public string phone_no { set; get; } = "";
        public string phone_ext { set; get; } = "";
        public string fax_no { set; get; } = "";
        public string fax_ext { set; get; } = "";
        public string province_name { set; get; } = "";
        public string province_code { set; get; } = "";
        public string district_name { set; get; } = "";
        public string district_code { set; get; } = "";
        public string subdistrict_name { set; get; } = "";
        public int subdistrict_code { set; get; }
        public string house_no { set; get; } = "";
        public string tax_type { set; get; } = "";

    }
}
